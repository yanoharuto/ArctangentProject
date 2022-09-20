using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPart : MonoBehaviour
{
    [SerializeField] [Header("1pのスコア")] private PlayerScore m_PlayerScore1;
    [SerializeField] [Header("2pのスコア")] private PlayerScore m_PlayerScore2;
    [SerializeField] [Header("優勝するために必要なスコア")] private int m_FinalsScore;
    private bool m_IsFinals;//優勝フラグ
    /// <summary>
    /// アクションシーンが終わった後にプレイヤーのスコアを見せる
    /// </summary>
    public void ShowScore()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        return m_IsFinals;
    }
}
