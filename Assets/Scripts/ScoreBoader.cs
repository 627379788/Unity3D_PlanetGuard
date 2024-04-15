using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoader : MonoBehaviour
{
    int score = 0;
    TMP_Text tmpText;
    void Start(){
        tmpText = GetComponent<TMP_Text>();
        tmpText.text = score.ToString();
    }
    public void IncreaseScore(int IncreaseScore) {
        score += IncreaseScore;
        tmpText.text = score.ToString();
    }
}
