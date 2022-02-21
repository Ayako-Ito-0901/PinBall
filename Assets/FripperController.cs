using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の動き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {

        //HingeJoinコンポーネント取得フリッパーを動かすためには、フリッパーにアタッチしているHinge Jointをスクリプトから操作するため
        //「GetComponent」関数は、ゲームオブジェクトにアタッチしているコンポーネントを取得します。何のコンポーネントを取得するかは、GetComponentに続く「<>」内で指定
        this.myHingeJoint = GetComponent<HingeJoint>();
        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
        
    }

    // Update is called once per frame
    void Update()
    {
        //左矢印キーを押した時左フリッパーを動かす
        //「Input.GetKeyDown」は引数のキーが押された時にtrueを返す
        if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            SetAngle(this.flickAngle);
        }

        //右矢印キーを押した時右フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
            SetAngle(this.flickAngle);
        }

        //矢印キーが離された時フリッパーを元に戻す
        //「Input.GetKeyUp」は引数のキーが離された時にtrueを返す
        //「Input.GetKey」は引数のキーが押されている間、常にtrueを返
        if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            SetAngle(this.defaultAngle);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
            SetAngle(this.defaultAngle);
        }

        //タップされた場合の処理
        if (Input.touchCount > 0) {
            for(int i = 0; i <= Input.touchCount-1; i++) {
                Touch touch = Input.GetTouch(i);
                if(touch.position.x >= Screen.width/2) { //端末の横幅を求めるscreenクラス
                    if(touch.phase == TouchPhase.Began && tag == "RightFripperTag") {
                        SetAngle(this.flickAngle);
                    }
                    if(touch.phase == TouchPhase.Ended && tag == "RightFripperTag") {
                        SetAngle(this.defaultAngle);
                    }
                }
                else {
                    if(touch.phase == TouchPhase.Began && tag == "LeftFripperTag") {
                        SetAngle(this.flickAngle);
                    }
                    if(touch.phase == TouchPhase.Ended && tag == "LeftFripperTag") {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }

    }

    //フリッパーの傾きを設定 JointSpringクラスを使ってバネが戻ろうとする位置をangle引数で設定
    public void SetAngle(float angle) {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

}
