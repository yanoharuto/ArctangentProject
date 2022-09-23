﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// これをアタッチしてあるオブジェクトを起点に棒グラフを表示する
/// </summary>
public class ScoreElection : MonoBehaviour
{
    [SerializeField] [Header("スコアゲージ用のマスク")] private GameObject m_ImgMask;
    [SerializeField] [Header("スコアを表示する棒グラフのsprite")] private GameObject m_BarImg;
    [SerializeField] private Transform m_MaskT;
    [SerializeField] private Transform m_BarT;
    [SerializeField] private float m_BarSizeY;
    [SerializeField] [Header("BarImgの表示にかかる時間")] private float m_DisplayTime;
    [SerializeField] [Header("マスクの数")] private int m_MaskNum;
    [SerializeField] [Header("スコアの色の種類")] private List<Color> m_ColorList = new List<Color>();
    private PlayerScoreStruct m_DisplayScore;//表示した分はここに
    private void Start()
    {
        SettingMask();
        SetDisplayScore(0, 0, 0);
    }
    /// <summary>
    /// もう既に表示したスコアは更新
    /// </summary>
    /// <param name="goal"></param>
    /// <param name="coin"></param>
    /// <param name="kill"></param>
    private void SetDisplayScore(float goal,float coin,float kill)
    {
        m_DisplayScore.m_GoalScore = goal;
        m_DisplayScore.m_CoinScore = coin;
        m_DisplayScore.m_PlayerKillScore = kill;
    }

    /// <summary>
    /// Maskを付くる
    /// </summary>
    private void SettingMask()
    {
        
        for (int i = 0; i < m_MaskNum; i++)
        {
            GameObject Img = Instantiate(m_ImgMask);

            Transform ImgT = Img.transform;
            ImgT.position = m_MaskT.position ;
            //親子付けしてキャンバスの下に置く
            ImgT.SetParent(m_MaskT);

        }
    }
    /// <summary>
    /// スコアをスコアの大きさ分長くして表示して色変えます
    /// </summary>
    /// <param name="score">これが大きいほど横長になる</param>
    /// <param name="color"></param>
    private void DisplayScore(float score,Color color)
    {
        GameObject imgObj = Instantiate(m_BarImg);
        imgObj.transform.SetParent(m_BarT);
        imgObj.transform.localScale = new Vector3(score, m_BarSizeY);
        SpriteRenderer image = imgObj.GetComponent<SpriteRenderer>();
        image.color = color;
    }
    /// <summary>
    /// コルーチン　ちょっとずつスコアが出るよ
    /// </summary>
    /// <param name="score"></param>
    /// <returns></returns>
    private IEnumerator DisplayScores(PlayerScoreStruct score)
    {
  
        DisplayScore(score.m_GoalScore, m_ColorList[0]);
        yield return new WaitForSeconds(m_DisplayTime);
        DisplayScore(score.m_CoinScore, m_ColorList[1]);
        yield return new WaitForSeconds(m_DisplayTime);
        DisplayScore(score.m_PlayerKillScore, m_ColorList[2]);
        yield break;
    }
    /// <summary>
    /// スコアを表示
    /// </summary>
    /// <param name="score">構造体ごと投げて</param>
    /// <param name="first">最初の一回だけ教えて</param>
    public void Display(PlayerScoreStruct score,bool first)
    {
        PlayerScoreStruct addDisplayScore = score;
        //二回目からは
        if (!first)
        {
            //すでに描画したものを引く
            addDisplayScore.m_CoinScore -= m_DisplayScore.m_CoinScore;
            addDisplayScore.m_GoalScore -= m_DisplayScore.m_GoalScore;
            addDisplayScore.m_PlayerKillScore -= m_DisplayScore.m_PlayerKillScore;
            SetDisplayScore(score.m_GoalScore, score.m_CoinScore, score.m_PlayerKillScore);
        }
        StartCoroutine("DisplayScores",addDisplayScore);
    }
}
