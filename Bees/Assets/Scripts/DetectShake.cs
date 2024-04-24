using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(InputData))]
public class DetectShake : MonoBehaviour
{
    private InputData _inputData;
    GameObject player;
    [SerializeField] MiniGameScriptable defenseScriptable;
    [SerializeField] float shakeThreshold;
    [SerializeField] float maxShakeTime;
    [SerializeField] float detectionRadius;
    float shakeTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        //If the player is close enough to the wasp and is shaking their controller, up the shake time
        if(_inputData._leftController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity) && Vector3.Distance(this.transform.position, player.transform.position) <= detectionRadius)
        {
            if(Mathf.Abs(leftVelocity.magnitude) > shakeThreshold)
            {
                shakeTime += Time.deltaTime;
            }
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity) && Vector3.Distance(this.transform.position, player.transform.position) <= detectionRadius)
        {
            if (Mathf.Abs(rightVelocity.magnitude) > shakeThreshold)
            {
                shakeTime += Time.deltaTime;
            }
        }


        //if reached the shaking goal, kill the wasp
        if(shakeTime >= maxShakeTime)
        {
            defenseScriptable.IncreaseScore(MetricName.EnemiesDefeated, 1f);
            Destroy(this.gameObject);
        }
        
    }
}
