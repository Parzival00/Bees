using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TrackerPoseDriverCanvasFollow : TrackedPoseDriver
{
    [SerializeField]
    public Transform canvas; // Reference to the UI canvas

    public float distanceFromHead = 2f; // Distance between the head and the canvas

    protected override void PerformUpdate()
    {
        // Call the base PerformUpdate method to update the transform according to tracking data
        base.PerformUpdate();

        // Move the canvas along with the camera
        if (canvas != null)
        {
            // Calculate the position of the canvas relative to the camera
            Vector3 canvasOffset = transform.forward * distanceFromHead; // Adjust 2f to your desired distance

            // Set the position of the canvas
            canvas.position = transform.position + canvasOffset;
            canvas.rotation = transform.rotation;
        }
    }
}