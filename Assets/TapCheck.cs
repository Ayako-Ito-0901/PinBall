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
    public int touchLeft;
    public int touchRight;

    /*************
    タップされた座標を確認し、bool型配列をリターンする{右側のタップ, 左側のタップ}
    **************/
    public int[] GetLrPos() {
    
        this.touchFlg = false;
        this.touchLeft = 0;
        this.touchRight = 0;

        if (Input.touchCount > 0) {
            for(int i = 0; i <= Input.touchCount-1; i++) {
                Touch touch = Input.GetTouch(i);

                if(touch.position.x >= Screen.width/2) { //端末の横幅を求めるscreenクラス
                    if(touch.phase == TouchPhase.Began) {
                        //右フリッパーを動かす
                    }
                    if(touch.phase == TouchPhase.Ended) {
                        //右フリッパーを話す
                    }
                }
                else {
                        //同じ
                }

                this.touchPosition = touch.position;
                this.touchPhase = touch.phase;
                this.touchFlg = true;                
                Debug.Log("タップ" + i + ":" + touch.position);
                if(this.touchPosition.x >= 350) {
                    if(this.touchPhase == TouchPhase.Began) { //タッチ開始
                        this.touchRight = 1;
                    }
                    if(this.touchPhase == TouchPhase.Ended) { //タッチ終了
                        this.touchRight = 2;
                    }
                }
                else {
                    if(this.touchPhase == TouchPhase.Began) { //タッチ開始
                        this.touchLeft = 1;
                    }
                    if(this.touchPhase == TouchPhase.Ended) { //タッチ終了
                        this.touchLeft = 2;
                    }
                }   
            }
        }
        
        int[] resultArray = {this.touchRight, this.touchLeft};
        return resultArray;
        //return this.touchRight;
    }
}
