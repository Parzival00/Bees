using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerUIManager : MonoBehaviour
{

    [Header("Pop up for instructions")]
    public TMP_Text miniGameName;
    public TMP_Text minGameDesc;
    public GameObject TutorialWindow;
    public Button closeTutrialButton;

    [Header("Score Prefab")]
    public GameObject scoreGO;
    public TMP_Text timer;

    //Audio Manager
    AudioManager audioManager;

     //Audio
    private void Awake()
    {
       audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        closeTutrialButton = GetComponentInChildren<Button>();
    }

    private void Update()
    {
        if (MiniGameManager.instance.tutWindowCounter > MiniGameManager.instance.currentMiniGame.tutorialWindowTime)
        {
            closeTutrialButton.interactable = true;
        }
        timer.text = ((int)(MiniGameManager.instance.currentMiniGame.MiniGameTime - MiniGameManager.instance.miniGameCounter)).ToString();
    }


    public void DisplyMiniGameInfo(MiniGameScriptable g)
    {
        miniGameName.text = g.MiniGameName;
        minGameDesc.text = g.MiniGameDescription;

    }
    [ContextMenu("Start Mini Game")]
    public void HideTutorialWindow()
    {
        audioManager.PlaySFX(audioManager.menuClick);
        TutorialWindow.SetActive(false);
        MiniGameManager.instance.playStarted = true;
        SpawnMiniGameScores();
    }

    public void SpawnMiniGameScores()
    {
        if(MiniGameManager.instance.currentMiniGame.minGameUIBackGround != null)
        {
            GameObject scoreBG = Instantiate(MiniGameManager.instance.currentMiniGame.minGameUIBackGround, scoreGO.transform);
            MiniGameManager.instance.currentMiniGame.SpawnUIPrefabs(scoreBG);
        }
        else
        {
            MiniGameManager.instance.currentMiniGame.SpawnUIPrefabs(scoreGO);
        }


    }



}
