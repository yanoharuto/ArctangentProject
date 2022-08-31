using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 設置後のギミックに仕事をさせるよ
/// </summary>
public class GimmickManager : MonoBehaviour
{
    private List<GimmickBase> m_GimmickBases = new List<GimmickBase>();
    /// <summary>
    /// 呼ぶたびに設置したオブジェクトの状態を遷移
    /// </summary>
    public void ChangeProcess()
    {
        //破壊しないギミックのリスト
        List<GimmickBase> NonDestroyGimmick = new List<GimmickBase>();
        foreach (GimmickBase GB in m_GimmickBases)
        {
            GB.ChangeState();
            if(!GB.IsDestroy())
            {
                //破壊しないギミックを登録
                NonDestroyGimmick.Add(GB);
            }
        }
        //受け渡し。渡されなかったギミックは起動時に破壊される
        m_GimmickBases = NonDestroyGimmick;
    }
 
    public void AddGimmick(GimmickBase gimmickBase)
    {
        m_GimmickBases.Add(gimmickBase);
        //設置後状態にする
        gimmickBase.ChangeState();
    }
}