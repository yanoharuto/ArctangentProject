using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイヤー１人１人のスコアを記録する
/// </summary>
public class PlayerScore : MonoBehaviour
{
   [SerializeField] NowRoundPlayerScore m_ScoreStocker;
    PlayerScoreStruct m_ScoreStruct;

    /// <summary>
    /// プレイヤーのスコアを見せる
    /// </summary>
    public PlayerScoreStruct GetNowRoundScore()
    {
        PlayerScoreStruct getNowRoundScore = m_ScoreStocker.GetNowRoundScore();
        m_ScoreStruct.m_GoalScore += getNowRoundScore.m_GoalScore;
        m_ScoreStruct.m_PlayerKillScore += getNowRoundScore.m_PlayerKillScore;
        m_ScoreStruct.m_CoinScore += getNowRoundScore.m_CoinScore;
        return getNowRoundScore;
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
