using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModifier : MonoBehaviour
{
    protected void IncreasescoreIfAplicable(MetricName targetMetric, float pointValue)
    {
        foreach (GameMetrics score in MiniGameManager.instance.currentMiniGame.miniGameScores)
        {
            if (score.metricName == targetMetric)
            {
                MiniGameManager.instance.currentMiniGame.IncreaseScore(targetMetric, pointValue);
                return;
            }
        }
    }
    protected void DecreasescoreIfAplicable(MetricName targetMetric, float pointValue)
    {
        foreach (GameMetrics score in MiniGameManager.instance.currentMiniGame.miniGameScores)
        {
            if (score.metricName == targetMetric)
            {
                MiniGameManager.instance.currentMiniGame.DecreaseScore(targetMetric, pointValue);
                return;
            }
        }
    }
}
