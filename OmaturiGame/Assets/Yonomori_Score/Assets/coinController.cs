using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)               //衝突したオブジェクトのタグをcollisionに代入
    {
        Debug.Log(collision.gameObject.name);              //衝突したオブジェクトの名前を表示

        if (collision.CompareTag("coin"))            //衝突したオブジェクトのタグがcoinなら
        {
            Debug.Log("ゲット");                       //ゲットと表示
            Destroy(collision.gameObject);          //衝突したコインを消す
        }




    }
}