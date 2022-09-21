using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScore : MonoBehaviour
{
    [SerializeField] private int m_Coin, m_Kill, m_Goal;
    private PlayerScoreStruct m_Score;
    void Start()
    {
        m_Score.m_CoinScore = m_Coin;
        m_Score.m_GoalScore = m_Goal;
        m_Score.m_PlayerKillScore = m_Kill;
    }

    public PlayerScoreStruct ShowScore()
    {
        return m_Score;
    }
}
