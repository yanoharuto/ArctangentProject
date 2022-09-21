using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultPart : MonoBehaviour
{
    [SerializeField] [Header("1pのスコア")] private TestScore m_PlayerScore1;
    [SerializeField] [Header("2pのスコア")] private TestScore m_PlayerScore2;
    [SerializeField] [Header("優勝するために必要なスコア")] private int m_FinalsScore;
    [SerializeField] [Header("スコアを表示する棒グラフの画像")] private GameObject m_BarGraph;
    [SerializeField] [Header("このオブジェクトを起点にUIを表示する")] private GameObject m_P1BarGraphObj;
    [SerializeField]  private GameObject m_P2BarGraphObj;
    [SerializeField] [Header("スコアの色の種類")] private List<Color> ColorList = new List<Color>();
    [SerializeField] [Header("スコアの表示にかかる時間")] private float m_ElectionTime;
    private bool m_IsEnd;//リザルトを表示し終えたかどうか
    private bool m_IsFinals;//優勝フラグ
    //スコアを表示するためのスクリプト
    private ScoreElection m_P1ScoreElection;
    private ScoreElection m_P2ScoreElection;
    /// <summary>
    /// コルーチン　表示時間が経過するたび新しいスコアを表示する
    /// </summary>
    /// <returns></returns>
    private IEnumerator ElectionScore()
    {
        for (int i = 0; i < 3; i++)
        {
            ShowScore(i);
            yield return new WaitForSeconds(m_ElectionTime);
        }
        m_IsEnd = true;
        yield break;
    }
    /// <summary>
    /// スコアを実体化させる
    /// </summary>
    /// <param name="i"></param>
    private void ShowScore(int i)
    {
        switch(i)
        {
            case 0:
                m_P1ScoreElection.InstantiateBarGraph(m_BarGraph, m_PlayerScore1.ShowScore().m_GoalScore, ColorList[i]);
                m_P2ScoreElection.InstantiateBarGraph(m_BarGraph, m_PlayerScore1.ShowScore().m_GoalScore, ColorList[i]);
                break;
            case 1:
                m_P1ScoreElection.InstantiateBarGraph(m_BarGraph, m_PlayerScore1.ShowScore().m_CoinScore, ColorList[i]);
                m_P2ScoreElection.InstantiateBarGraph(m_BarGraph, m_PlayerScore1.ShowScore().m_CoinScore, ColorList[i]);
                break;
            case 2:
                m_P1ScoreElection.InstantiateBarGraph(m_BarGraph, m_PlayerScore1.ShowScore().m_PlayerKillScore, ColorList[i]);
                m_P2ScoreElection.InstantiateBarGraph(m_BarGraph, m_PlayerScore1.ShowScore().m_PlayerKillScore, ColorList[i]);
                break;
        }
    }
    /// <summary>
    /// プレイヤーのスコアを足し合わせて優勝したかどうか判定するよ
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    private bool IsFinalisedPlayer(TestScore player)
    {
        PlayerScoreStruct score = player.ShowScore();
        int totalScore = score.m_CoinScore + score.m_GoalScore + score.m_PlayerKillScore;
        return m_FinalsScore < totalScore;
    }
    private void Start()
    {
        m_P1ScoreElection = m_P1BarGraphObj.AddComponent<ScoreElection>();
        m_P2ScoreElection = m_P2BarGraphObj.AddComponent<ScoreElection>();
        Run();
    }    
    /// <summary>
    /// スコアを表示　コルーチン起動
    /// </summary>
    public void Run()
    {
        StartCoroutine("ElectionScore");
        if (IsFinalisedPlayer(m_PlayerScore1))
        {
            m_IsFinals = true;
        }
        if(IsFinalisedPlayer(m_PlayerScore2))
        {
            m_IsFinals = true;
        }
    }
    /// <summary>
    /// 優勝したかどうかのフラグを返す
    /// </summary>
    /// <returns></returns>
    public bool IsFinals()
    {
        return m_IsFinals;
    }
    /// <summary>
    /// UIを表示し終えたかどうかを返す
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        return m_IsEnd;
    }
}
