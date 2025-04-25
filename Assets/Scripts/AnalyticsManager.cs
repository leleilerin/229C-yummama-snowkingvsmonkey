using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;
    private static float scorePerHit;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        Initialize();
    }

    private void Start()
    {
        scorePerHit = GameManager.instance.scorePerHit;
    }

    private async void Initialize()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }
    
    //Method

    public void LeftPlayerScored(bool isLeft)
    {
        if (isLeft)
        {
            AnalyticsService.Instance.RecordEvent(leftScore);
            Debug.Log($"P1 get {scorePerHit} points");
        }
        else
        {
            AnalyticsService.Instance.RecordEvent(rightScore);
            Debug.Log($"P2 get {scorePerHit} points");
        }
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

    public CustomEvent gameTie = new CustomEvent("GameTie")
    {
        { "tieCount", 1 }
    };
    
    public CustomEvent leftScore = new CustomEvent("LeftScore")
    {
        {"score", scorePerHit}
    };
    
    public CustomEvent rightScore = new CustomEvent("RightScore")
    {
        {"score", scorePerHit}
    };


}
