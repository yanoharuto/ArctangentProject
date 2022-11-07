using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAdministrator : MonoBehaviour
{
    public static TitleAdministrator instance;

    [SerializeField] Rigidbody2D rigit;
    [SerializeField] float force;
    public bool titleButtonTrriger;
    GameObject titleBox;

    private void Start()
    {
        Debug.Log(rigit);
        titleButtonTrriger = false;
        titleBox = GameObject.Find("TitleBox");
    }
    private void Update()
    {
        if(Input.GetButtonDown("A1"))
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
