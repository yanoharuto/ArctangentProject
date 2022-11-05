using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    [SerializeField] GameObject effectObject;
    [SerializeField] Transform effectPos;
    [SerializeField] string tagname;
    
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

        if (collision.gameObject.CompareTag(tagname))                                    //触ったオブジェクトのタグを取得
        {
            GameObject instance = Instantiate(effectObject, this.transform.position, Quaternion.identity);

            instance.transform.position = effectPos.position;                              //ターゲットの位置にエフェクトを出す
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(tagname))                                    //触ったオブジェクトのタグを取得
        {
            GameObject instance = Instantiate(effectObject, this.transform.position, Quaternion.identity);

            instance.transform.position = effectPos.position;                              //ターゲットの位置にエフェクトを出す
        }
    }
}
