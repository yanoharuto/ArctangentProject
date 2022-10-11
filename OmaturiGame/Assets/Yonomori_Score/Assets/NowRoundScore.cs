using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1ラウンド毎のスコアを集めた場所
/// </summary>
public class NowRoundScore : MonoBehaviour
{
    private PlayerScoreStruct m_Score;
    private bool m_Die;
    /// <summary>
    /// このラウンド中に獲得したスコアの表示
    /// </summary>
    /// <returns>一回渡したら次のラウンドが来るまで0が返ってくるよ</returns>
    public PlayerScoreStruct GetNowRoundScore()
    { 
        if (m_Die)
        {
            ResetNowRoundScore();
        }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)            //衝突したオブジェクトのタグによってスコアが増えたり減ったり
        {
            case "dangerousObject":
                m_Die = true;
                break;
            case "goal":
                Debug.Log("goal");
                m_Score.m_GoalScore++;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)               //衝突したオブジェクトのタグをcollisionに代入
    {
        switch (collision.tag)            //衝突したオブジェクトのタグによってスコアが増えたり減ったり
        {
            case "coin":
                m_Score.m_CoinScore++;
                break;
        }
    }
}
