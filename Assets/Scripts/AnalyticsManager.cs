using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
        Initialize();
    }

    void Update()
    {
        
    }

    private async void Initialize()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }
    
    //Method
    public void WinCount(bool isLeftWin)
    {
        if (isLeftWin)
        {
            AnalyticsService.Instance.RecordEvent(leftWin);
        }
        else
        {
            AnalyticsService.Instance.RecordEvent(rightWin);
        }
    }
    
    //Event
    private CustomEvent leftWin = new CustomEvent("LeftWin")
    {
        { "winCount", 1 }
    };
    
    private CustomEvent rightWin = new CustomEvent("RightWin")
    {
        { "winCount", 1 }
    };

    
}
