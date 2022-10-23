using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : GimmickBase
{
     private void OnCollisionEnter2D(Collision2D collision)
    {
        m_IsOvarlap = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        m_IsOvarlap = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        TriggerEvenet(collision.gameObject);
    }
}
