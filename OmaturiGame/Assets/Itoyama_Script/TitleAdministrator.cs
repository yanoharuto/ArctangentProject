using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAdministrator : MonoBehaviour
{
    Rigidbody2D rigit=new Rigidbody2D();
    [SerializeField]float force=10.0f;

    private void Start()
    {
        rigit = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigit.AddForce(transform.right * force);
        }
    }
}
