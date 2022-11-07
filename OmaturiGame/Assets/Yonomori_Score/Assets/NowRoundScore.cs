using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1ラウンド毎のスコアを集めた場所
/// </summary>
public class NowRoundScore : MonoBehaviour
{
    private PlayerScoreStruct m_Score;
    [SerializeField] private ScoreScale m_ScoreScale;
    /// <summary>
    /// このラウンド中に獲得したスコアの表示
    /// </summary>
    /// <returns>一回渡したら次のラウンドが来るまで0が返ってくるよ</returns>
    public PlayerScoreStruct GetNowRoundScore()
    {

        if (m_Score.m_Die)
        {
            ResetNowRoundScore();
            m_Score.m_Die = false;
        }
        PlayerScoreStruct score = m_Score;
        ResetNowRoundScore();
        return score;
    }
    public void SetPlaeyerKillScore(bool _OtherPlayerDie)
    {
        if (_OtherPlayerDie)
        {
            m_Score.m_PlayerKillScore = m_ScoreScale.m_PlayerKillScore;
        }
    }
    private void ResetNowRoundScore()
    {
        m_Score.m_PlayerKillScore = 0;
        m_Score.m_GoalScore = 0;
        m_Score.m_CoinScore = 0;
    }
    public bool NowRoundDie()
    {
        return m_Score.m_Die;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)            //衝突したオブジェクトのタグによってスコアが増えたり減ったり
        {
            case "dangerousObj":
                m_Score.m_Die = true;
                break;
            case "goal":
                m_Score.m_GoalScore=m_ScoreScale.m_GoalScore;
                break;
            case "coin":
                m_Score.m_CoinScore=m_ScoreScale.m_CoinScore;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)               //衝突したオブジェクトのタグをcollisionに代入
    {
        switch (collision.tag)            //衝突したオブジェクトのタグによってスコアが増えたり減ったり
        {
            case "coin":
                m_Score.m_CoinScore=m_ScoreScale.m_CoinScore;
                break;
            case "dangerousObj":
                m_Score.m_Die = true;
                break;
            case "goal":
                m_Score.m_GoalScore=m_ScoreScale.m_GoalScore;
                break;
        }
    }
}
