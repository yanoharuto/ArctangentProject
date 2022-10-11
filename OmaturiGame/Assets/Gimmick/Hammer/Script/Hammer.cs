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
    [SerializeField] Animator HammerAnim;
    protected override void PlayUpdate()
    {
        HammerAnim.SetBool("Run",true);
    }  
    /// <summary>
    /// アニメーションの終わりに呼ぶよ
    /// </summary>
    private void Finish()
    {
        m_IsDestroy = true;
        m_Collider.enabled = true;
        m_Collider.enabled = false;
        PreparingSelfDestruction();
    }
}