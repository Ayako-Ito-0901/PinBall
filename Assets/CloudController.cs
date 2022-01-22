using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    //最小サイズ
    private float minimum = 1.0f;
    //拡大縮小スピード
    private float magSpeed = 10.0f;
    //拡大率
    private float magnification = 0.07f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //雲を拡大、縮小
        //オブジェクトのサイズ変更：transform.localScaleにそれぞれの軸方向の拡大率を渡す。
        //lacalScaleに値を代入する時は、Vector3を用いる。
        //Vector：オブジェクトの座標やオブジェクトに加わる力の方向を扱う型。Vector2はfloat型のx, yの要素を持っており、Vector3はfloat型のx, y, zの要素を持っている。
        //Vectorはインスタンスを生成して使うこと　例）Vector3 vec = new Vector3(1.0f, 2.0f, 3.0f);
        this.transform.localScale =  new Vector3(this.minimum +  Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimum +  Mathf.Sin(Time.time * this.magSpeed) * this.magnification);

        //Mathfクラスの「Sin」関数:引数に与えた角度をサインの値で返す。また、引数はラジアンで指定。
        //Timeクラスの「time」は、ゲーム開始から何秒経ったかを取得できる
    }
}
