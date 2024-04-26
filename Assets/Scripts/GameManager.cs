using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float scoreCount = 5;
    
    private static float scoreP1;
    public float ScoreP1 { get { return scoreP1;} set { scoreP1 = value; } }
    
    private static float scoreP2;
    public float ScoreP2 { get { return scoreP2;} set { scoreP2 = value; } }

    [SerializeField] private float duration;
    public static float curTime;
    
    public void PlayerGotHit(bool one)
    {
        if (one)
        {
            scoreP2 += scoreCount;
        }
        else
        {
            scoreP1 += scoreCount;
        }
    }

    private void Timing()
    {
        if (curTime > 0)
        {
            curTime -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Time UP");
            SceneManager.LoadScene(1);
        }
        
        minutes = Mathf.FloorToInt(curTime / 60f);
        seconds = Mathf.FloorToInt(curTime - minutes * 60);
    }
    
    public static float minutes;
    public static float seconds;
    
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        scoreP1 = 0;
        scoreP2 = 0;

        curTime = duration;
    }

    void Update()
    {
        Timing();
    }
}
