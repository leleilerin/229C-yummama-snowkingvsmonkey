using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AnalyticsService.Instance.RecordEvent(leftWinCount);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            AnalyticsService.Instance.RecordEvent(rightWinCount);
        }
    }

    private async void Initialize()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }
    
    private CustomEvent leftWinCount = new CustomEvent("sideWinCount")
    {
        { "leftWin", 1 }
    };
    
    private CustomEvent rightWinCount = new CustomEvent("sideWinCount")
    {
        { "rightWin", 1 }
    };

    
}
