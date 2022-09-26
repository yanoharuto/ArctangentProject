using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1ラウンド毎のスコアを集めた場所
/// </summary>
public class NowRoundScore : MonoBehaviour
{
    private PlayerScoreStruct m_Score;
    [SerializeField] [Header("Debug用、本番時は0")] private float m_Coin, m_Kill, m_Goal;
    private void Awake()
    {
        m_Score.m_CoinScore = m_Coin;
        m_Score.m_GoalScore = m_Goal;
        m_Score.m_PlayerKillScore = m_Kill;
    }
    /// <summary>
    /// このラウンド中に獲得したスコアの表示
    /// </summary>
    /// <returns>一回渡したら次のラウンドが来るまで0が返ってくるよ</returns>
    public PlayerScoreStruct GetNowRoundScore()
    {
        PlayerScoreStruct score = m_Score;
        ResetNowRoundScore();
        return score;
    }
    private void ResetNowRoundScore()
    {
        m_Score.m_PlayerKillScore = 0;
        m_Score.m_GoalScore = 0;
        m_Score.m_CoinScore = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)               //衝突したオブジェクトのタグをcollisionに代入
    {
        switch (collision.tag)            //衝突したオブジェクトのタグによってスコアが増えたり減ったり
        {
            case "coin":
            m_Score.m_CoinScore++;
                break;
            case "dangerousObject":
                ResetNowRoundScore();
                break;
            case "goal":
                m_Score.m_GoalScore++;
                break;
        }
    }
}
