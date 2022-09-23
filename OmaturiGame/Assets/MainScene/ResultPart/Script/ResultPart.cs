using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultPart : MonoBehaviour
{

    [SerializeField] [Header("ScoreBarを表示するスクリプト")] private ScoreBarManager m_ScoreBarMana;
    [SerializeField] [Header("優勝するために必要なスコア")] private float m_ChampScore;
    [SerializeField] private RoundManager m_RoundManager;


    private void Start()
    {
        Run();
    }

    /// <summary>
    /// 表示始める
    /// </summary>
    public void Run()
    {
        m_RoundManager.CountRound();
        m_ScoreBarMana.StartCoroutine("UpdateScoreBar");
    }
    public bool IsDisplayEnd()
    {
        return m_ScoreBarMana.IsDisplayEnd();
    }
}
