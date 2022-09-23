using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowRoundPlayerScore : MonoBehaviour
{
    private PlayerScoreStruct m_Score;
    [SerializeField] [Header("Debug用")] private float m_Coin, m_Kill, m_Goal;
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
        Debug.Log(collision.gameObject.name);              //衝突したオブジェクトの名前を表示

        if (collision.CompareTag("coin"))            //衝突したオブジェクトのタグがcoinなら
        {
            m_Score.m_CoinScore++;
        }

        if (collision.CompareTag("dangerousObject"))            //衝突したオブジェクトのタグがobjectなら
        {
            ResetNowRoundScore();
        }

        if (collision.CompareTag("goal"))            //衝突したオブジェクトのタグがobjectなら
        {
            m_Score.m_GoalScore++;
        }
    }
}
