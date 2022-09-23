using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpornProcess : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReSporn()
    {
        //  スタート地点に戻る
        Transform myTransform = this.transform;         //transformを取得

        Vector3 pos = myTransform.position;             //座標を取得
        Debug.Log("ゴール");                    //ゴールと表示
        pos.x = 0f;                                 //x初期位置
        pos.y = -3.6f;                              //y初期位置
        pos.z = 0f;                                  //z初期位置

        myTransform.position = pos;                     //座標を設定
    }
}
