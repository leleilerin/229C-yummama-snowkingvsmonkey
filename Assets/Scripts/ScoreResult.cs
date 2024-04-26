using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreResult : MonoBehaviour
{
    [SerializeField] private GameObject scoreP1Text, scoreP2Text;

    private void Start()
    {
        scoreP1Text.GetComponent<Text>().text = $"{GameManager.instance.ScoreP1}";
        scoreP2Text.GetComponent<Text>().text = $"{GameManager.instance.ScoreP2}";
    }
}
