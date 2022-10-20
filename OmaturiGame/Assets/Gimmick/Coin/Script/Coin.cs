using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// コイン
/// </summary>
public class Coin : GimmickBase
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

        if (collision.gameObject.CompareTag("player"))
        {
            PreparingSelfDestruction();
        }
        TriggerEvenet(collision.gameObject);
    }
}
