using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPollinationTracker : ScoreModifier
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (IncreasescoreIfAplicable(MetricName.FlowersPollenated, 1))
            {
                Destroy(this);//destroy this script on the flower
            }
        }
    }

}
