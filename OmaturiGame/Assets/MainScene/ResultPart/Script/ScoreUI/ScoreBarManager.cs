﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBarManager : MonoBehaviour
{
    [SerializeField] [Header("1pのスコア")] private PlayerScore m_PlayerScore1;
    [SerializeField] [Header("2pのスコア")] private PlayerScore m_PlayerScore2;
    [SerializeField] [Header("1pのスコアグラフ")] private ScoreBar m_ScoreBar1;
    [SerializeField] [Header("2pのスコアグラフ")] private ScoreBar m_ScoreBar2;
    [SerializeField] [Header("スコアを表示するときに鳴る音4つめはスコアが0のときに鳴る")] private List<AudioClip> m_AudioList = new List<AudioClip>();
    [SerializeField] private float m_DisplayTime;
    private AudioSource m_Audio;// 音が複数なると危険なのでここに実装
    private const int m_ScoreKind = 3;
    private bool m_IsDisplayEnd = false;
    private void Start()
    {
        m_Audio = gameObject.GetComponent<AudioSource>();
    }
    /// <summary>
    /// 音を鳴らして表示
    /// </summary>
    /// <param name="score1"></param>
    /// <param name="score2"></param>
    /// <param name="scoreKind"></param>
    /// <param name="SE"></param>
    private void DisplayScore(float score1,float score2,int scoreKind,AudioClip SE)
    {
        m_ScoreBar1.DisplayScore(score1, scoreKind);
        m_ScoreBar2.DisplayScore(score2, scoreKind);
        m_Audio.PlayOneShot(SE);
    }
    /// <summary>
    /// スコアバーを表示させる
    /// </summary>
    /// <returns></returns>
    IEnumerator UpdateScoreBar()
    {
        m_IsDisplayEnd = false;
        PlayerScoreStruct p1Struct = m_PlayerScore1.GetNowRoundScore();
        PlayerScoreStruct p2Struct = m_PlayerScore2.GetNowRoundScore();
        if(m_PlayerScore1.GetTotalScore()<=0.1|| m_PlayerScore2.GetTotalScore() <= 0.1)
        {
            m_Audio.PlayOneShot(m_AudioList[3]);
        }
            yield return new WaitForSeconds(m_DisplayTime);
        for (int i = 0; i < m_ScoreKind; i++)
        {
            switch (i)
            {
                case 0:
                    DisplayScore(p1Struct.m_GoalScore,p2Struct.m_GoalScore, i,m_AudioList[i]);
                    
                    break;
                case 1:
                    DisplayScore(p1Struct.m_CoinScore,p2Struct.m_CoinScore, i, m_AudioList[i]);
                    break;
                case 2:
                    DisplayScore(p1Struct.m_PlayerKillScore,p2Struct.m_PlayerKillScore, i, m_AudioList[i]);
                    break;
            }
            yield return new WaitForSeconds(m_DisplayTime);
        }

        m_IsDisplayEnd = true;
        yield break;
    }
    /// <summary>
    /// 表示し終えたかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsDisplayEnd()
    {
        return m_IsDisplayEnd;
    }
}