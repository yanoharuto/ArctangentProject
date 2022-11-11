using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAdministrator : MonoBehaviour
{
    public static TitleAdministrator instance;

    [SerializeField] Rigidbody2D rigit;
    [SerializeField] float force;
    public bool titleButtonTrriger;

    private void Start()
    {
        Debug.Log(rigit);
        titleButtonTrriger = false;
    }
    private void Update()
    {
        if(Input.GetButtonDown("A1") || Input.GetKeyDown(KeyCode.Space))
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
