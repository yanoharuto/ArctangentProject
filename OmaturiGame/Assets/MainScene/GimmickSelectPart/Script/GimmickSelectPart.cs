using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ギミックを選出する
/// </summary>
public class GimmickSelectPart : MonoBehaviour
{   
    [SerializeField] private GimmickElection m_GElection;
    private GimmickManager m_GManager;
    private int m_SelectGimmickNum = 0;
    private bool m_IsElection = false;


    /// <summary>
    /// 設置するギミックをマネージャーのリストに追加
    /// </summary>
    /// <param name="AddGimmick"></param>
    public void RecieveGimmick(GimmickBase AddGimmick)
    {
        m_SelectGimmickNum++;
        m_GManager.AddGimmick(AddGimmick);
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
    /// プレイヤーが選択するギミックを選出
    /// </summary>
    public void ElectionGimmick()
    {
        if (!m_IsElection)
        {
            m_GElection.Election();
            m_IsElection = true;
        }
    }
    public void InitGimmickManager(GimmickManager _gimmickManager)
    {
        m_GManager = _gimmickManager;
    }
}
