using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreTrigerPoint : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI score;

    private int currentScore = 0;
    public  void IncreaseScore()
    {
        currentScore += 1;
        score.text = currentScore.ToString(); 
    }  
}
