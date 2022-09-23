using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイヤー１人１人のスコアを記録する
/// </summary>
public class PlayerScore : MonoBehaviour
{
    [SerializeField] [Header("Debug用")] private float m_Coin, m_Kill, m_Goal;
    [SerializeField] private ScoreElection m_ScoreElection;
    PlayerScoreStruct m_ScoreStruct;
    private void Awake()
    {
        m_ScoreStruct.m_CoinScore = m_Coin;
        m_ScoreStruct.m_GoalScore = m_Goal;
        m_ScoreStruct.m_PlayerKillScore = m_Kill;
    }
    /// <summary>
    /// このスクリプトが持っているスコアを表示
    /// </summary>
    public void ElectionScore(bool first)
    {
        m_ScoreElection.Display(m_ScoreStruct,first);
    }
    /// <summary>
    /// プレイヤーのスコアを見せる
    /// </summary>
    public PlayerScoreStruct GetPlayerScore()
    {
        return m_ScoreStruct;
    }
    /// <summary>
    /// スコアの合計値を出す
    /// </summary>
    /// <returns></returns>
    public float GetTotalScore()
    {
        return m_ScoreStruct.m_CoinScore + m_ScoreStruct.m_GoalScore + m_ScoreStruct.m_PlayerKillScore;
    }
}
