using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class EndgameAnalytics : MonoBehaviour
{
    private static float scoreP1 = GameManager.instance.ScoreP1;
    private static float scoreP2 = GameManager.instance.ScoreP2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WinCount(GameManager.instance.isLeftWin, GameManager.instance.isTie);
        ScoreCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Method
    public void WinCount(bool isLeftWin, bool isTie)
    {
        if (!isTie)
        {
            switch (isLeftWin)
            {
                case true:
                    AnalyticsService.Instance.RecordEvent(AnalyticsManager.instance.leftWin);
                    Debug.Log("leftWin");
                    break;
                case false:
                    AnalyticsService.Instance.RecordEvent(AnalyticsManager.instance.rightWin);
                    Debug.Log("rightWin");
                    break;
            }
        }
        else
        {
            AnalyticsService.Instance.RecordEvent(AnalyticsManager.instance.gameTie);
            Debug.Log("tie");
        }
    }

    public void ScoreCount()
    {
        AnalyticsService.Instance.RecordEvent(scoreCount);
        Debug.Log(scoreP1 + scoreP2);
    }
    
    //Event
    public CustomEvent scoreCount = new CustomEvent("ScoreCount")
    {
        { "leftScore", scoreP1 },{"rightScore", scoreP2}
    };
}
