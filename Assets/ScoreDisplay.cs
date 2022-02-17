using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //追記。スクリプトでUIを操作する場合は、「using UnityEngine.UI;」を記述する。

public class ScoreDisplay : MonoBehaviour
{
    
    //スコアテキストの初期化
    private GameObject scoreText;
    //スコアの初期化
    int score = 0;

    string test = "";

    //点数
    private int smallCloudScore = 10; //小さな雲
    private int largeCloudScore = 30; //大きな雲
    private int largeStarScore = 5; //大きな星
    private int smallStarScore = 1; //小さな星

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得する
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision collision) {
        string yourTag = collision.gameObject.tag;
        Debug.Log(collision.gameObject.tag);
        if(yourTag == "LargeCloudTag") {
            score += largeCloudScore;
        }
        else if(yourTag == "SmallCloudTag") {
            score += smallCloudScore;
        }
        else if(yourTag == "SmallStarTag") {
            score += smallStarScore;
        }
        else if(yourTag == "LargeStarTag") {
            score += largeStarScore;
        }
        
        this.scoreText.GetComponent<Text> ().text = "Score:" + score;
    }
}
