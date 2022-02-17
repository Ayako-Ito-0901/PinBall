using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    //Materialを入れる
    Material myMaterial;

    //Emissionの最小値
    private float minEmission = 0.2f;
    //Emissionの強度
    private float magEmission = 2.0f;
    //角度　★光の強度？
    private int degree = 0;
    //発光速度
    private int speed = 5;
    //ターゲットのデフォルトの色
    Color defaultColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        //タグによって光らせる色を変える　★tagでこのスクリプトがアタッチされているタグが取得できる
        if(tag == "SmallStarTag") {
            this.defaultColor = Color.white;
        }
        else if(tag == "LargeStarTag") {
            this.defaultColor = Color.yellow;
        }
        else if(tag == "SmallCloudTag" || tag == "LargeCloudTag") {
            this.defaultColor = Color.cyan;
        }

        //オブジェクトにアタッチしているMaterialを取得 雲やスターのマテリアルを取得★
        //コンポーネントRendererを取得
        this.myMaterial = GetComponent<Renderer> ().material;

        //オブジェクトの最初の色を設定　Materialクラスの「SetColor」関数は、マテリアルの色を設定
        //第一引数に変更したい色のパラメータを指定し、第二引数に変更する色の値を指定
        //第一引数にEmissionのパラメータ名である_EmissionColorを指定し、第二引数にはTagで個々に設定した色を最小限に光らせた値を指定
        //★この_EmissionColorはどこから出てきたのか？
        myMaterial.SetColor("_EmissionColor", this.defaultColor*minEmission);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.degree >= 0) {
            //光らせる強度を計算する 「Color」は色を設定するためのクラス.
            //色の種類に発光の強さを掛けて代入している
            //Sin関数に渡す値は度数ではなくラジアンでなくてはならないため、this.degree * Mathf.Deg2Radと記述して度数をラジアンに変換している。「Mathf.Deg2Rad」は、度数に掛けることでラジアンに変換できる
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            //エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            this.degree -= this.speed;
        }
    }

    //衝突時に呼ばれる関数 unityで当たり判定をする時にはOnTriggerEnterやOnCollisionEnterなどいくつかの関数が使われる
    void OnCollisionEnter(Collision other) {
        //角度を180に設定
        this.degree = 180;
    }
}
