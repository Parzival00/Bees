using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{

    [Header("Pop up for instructions")]
    public TMP_Text miniGameName;
    public TMP_Text minGameDesc;
    public GameObject TutorialWindow;
    public Button closeTutrialButton;

    [Header("Score Prefab")]
    public GameObject scoreGO;


    public void DisplyMiniGameInfo(MiniGameScriptable g)
    {
        Debug.Log("MINI GAME UI SE UP: "+ g.MiniGameName);
        miniGameName.text = g.MiniGameName;
        minGameDesc.text = g.MiniGameDescription;

    }

    public void HideTutorialWindow()
    {
        TutorialWindow.SetActive(false);
        MiniGameManager.instance.playStarted = true;
    }

    public void SpawnMiniGameScores()
    {

    }



}
