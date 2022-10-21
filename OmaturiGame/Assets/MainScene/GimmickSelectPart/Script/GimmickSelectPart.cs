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
    private GimmickManager m_GManger;
    private int m_PlayerNum;
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
    /// <summary>
    /// ギミックを設置したなら渡してください
    /// </summary>
    /// <param name="_GB"></param>
    public void OnRecieveGimmick(GimmickBase _GB)
    {
        m_SelectGimmickNum++;
        m_GManger.AddPutedGimick(_GB);
    }

    /// <summary>
    /// プレイヤーが選択するギミックを選出して実体化
    /// </summary>
    public void ElectionGimmick(bool _FirstRound)
    {
        if (!m_IsElection)
        {
            m_GElection.Election(_FirstRound);
            m_IsElection = true;
        }
    }
    /// <summary>
    /// プレイヤーの数を教えてください
    /// </summary>
    /// <param name="_PlayerNum"></param>
    public void OnFirstInit(int _PlayerNum,GimmickManager _GimmickManager)
    {
        m_PlayerNum = _PlayerNum;
        m_GElection.OnSetGimmickManager(_GimmickManager);
        m_GManger = _GimmickManager;
        
    }
}
