using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 設置すると他のオブジェクトを破壊するよ
/// </summary>
public class Hammer : GimmickBase
{
    protected override void Run()
    {
        Destroy(this.gameObject);
    }
    protected override void SetUp()
    { 
    }
    protected override void Standby()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (m_GimmickState == GimmickState.Hammer)
        {
            Destroy(collision.gameObject);
        }
    }
}