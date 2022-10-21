﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultPart : MonoBehaviour
{

    [SerializeField] [Header("ScoreBarを表示するスクリプト")] private ScoreBarDisplayer m_ScoreBarMana;
    [SerializeField] [Header("優勝するために必要なスコア")] private float m_ChampScore;
    [SerializeField] private ScoreTotaling m_ScoreTotaling;
    [SerializeField] private InputPlyer1 m_Player1Controller;
    [SerializeField] private GameObject m_ScoreBord;
    [SerializeField] private GoNextScene m_GoNextScene1;
    [SerializeField] private GoNextScene m_GoNextScene2;
    private bool m_IsResultFirst = false;
    private void Start()
    {
        m_ScoreBord.SetActive(false);
    }

    /// <summary>
    /// 表示始める
    /// </summary>
    public void Run()
    {
        if (!m_IsResultFirst)
        {
            m_IsResultFirst = true;
            m_ScoreBord.SetActive(true);
            m_ScoreBarMana.StartCoroutine("UpdateScoreBar");
        }
    }
    /// <summary>
    /// スコアの表示が終えたか
    /// </summary>
    /// <returns></returns>
    public bool IsDisplayEnd()
    {
        if (m_ScoreBarMana.IsDisplayEnd())
        {
            m_IsResultFirst = false;
            m_ScoreBord.SetActive(false);
            return true;
        }
        return false;
    }
    /// <summary>
    /// どっちが勝ちましたか
    /// </summary>
    /// <returns></returns>
    public bool GetWin()
    {
        return m_ScoreTotaling.GetIsExistWinner(m_ChampScore);
    }
    /// <summary>
    /// 勝った方のリザルト画面に行く
    /// </summary>
    public void OnNextSceneChange()
    {
        if(m_ScoreTotaling.GetIs1PWin())
        {
            m_GoNextScene1.OnRun();
        }
        else
        {
            m_GoNextScene2.OnRun();
        }
    }
}
