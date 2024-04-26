using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreP1Txt;
    [SerializeField] private TextMeshProUGUI scoreP2Txt;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreP1Txt.text = $"Snow King: {GameManager.instance.ScoreP1}";
        scoreP2Txt.text = $"Monkey: {GameManager.instance.ScoreP2}";
    }

    // Update is called once per frame
    void Update()
    {
        scoreP1Txt.text = $"Snow King: {GameManager.instance.ScoreP1}";
        scoreP2Txt.text = $"Monkey: {GameManager.instance.ScoreP2}";
    }
}
