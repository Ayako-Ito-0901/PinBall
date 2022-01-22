using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    //回転速度を定義　float型の変数に値を代入するときは、値の最後に「f」を書く
    private float rotSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //回転を開始する角度を設定　y軸をランダム→星が複数時すべての星がバラバラに回転しているように見せる
        //Randomクラスの「Range」関数は、第一引数以上、第二引数未満の整数をランダムに返す。
        this.transform.Rotate (0, Random.Range(0, 360), 0);
    }

    // Update is called once per frame
    void Update()
    {
        //回転 引数に与えた角度の文だけ回転。第一引数から順番に、X軸、Y軸、Z軸を中心とした回転量を渡す
        this.transform.Rotate (0, this.rotSpeed, 0);
    }
}
