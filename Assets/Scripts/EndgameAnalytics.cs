using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class EndgameAnalytics : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WinCount(GameManager.instance.isLeftWin, GameManager.instance.isTie);
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
}
