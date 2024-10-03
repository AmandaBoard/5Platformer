using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image scoreBarFill;
    public int maxTokens = 20;
    
    public void UpdateScoreBar(int currentTokens){
        float fillAmount = (float)currentTokens / maxTokens;
        scoreBarFill.fillAmount = fillAmount;
    }
}
