using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// コイン
/// </summary>
public class Coin : GimmickBase
{
    protected override void Standby()
    {
        if (!m_IsPut)
        {
            Destroy(this.gameObject);
        }
    }
    protected override void Run()
    {
        if(m_IsDestroy)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("player"))
        {

            StartCoroutine("DestroyForPlayer");
        }
    }
}
