using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    [SerializeField] GameObject effectObject;
    [SerializeField] Transform target;
    [SerializeField] string tagname;
    private bool touchFlag = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag(tagname) && touchFlag == false)                                    //触ったオブジェクトのタグを取得
        {
            GameObject instance = Instantiate(effectObject, this.transform.position, Quaternion.identity);

            instance.transform.position = target.position;                              //ターゲットの位置にエフェクトを出す

            touchFlag = true;           //触ったふらぐをたてる
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag(tagname) && touchFlag == false)                                    //触ったオブジェクトのタグを取得
        {
            GameObject instance = Instantiate(effectObject, this.transform.position, Quaternion.identity);

            instance.transform.position = target.position;                              //ターゲットの位置にエフェクトを出す

            touchFlag = true;           //触ったふらぐをたてる
        }
    }
}
