using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAdministrator : MonoBehaviour
{
    public static TitleAdministrator instance;

    Rigidbody2D rigit=new Rigidbody2D();
    [SerializeField]float force=10.0f;
    public bool titleButtonTrriger;
    GameObject titleBox;

    private void Start()
    {
        rigit = GetComponent<Rigidbody2D>();
        titleButtonTrriger = false;
        titleBox = GameObject.Find("TitleBox");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigit.AddForce(transform.right * force);
        }
        if(this.transform.position.x<-20.0f)
        {
            SetTriggerTrue();
            //Debug.Log("Exit");
        }
        //Debug.Log(titleButtonTrriger);
    }

    public void SetTriggerTrue()
    {
        titleButtonTrriger = true;
    }
}
