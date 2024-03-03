using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModifier : MonoBehaviour
{
    protected bool IncreasescoreIfAplicable(MetricName targetMetric, float pointValue)
    {
        foreach (GameMetrics score in MiniGameManager.instance.currentMiniGame.miniGameScores)
        {
            if (score.metricName == targetMetric)
            {
                if (targetMetric == MetricName.PollenCollected && score.MetricScore >= 100)
                {
                    return false;
                }
                else
                {
                    MiniGameManager.instance.currentMiniGame.IncreaseScore(targetMetric, pointValue);

                    return true;
                }
            }
        }
        return false;
    }
    protected bool DecreasescoreIfAplicable(MetricName targetMetric, float pointValue)
    {
        foreach (GameMetrics score in MiniGameManager.instance.currentMiniGame.miniGameScores)
        {
            if (score.metricName == targetMetric)
            {

                MiniGameManager.instance.currentMiniGame.DecreaseScore(targetMetric, pointValue);
                return true;
            }
        }
        return false;
    }
}
