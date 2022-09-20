using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// これをアタッチしてあるオブジェクトを起点に棒グラフを表示する
/// </summary>
public class ScoreElection : MonoBehaviour
{
    [SerializeField] [Header("スコアを表示する棒グラフの画像")] private Image m_BarGraph;

    public void ElectionBarGraph(int score,Color graphColor)
    {
        
    }
}
