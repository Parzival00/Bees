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
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject;
        animator = GetComponent<Animator>();
        animator.SetBool("isFlying", true);
        animator.SetFloat("Speed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is close enough to the wasp and is shaking their controller, up the shake time
        if (Vector3.Distance(this.transform.position, player.transform.position) <= detectionRadius)
        {
            if (_inputData._leftController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity))
            {

                if (Mathf.Abs(leftVelocity.magnitude) > shakeThreshold)
                {
                    shakeTime += Time.deltaTime;
                }
            }

            if (_inputData._rightController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
            {
                if (Mathf.Abs(rightVelocity.magnitude) > shakeThreshold)
                {
                    shakeTime += Time.deltaTime;
                }
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
