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

    //タップで追加
    TapCheck tapCheck;

    // Start is called before the first frame update
    void Start()
    {

        //HingeJoinコンポーネント取得フリッパーを動かすためには、フリッパーにアタッチしているHinge Jointをスクリプトから操作するため
        //「GetComponent」関数は、ゲームオブジェクトにアタッチしているコンポーネントを取得します。何のコンポーネントを取得するかは、GetComponentに続く「<>」内で指定
        this.myHingeJoint = GetComponent<HingeJoint>();
        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

        //タップで追加
        this.tapCheck = new TapCheck();
        
    }

    // Update is called once per frame
    void Update()
    {
        //タップで追加
        bool[] resultArray = tapCheck.GetLrPos();

        if(tag == "RightFripperTag") {
            if(Input.GetKeyDown(KeyCode.RightArrow) || resultArray[0] == true) {
                SetAngle(this.flickAngle);
            }
            else {
                SetAngle(this.defaultAngle);
            }
        }

        if(tag == "LeftFripperTag") {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || resultArray[1] == true) {
                SetAngle(this.flickAngle);
            }
            else {
                SetAngle(this.defaultAngle);
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
