using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPollinationTracker : ScoreModifier
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (IncreasescoreIfAplicable(MetricName.FlowersPollenated, 1))
            {
                Destroy(this.gameObject);//destroy this script on the flower
            }
        }
    }


}
