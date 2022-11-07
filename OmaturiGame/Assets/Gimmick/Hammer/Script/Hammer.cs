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
    private bool m_Finish;

    /// <summary>
    /// アニメーションの終わりに呼ぶよ
    /// </summary>
    private void OnFinish()
    {
        m_Finish = true;
        PreparingSelfDestruction();

    }
    public override void OnUpdatePutState()
    {
        switch (m_PutState)
        {
            case GimmickPutState.Select:
                m_PutState = GimmickPutState.Put;
                break;
            case GimmickPutState.Put:
                m_PutState = GimmickPutState.FinishPut;
                HammerAnim.SetBool("Run", true);
                break;
        }
    }
}