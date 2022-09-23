using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]  [Header("コインスコア")]private int CoinScore;
    [SerializeField][Header("ゴールスコア")] private int GoalScore;
    [SerializeField][Header("ゴールスコア")] private int DieScore;

    public int Point = 0;
 
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

    public void ResetScore()
    {
        Point = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)               //衝突したオブジェクトのタグをcollisionに代入
    {
        Debug.Log(collision.gameObject.name);              //衝突したオブジェクトの名前を表示

        if (collision.CompareTag("coin"))            //衝突したオブジェクトのタグがcoinなら
        {
            Point += CoinScore;
            Debug.Log("ゲット");                       //ゲットと表示
            Debug.Log(Point);
            Destroy(collision.gameObject);          //衝突したコインを消す
        }

        if (collision.CompareTag("object"))            //衝突したオブジェクトのタグがobjectなら
        {
            Point -= DieScore;
            Debug.Log("死亡");                       //ゲットと表示
            Debug.Log(Point);
        }

        if (collision.CompareTag("Re"))            //衝突したオブジェクトのタグがobjectなら
        {
            Point -= DieScore;
            Debug.Log("死亡");                       //ゲットと表示
            Debug.Log(Point);
        }
    }
}
