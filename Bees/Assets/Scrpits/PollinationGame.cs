using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollinationGame : MonoBehaviour
{

    //like on collision but for character controller since it doesnt use rigidbody

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            MiniGameManager.instance.currentMiniGame.IncreaseScore(
                MetricName.PollenDelivered,
                MiniGameManager.instance.currentMiniGame.GetScore(MetricName.PollenCollected)
            );

            MiniGameManager.instance.currentMiniGame.ResetScore(MetricName.PollenCollected);
        }
    }


}
