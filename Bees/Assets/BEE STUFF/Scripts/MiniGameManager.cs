using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class MiniGameManager : MonoBehaviour
{
    protected MiniGameScriptable currentMiniGame;
    public MiniGameScriptable[] allMiniGames;
    private HiveCluster[] allClusters;

    public static MiniGameManager instance;
    private List<GameObject> miniGameSpawns = new List<GameObject>();
    public Transform hiveEntranceSpawn;
    public Transform queenBeeSpawn;




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
        StartMiniGame();

    }


    //Called at the begining of every minigame to set it up
    public async void StartMiniGame()
    {
        currentMiniGame.ResetScores();

        // Use a TaskCompletionSource to await scene loading
        var sceneLoadTask = new TaskCompletionSource<bool>();
        SceneManager.sceneLoaded += (scene, mode) => sceneLoadTask.SetResult(true);

        SceneManager.LoadScene(currentMiniGame.GameScene);

        // Wait for the scene to finish loading
        await sceneLoadTask.Task;

        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= (scene, mode) => sceneLoadTask.SetResult(true);

        // Get all clusters again as they might have changed after scene load
        allClusters = FindObjectsOfType<HiveCluster>();

        foreach (var cluster in allClusters)
        {
            cluster.SetUPCells(currentMiniGame.CappedCellsPercentage, currentMiniGame.HoneyCellsPercentage);

            //if the player cannot reach this cluster and it is just for looks, remove it's functionality and collision
            if (!cluster.playerReach)
            {
                cluster.DisableAllCells();
            }
        }

        // Instantiates the spawner for this miniGame
        if (currentMiniGame.SetUpSpawner != null)
        {
            miniGameSpawns.Add(Instantiate(currentMiniGame.SetUpSpawner));
        }
    }


    //called by the spawners for the miniGame
    public void SpawnMiniGameActors(GameObject spawn, Transform locationSpawn)
    {
        miniGameSpawns.Add( Instantiate(spawn,locationSpawn.position,Quaternion.identity));
    }

}
