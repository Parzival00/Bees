using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Oculus.Interaction.Samples;
using UnityEngine.Audio;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance;
    public PlayerUIManager playerUIManager;

    public MiniGameScriptable currentMiniGame;
    public MiniGameScriptable[] allMiniGames;
    public int miniGameIndex = 0;
    private HiveCluster[] allClusters;


    private List<GameObject> miniGameSpawns = new List<GameObject>();
    public bool playStarted;
    private bool sceneLoaded = false;
    public float tutWindowCounter = 0;
    public float miniGameCounter = 0;

    public AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(audioManager);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        allClusters = FindObjectsOfType<HiveCluster>();
        playerUIManager = GetComponentInChildren<PlayerUIManager>();
        currentMiniGame = allMiniGames[0];
        StartCoroutine(LoadSceneAndDisplayInfo());

    }


    private void Update()
    {
        if (tutWindowCounter <= currentMiniGame.tutorialWindowTime)
        {
            tutWindowCounter += Time.deltaTime;
            
        }
        else
        {
            if (playStarted)
            {
                miniGameCounter += Time.deltaTime;
                if (miniGameCounter >= currentMiniGame.MiniGameTime)
                {
                    NextMiniGame();
                }
            }

        }
        
    }

    public void NextMiniGame()
    {
        miniGameCounter = 0;
        tutWindowCounter = 0;
        playStarted = false;
        currentMiniGame.SaveMiniGameMetrics();
        miniGameIndex++;
        if (miniGameIndex >= allMiniGames.Length) { miniGameIndex = 0; }
        currentMiniGame = allMiniGames[miniGameIndex];
        StartCoroutine(LoadSceneAndDisplayInfo());
    }


    private IEnumerator LoadSceneAndDisplayInfo()
    {
        // Change music track based on the loaded mini-game
       if (audioManager != null) {
        audioManager.ChangeMusic(currentMiniGame.musicTrackID);
        } else {
        Debug.LogWarning("AudioManager instance is null.");
        }

        currentMiniGame.ResetScores();
        
        SceneManager.LoadScene(currentMiniGame.GameScene);

        // Change music track based on the loaded mini-game
        //AudioManager.audioManager.ChangeMusic(currentMiniGame.musicTrackID);

        yield return new WaitUntil(() => sceneLoaded);

                miniGameCounter = 0;
        tutWindowCounter = 0;
        // Get all clusters again as they might have changed after scene load
        allClusters = FindObjectsOfType<HiveCluster>();

        foreach (var cluster in allClusters)
        {
            cluster.SetUPCells(currentMiniGame.combCellsSettings.CappedCellsPercentage, currentMiniGame.combCellsSettings.HoneyCellsPercentage);

            if (!cluster.playerReach)
            {
                cluster.DisableAllCells();
            }
        }

        // Add pollen logic here

        // Instantiates the spawner for this miniGame
        if (currentMiniGame.SetUpSpawner != null)
        {
            miniGameSpawns.Add(Instantiate(currentMiniGame.SetUpSpawner));
        }

        // Display mini game info after scene has loaded
        playerUIManager = FindObjectOfType<PlayerUIManager>();
        playerUIManager.DisplyMiniGameInfo(currentMiniGame);

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneLoaded = true;
    }


}
