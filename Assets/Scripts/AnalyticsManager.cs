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
            AnalyticsService.Instance.RecordEvent(leftWin);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            AnalyticsService.Instance.RecordEvent(rightWin);
        }
    }

    private async void Initialize()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }
    
    private CustomEvent leftWin = new CustomEvent("LeftWin")
    {
        { "winCount", 1 }
    };
    
    private CustomEvent rightWin = new CustomEvent("RightWin")
    {
        { "winCount", 1 }
    };

    
}
