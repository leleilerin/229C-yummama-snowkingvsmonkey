using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreP1Txt;
    [SerializeField] private TextMeshProUGUI scoreP2Txt;
    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] private TextMeshProUGUI resultTxt;

    private float scoreP1;
    private float scoreP2;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreP1Txt.text = $"Snow King: {scoreP1}";
        scoreP2Txt.text = $"Monkey: {scoreP2}";
        timeTxt.text = "00:00";
    }

    // Update is called once per frame
    void Update()
    {
        scoreP1 = GameManager.instance.ScoreP1;
        scoreP2 = GameManager.instance.ScoreP2;
        
        scoreP1Txt.text = $"Snow King: {scoreP1}";
        scoreP2Txt.text = $"Monkey: {scoreP2}";
        
        if (GameManager.curTime <= 0)
        {
            timeTxt.text = "00:00";
            SceneManager.LoadScene(2);
        }
        else
        {
            timeTxt.text = string.Format("{0:0}:{1:00}", GameManager.minutes, GameManager.seconds); 
        }

        if (scoreP1 > scoreP2)
        {
            resultTxt.text = "Snow King WON!!!";
        }
        else if (scoreP2 > scoreP1)
        {
            resultTxt.text = "Monkey WON!!!";
        }
        else
        {
            resultTxt.text = "TIE!!!";
        }
    }
}
