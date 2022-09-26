using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 足場クラス
/// </summary>
public class Scaffold : GimmickBase
{
    protected override void SetUp()
    {
    }
    protected override void Standby()
    {
        if (!m_IsPut)
        {
            Destroy(this.gameObject);
        }
    }
    protected override void Run()
    {
        if (m_IsDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
