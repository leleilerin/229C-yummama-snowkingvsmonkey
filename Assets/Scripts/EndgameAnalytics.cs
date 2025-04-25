using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class EndgameAnalytics : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(GameManager.instance.isTie);
        if (!GameManager.instance.isTie)
        {
            Debug.Log("RUN");
            WinCount(GameManager.instance.isLeftWin);
        }
        else
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Method
    public void WinCount(bool isLeftWin)
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
}
