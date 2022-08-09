using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 足場クラス
/// </summary>
public class Scaffold : GimmickBase
{
    private void OnCollisionEnter(Collision collision)
    {
        DestroyByHummer(collision.transform.tag);
    }

    protected override void SetUp()
    {
    }
    protected override void Standby()
    {
    }
    protected override void Run()
    {

    }
}
