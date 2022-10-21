using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTotaling : MonoBehaviour
{
    [SerializeField] [Header("1pのスコア")] private PlayerScore m_PlayerScore1;
    [SerializeField] [Header("2pのスコア")] private PlayerScore m_PlayerScore2;
    [SerializeField] [Header("ゴールスコアの倍率")] private float m_GoalScoreCoefficient;
    [SerializeField] [Header("コインスコアの倍率")] private float m_CoinScoreCoefficient;
    [SerializeField] [Header("プレイヤーキルスコアの倍率")] private float m_PlayerKillScoreCoefficient;
    PlayerScoreStruct p1Struct;
    PlayerScoreStruct p2Struct;
    /// <summary>
    /// 係数かけてスコアを増やす
    /// </summary>
    /// <param name="_PlayerScore"></param>
    private void UpdateScoreProcess(PlayerScoreStruct _PlayerScore)
    {
        _PlayerScore.m_GoalScore *= m_GoalScoreCoefficient;
        _PlayerScore.m_CoinScore *= m_CoinScoreCoefficient;
        _PlayerScore.m_PlayerKillScore *= m_PlayerKillScoreCoefficient;
    }
    /// <summary>
    /// 1pの現ラウンドのスコアをゲット
    /// </summary>
    /// <returns></returns>
    public PlayerScoreStruct GetScoreP1()
    {
        return p1Struct;
    }
    /// <summary>
    /// 2pの現ラウンドのスコアをゲット
    /// </summary>
    /// <returns></returns>
    public PlayerScoreStruct GetScoreP2()
    {
        return p2Struct;
    }
    /// <summary>
    /// スコアの更新
    /// </summary>
    public void UpdatePlayerScore()
    {
        p1Struct = m_PlayerScore1.GetNowRoundScore();
        p2Struct = m_PlayerScore2.GetNowRoundScore();
        if (!p1Struct.m_Die && p2Struct.m_Die) 
        {
            p1Struct.m_PlayerKillScore++;
        }
        if (p1Struct.m_Die && !p2Struct.m_Die)
        {
            p2Struct.m_PlayerKillScore++;
        }
        UpdateScoreProcess(p1Struct);
        UpdateScoreProcess(p2Struct);
    }
    /// <summary>
    /// ゲームを終わらせた人がいるか
    /// </summary>
    /// <param name="champScore"></param>
    /// <returns></returns>
    public bool GetIsExistWinner(float champScore)
    {
        if (m_PlayerScore1.GetTotalScore() > champScore)
        {
            return true;
        }
        //以下、後で変える必要あり
        else if (0 > champScore)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// 1pは2pよりスコアが多いか？
    /// </summary>
    /// <returns></returns>
    public bool GetIs1PWin()
    {
        if(m_PlayerScore1.GetTotalScore()>m_PlayerScore2.GetTotalScore())
        {
            return true;
        }
        return false;
    }
}
