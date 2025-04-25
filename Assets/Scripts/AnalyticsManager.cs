using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        Initialize();
    }

    private async void Initialize()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }
    
    //Event
    public CustomEvent leftWin = new CustomEvent("LeftWin")
    {
        { "winCount", 1 }
    };
    
    public CustomEvent rightWin = new CustomEvent("RightWin")
    {
        { "winCount", 1 }
    };

    
}
