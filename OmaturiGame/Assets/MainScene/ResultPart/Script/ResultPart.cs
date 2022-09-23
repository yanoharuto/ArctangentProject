using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultPart : MonoBehaviour
{
    [SerializeField] [Header("1pのスコア")] private PlayerScore m_PlayerScore1;
    [SerializeField] [Header("2pのスコア")] private PlayerScore m_PlayerScore2;
    [SerializeField] [Header("優勝するために必要なスコア")] private float m_ChampScore;
    private bool m_IsEnd;//リザルトを表示し終えたかどうか
    private bool m_IsFinals;//優勝フラグ
    private void Start()
    {
        Run(0);
    }
    /// <summary>
    /// プレイヤーのスコアを足し合わせて優勝したかどうか判定するよ
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    private bool IsFinalisedPlayer(PlayerScore player)
    {
        float totalScore = player.GetTotalScore();
        return m_ChampScore < totalScore;
    }    
    /// <summary>
    /// スコアを表示
    /// </summary>
    public void Run(int roundNum)
    {
        m_PlayerScore1.ElectionScore(roundNum == 1) ;
        m_PlayerScore2.ElectionScore(roundNum == 1);
        if (IsFinalisedPlayer(m_PlayerScore1))
        {
            m_IsFinals = true;
        }
        if(IsFinalisedPlayer(m_PlayerScore2))
        {
            m_IsFinals = true;
        }
    }
    /// <summary>
    /// 優勝したかどうかのフラグを返す
    /// </summary>
    /// <returns></returns>
    public bool IsFinals()
    {
        return m_IsFinals;
    }
    /// <summary>
    /// UIを表示し終えたかどうかを返す
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        return m_IsEnd;
    }
}
