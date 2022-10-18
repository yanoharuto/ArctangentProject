using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clserSystem : MonoBehaviour
{

    Animator animator;
    bool clearFlag;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("clearFlag", clearFlag);
    }

    void OnTriggerEnter2D(Collider2D collision)               //衝突したオブジェクトのタグをcollisionに代入
    {
        Debug.Log(collision.gameObject.name);              //衝突したオブジェクトの名前を表示

        if (collision.CompareTag("goal"))            //衝突したオブジェクトのタグがdangerousObjなら
        {
            Debug.Log("クリア");

            clearFlag = true;
        }
    }
}
