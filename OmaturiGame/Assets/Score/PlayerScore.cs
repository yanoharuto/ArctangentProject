using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイヤー１人１人のスコアを記録する
/// </summary>
public class PlayerScore : MonoBehaviour
{
    PlayerScoreStruct m_ScoreStruct;
    /// <summary>
    /// プレイヤーのスコアを見せる
    /// </summary>
    public PlayerScoreStruct ShowScore()
    {
        return m_ScoreStruct;
    }
    /// <summary>
    /// 相手のプレイヤーを殺したときのスコアを加算
    /// </summary>
    /// <param name="addScore"></param>
    public void AddPlayerKillScore(int addScore)
    {
        m_ScoreStruct.m_PlayerKillScore += addScore;
    }
    /// <summary>
    /// ゴールした時のスコアを加算
    /// </summary>
    /// <param name="addScore"></param>
    public void AddGorlScore(int addScore)
    {
        m_ScoreStruct.m_GoalScore += addScore;
    }
    /// <summary>
    /// コインを所得したときのスコアを加算
    /// </summary>
    /// <param name="addScore"></param>
    public void AddCoinScore(int addScore)
    {
        m_ScoreStruct.m_CoinScore += addScore;
    }
}
