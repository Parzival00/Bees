using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollinationGame : MonoBehaviour
{
    public MiniGameScriptable pollenScriptable;
    public PollenManager pollenManager;
    [SerializeField] int subtractionAmount;
    [SerializeField] float scoreIncrease;
    [SerializeField] float timeToDecrease;
    bool subtracting = false;


    //while the player is within the deposit radius, the game will incrementally subtract pollen from their inventory and increase their score and deposited pollen
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (!subtracting && pollenManager.getPollenCount() > 0)
            {
                StartCoroutine(SubtractPollen());
            }
        }
    }

    //takes in the specific amount of pollen to deposit, how often, and how much score to give, and repeats every n seconds while the player is depositing
    IEnumerator SubtractPollen()
    {
        subtracting = true;

        pollenManager.playerPollen.count -= subtractionAmount;
        pollenScriptable.IncreaseScore(MetricName.PollenDelivered, scoreIncrease);

        yield return new WaitForSeconds(timeToDecrease);

        subtracting = false;
    }


}
