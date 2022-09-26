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
    [SerializeField] private int m_PlayerNum;
    private int m_SelectGimmickNum = 0;
    private bool m_IsElection = false;

    /// <summary>
    /// ギミックを設置し終えたか
    /// </summary>
    /// <returns></returns>
    public bool PutedGimmickEnd()
    {
        if (m_SelectGimmickNum == m_PlayerNum) 
        {
            m_SelectGimmickNum = 0;
            m_IsElection = false;
            return true;
        }
        return false;
    }
    public void RecieveGimmick(GimmickBase GB)
    {
        m_GManager.AddPutedGimick(GB);
        m_SelectGimmickNum++;
    }
    /// <summary>
    /// 呼ぶたびにギミックの状態を遷移
    /// </summary>
    public void ChangeGimmicksState(MainState mainState)
    {
        switch(mainState)
        {
            case MainState.SelectGimmickPart:
                m_GManager.ChangeElectionGimmickState();
                break;
            case MainState.PutGimmickPart:
                m_GManager.ChangeElectionGimmickState();
                break;
        }
        m_GManager.HidePutedGimick(mainState);
        m_GManager.ChangePutedGimmickState();
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
