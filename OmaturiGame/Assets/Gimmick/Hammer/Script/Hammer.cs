using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// hammerのタグが付いたオブジェクトに大きめの当たり判定をつければ
/// その当たり判定に当たったギミックはDestroy
/// こいつも消える
/// </summary>
public class Hammer : GimmickBase
{
    [SerializeField] [Header("この有効範囲に入ったものを壊す")]BoxCollider2D m_TriggerCollider;
    protected override void SetUp()
    {
        m_TriggerCollider.enabled = false;
    }
    protected override void Standby()
    {      
        m_IsDestroy = true;
        m_TriggerCollider.enabled = true;
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
}