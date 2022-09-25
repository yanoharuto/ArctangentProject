using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ギミックを選出する
/// </summary>
public class GimmickSelectPart : MonoBehaviour
{   
    //ポジション
    [SerializeField] private GimmickElection m_GElection;
    [SerializeField] private GimmickManager m_GManager;
    private int m_SelectGimmickNum = 0;
    private bool m_IsElection = false;
    /// <summary>
    /// 設置するギミックをマネージャーのリストに追加
    /// </summary>
    /// <param name="addGimmick"></param>
    public void RecieveGimmick(GimmickBase addGimmick)
    {
        m_SelectGimmickNum++;
        m_GManager.SearchPutGimmick(addGimmick);
    }
    /// <summary>
    /// ギミックを二つ設置したかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsSelectGimmickEnd()
    {
        if (m_SelectGimmickNum == 2)
        {
            m_SelectGimmickNum = 0;
            m_IsElection = false;
            return true;
        }
        return false;
    }
    /// <summary>
    /// 呼ぶたびにギミックの状態を遷移
    /// </summary>
    public void ChangeGimmicksState()
    {
        m_GManager.ChangeProcess();
    }
    /// <summary>
    /// プレイヤーが選択するギミックを選出して実体化
    /// </summary>
    public void ElectionGimmick()
    {
        if (!m_IsElection)
        {
            m_GElection.Election();
            m_IsElection = true;
        }
    }

}
