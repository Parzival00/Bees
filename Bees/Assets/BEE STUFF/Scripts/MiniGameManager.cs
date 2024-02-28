using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Oculus.Interaction.Samples;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance;
    public PlayerUIManager playerUIManager;

    protected MiniGameScriptable currentMiniGame;
    public MiniGameScriptable[] allMiniGames;
    private HiveCluster[] allClusters;


    private List<GameObject> miniGameSpawns = new List<GameObject>();
    public Transform hiveEntranceSpawn;
    public Transform queenBeeSpawn;

    private float tutWindowCounter = 0;
    private float miniGameCounter = 0;
    public bool playStarted;
    private bool sceneLoaded = false;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        allClusters = FindObjectsOfType<HiveCluster>();

        currentMiniGame = allMiniGames[0];
        StartCoroutine(LoadSceneAndDisplayInfo());

    }

    ////update
    private void Update()
    {
        //playerUIManager.DisplyMiniGameInfo(currentMiniGame);

        //if (tutWindowCounter <= currentMiniGame.tutorialWindowTime)
        //{
        //    tutWindowCounter++;


        //}
        //else
        //{

        //    miniGameCounter++;
        //    //ending mingame later
        //}

    }

    private IEnumerator LoadSceneAndDisplayInfo()
    {
        currentMiniGame.ResetScores();

        SceneManager.LoadScene(currentMiniGame.GameScene);

        yield return new WaitUntil(() => sceneLoaded);


        // Get all clusters again as they might have changed after scene load
        allClusters = FindObjectsOfType<HiveCluster>();

        foreach (var cluster in allClusters)
        {
            cluster.SetUPCells(currentMiniGame.CappedCellsPercentage, currentMiniGame.HoneyCellsPercentage);

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


    //called by the spawners for the miniGame
    public void SpawnMiniGameActors(GameObject spawn, Transform locationSpawn)
    {
        miniGameSpawns.Add( Instantiate(spawn,locationSpawn.position,Quaternion.identity));
    }

}
