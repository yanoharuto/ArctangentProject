using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundUpdater : MonoBehaviour
{
    [SerializeField] [Header("現在のroundの表記してあるテキスト")] private Text m_NowText;
    [SerializeField] [Header("最大のroundの表記してあるテキスト")] private Text m_MaxText;
    [SerializeField] private int m_RoundMax;
    private int m_NowRoundNum = 0;
    private void Start()
    {
        m_MaxText.text = m_RoundMax.ToString();
    }
    /// <summary>
    /// ラウンドの更新
    /// </summary>
    public void OnCountRound()
    {
        m_NowRoundNum++;
        m_NowText.text = m_NowRoundNum.ToString();
    }
    /// <summary>
    /// 最大ラウンドが終了したか
    /// </summary>
    /// <returns></returns>
    public bool IsMainEnd()
    {
        return m_NowRoundNum == m_RoundMax;
    }
}
