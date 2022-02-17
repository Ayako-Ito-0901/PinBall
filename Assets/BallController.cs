using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //追記。スクリプトでUIを操作する場合は、「using UnityEngine.UI;」を記述する。

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト初期化
    private GameObject gameoverText;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得する
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外にでた場合の処理　this.transformでボールなのか。→スクリプトをボールにアタッチしたから
        if(this.transform.position.z < this.visiblePosZ) {
            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text> ().text = "Game Over";
        }
    }
}
