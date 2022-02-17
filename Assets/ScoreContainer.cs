using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContainer : MonoBehaviour
{
    Text scoreText;
    int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        //初期値のスコアテキスト
        Debug.Log("scoreText初期値：" + scoreText.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int addScore) {
        totalScore += addScore;
        scoreText.text = "Score:" + totalScore.ToString();
    }
}
