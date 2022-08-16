using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : GimmickBase
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player") 
        {
            
        }
    }
}
