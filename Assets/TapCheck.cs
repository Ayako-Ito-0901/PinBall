using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCheck
{
    /*************
    タップされている場所を返すクラス
    **************/
    public bool touchFlg; //タッチ有無
    public Vector2 touchPosition; //タッチ座標
    public TouchPhase touchPhase; //タッチ状態
    public bool touchLeft;
    public bool touchRight;

    /*************
    タップされた座標を確認し、bool型配列をリターンする{右側のタップ, 左側のタップ}
    **************/
    public bool[] GetLrPos() {
    
        this.touchFlg = false;
        this.touchLeft = false;
        this.touchRight = false;

        if (Input.touchCount > 0) {
            for(int i = 0; i <= Input.touchCount-1; i++) {
                Touch touch = Input.GetTouch(i);
                this.touchPosition = touch.position;
                this.touchPhase = touch.phase;
                this.touchFlg = true;                
                Debug.Log("タップ" + i + ":" + touch.position);
                if(this.touchPosition.x >= 350) {
                    this.touchRight = true;
                }
                else {
                    this.touchLeft = true;
                }   
            }
        }
        
        bool[] resultArray = {this.touchRight, this.touchLeft};
        return resultArray;
        //return this.touchRight;
    }
}
