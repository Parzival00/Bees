using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PollinationGame : MonoBehaviour
{

    //Audio Manager
    AudioManager audioManager;

    //Audio
    private void Awake()
    {
       audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void Start()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }




    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.itemTurnin);

            MiniGameManager.instance.currentMiniGame.IncreaseScore(
                MetricName.PollenDelivered,
                MiniGameManager.instance.currentMiniGame.GetScore(MetricName.PollenCollected)
            );

            MiniGameManager.instance.currentMiniGame.ResetScore(MetricName.PollenCollected);
        }
    }


}
