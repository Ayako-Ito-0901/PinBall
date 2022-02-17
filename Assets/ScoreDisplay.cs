using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    ScoreContainer scoreContainer; //ScoreContainerを使いますよという宣言

    //スコアテキストの初期化
    private GameObject scoreText;

    string test = "";

    //点数
    private int smallCloudScore = 10; //小さな雲
    private int largeCloudScore = 30; //大きな雲
    private int largeStarScore = 5; //大きな星
    private int smallStarScore = 1; //小さな星

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のscoreTextオブジェクトを取得する
        this.scoreText = GameObject.Find("ScoreText");
        //scoreText中のScoreContainerコンポーネントの取得 ScoreContainerの関数を使うために。
        scoreContainer = scoreText.GetComponent<ScoreContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision collision) {
        string yourTag = collision.gameObject.tag;

        if(yourTag == "LargeCloudTag") {
            scoreContainer.AddScore(largeCloudScore);
        }
        else if(yourTag == "SmallCloudTag") {
            scoreContainer.AddScore(smallCloudScore);
        }
        else if(yourTag == "SmallStarTag") {
            scoreContainer.AddScore(smallStarScore);
        }
        else if(yourTag == "LargeStarTag") {
            scoreContainer.AddScore(largeStarScore);
        }
    }
}
