using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultPart : MonoBehaviour
{

    [SerializeField] [Header("ScoreBarを表示するスクリプト")] private ScoreBarManager m_ScoreBarMana;
    [SerializeField] [Header("優勝するために必要なスコア")] private float m_ChampScore;
    [SerializeField] private RoundTextUpdater m_RoundTextUpdater;
    [SerializeField] private GameObject m_ScoreBord;
    private void Start()
    {
        m_ScoreBord.SetActive(false);
    }

    /// <summary>
    /// 表示始める
    /// </summary>
    public void Run()
    {
        m_ScoreBord.SetActive(true);
        m_RoundTextUpdater.CountRound();
        m_ScoreBarMana.StartCoroutine("UpdateScoreBar");
    }
    public bool IsDisplayEnd()
    {
        m_ScoreBord.SetActive(false);
        return m_ScoreBarMana.IsDisplayEnd();
    }
}
