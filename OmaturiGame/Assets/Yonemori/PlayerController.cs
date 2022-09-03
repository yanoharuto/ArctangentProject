using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Ten;
    private int One;
    [SerializeField]  [Header("スコア")]private int Score;
    void Start()
    {

    }
    
    void Update()
    {
        // 左矢印が押された時
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-2, 0, 0); // 左に「3」動かす
        }

        // 右矢印が押された時
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(2, 0, 0); // 右に「3」動かす
        }
    }

    void OnTriggerEnter2D(Collider2D collision)               //衝突したオブジェクトのタグをcollisionに代入
    {
        Debug.Log(collision.gameObject.name);              //衝突したオブジェクトの名前を表示

        if (collision.CompareTag("coin"))            //衝突したオブジェクトのタグがcoinなら
        {
            Debug.Log("ゲット");                       //ゲットと表示
            Destroy(collision.gameObject);          //衝突したコインを消す
        }

        if (collision.CompareTag("flag"))                             //衝突したオブジェクトのタグがflagなら
        {
            Transform myTransform = this.transform;         //transformを取得

            Vector3 pos = myTransform.position;             //座標を取得
            Debug.Log("ゴール");                    //ゴールと表示
            pos.x = 0f;                                 //x初期位置
            pos.y = -3.6f;                              //y初期位置
            pos.z = 0f;                                  //z初期位置

            myTransform.position = pos;                     //座標を設定
        }
    }
}
