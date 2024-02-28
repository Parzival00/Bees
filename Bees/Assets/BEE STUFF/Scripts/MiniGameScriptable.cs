using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;


[System.Serializable]
public class GameMetrics
{
    public float MetricScore;
    public string MetricName;
}


//HINT: to create a new mini game asset, go in the MiniGames Folder in BEE STUFF and right click,
//go to the top and find Scriptable Objects -> Mini Game Scriptable, and put in what ever info you need to do

[CreateAssetMenu(fileName = "MiniGame", menuName = "ScriptableObjects/MiniGameScriptable")]

// Added 'public' access modifier to the class declaration
public class MiniGameScriptable : ScriptableObject
{
    [Header("UI Data")]
    public string MiniGameName;
    public float MiniGameTime;
    public float tutorialWindowTime = 40;
    public string MiniGameDescription = "Collect pollen by interacting with the flowers in the garden until your pollen meter is full";
    public GameMetrics[] miniGameScores; // some mingames may have more than one metic to track.


    //NOTE these two values should not be in excess of 100 percent, if they do not total 100 percent, this means the other percent of cells will be empty
    //capped cells have thier scripts destroyed to save on computational power
    //only relevant for games inside the hive
    [Header("Comb Cells Settings")]
    [Range(0f, 1f)]
    public float CappedCellsPercentage = 0.2f; // Default value represents 20%

    [Range(0f, 1f)]
    public float HoneyCellsPercentage = 0.2f; // Default value represents 20%


    [Header("Set Up information")]
    public GameObject SetUpSpawner;
    public string GameScene;



    //Call in MiniGame Manager when score should be increased
    public void IncreaseScore(string scoreName, float increase)
    {
        increase = Mathf.Abs(increase);
        foreach(GameMetrics metric in miniGameScores)
        {
            if (metric.MetricName == scoreName)
            {
                metric.MetricScore += increase;

                Debug.Log("Score Increased");
                return;
            }
        }
        Debug.Log("ScoreName " + scoreName + " invalid, please update script with propper name ");
    }


    //Call in MiniGame Manager when score should be decreased
    public void DecreaseScore(string scoreName, float decrease)
    {
        decrease = Mathf.Abs(decrease);

        foreach (GameMetrics metric in miniGameScores)
        {
            if (metric.MetricName == scoreName)
            {
                metric.MetricScore -= decrease;

                Debug.Log("Score decreased");
                return;
            }
        }
        Debug.Log("ScoreName " + scoreName + " invalid, please update script with propper name ");
    }


    //called when the mini game is over
    // Called when the mini-game is over
    public void SaveMiniGameMetrics()
    {
        foreach (GameMetrics metric in miniGameScores)
        {
            // Save the player's scores in player prefs
            PlayerPrefs.SetFloat(metric.MetricName, metric.MetricScore);
        }

        // Save PlayerPrefs to disk
        PlayerPrefs.Save();

        Debug.Log("Mini-game metrics saved successfully.");
    }

    public void ResetScores()
    {
        foreach (GameMetrics metric in miniGameScores)
        {
            metric.MetricScore = 0;
        }

    }

}
