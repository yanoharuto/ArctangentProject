using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundManager : MonoBehaviour
{
    [SerializeField] [Header("現在のroundの表記してあるテキスト")] private Text m_NowText;
    [SerializeField] [Header("最大のroundの表記してあるテキスト")] private Text m_MaxText;
    [SerializeField] private int m_RoundMax;
    private int m_NowRoundNum;
    private void Start()
    {
        m_NowRoundNum = 0;
        m_MaxText.text = m_RoundMax.ToString();
    }
    public void CountRound()
    {
        m_NowRoundNum++;
        m_NowText.text = m_NowRoundNum.ToString();

    }

}
