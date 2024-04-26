using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float scoreCount = 5;
    
    [SerializeField] private static float scoreP1;
    public float ScoreP1 { get { return scoreP1;} set { scoreP1 = value; } }
    
    [SerializeField] private static float scoreP2;
    public float ScoreP2 { get { return scoreP2;} set { scoreP2 = value; } }
    
    [SerializeField] private TextMeshPro scoreP1txt, scoreP2txt;
    
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

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreP1 = 0;
        scoreP2 = 0;
    }
}
