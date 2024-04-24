using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputData : MonoBehaviour
{
    public InputDevice _rightController;
    public InputDevice _leftController;
    public InputDevice _HMD;

    void Update()
    {
        if(!_rightController.isValid || !_leftController.isValid || !_HMD.isValid)
        {
            InitializeInputDevices();
        }
    }

    void InitializeInputDevices()
    {
        if (!_rightController.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref _rightController);
        }

        if (!_leftController.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref _leftController);
        }

        if (!_HMD.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.HeadMounted, ref _HMD);
        }
    }

    void InitializeInputDevice(InputDeviceCharacteristics inputCharacteristics, ref InputDevice inputDevice)
    {
        List<InputDevice> devices = new();
        //Call input device to see if it can find any devices with the characteristics we need
        InputDevices.GetDevicesWithCharacteristics(inputCharacteristics, devices);

        if(devices.Count > 0)
        {
            inputDevice = devices[0];
        }
    }
}
