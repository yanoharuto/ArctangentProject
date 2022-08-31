using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// コイン
/// </summary>
public class Coin : GimmickBase
{
    protected override void Run()
    {
        if(m_IsDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
