using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ScoreModifier : MonoBehaviour
{
    protected bool IncreasescoreIfAplicable(MetricName targetMetric, float pointValue)
    {
        //if we are pollenating a flower
        if (targetMetric == MetricName.FlowersPollenated)
        {
            //has pollen on legs
            if (MiniGameManager.instance.currentMiniGame.GetScore(MetricName.PollenCollected) > -1)
            {
                //increase number of flowers pollinated
                foreach (GameMetrics metric in MiniGameManager.instance.currentMiniGame.miniGameScores)
                {
                    if (metric.metricName == targetMetric)
                    {

                        metric.MetricScore += pointValue;
                        metric.Ui_Instance.ChangeScore(metric.MetricScore);
                        Debug.Log("Score Increased");
                        return true;
                    }
                }
                return false;
            }
        }
        else
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
