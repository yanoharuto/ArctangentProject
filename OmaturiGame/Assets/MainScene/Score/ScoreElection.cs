using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// これをアタッチしてあるオブジェクトを起点に棒グラフを表示する
/// </summary>
public class ScoreElection : MonoBehaviour
{
    private float m_GraphX = 0;
    /// <summary>
    /// スコアのUIを出すよ
    /// </summary>
    /// <param name="score"></param>
    /// <param name="graphColor"></param>
    public void InstantiateBarGraph(Image barGraph,int score,Color graphColor)
    {
        Image graph = Instantiate(barGraph);
        Vector3 scale = graph.transform.localScale;
        //描画位置はこのオブジェクトの位置から
        Vector3 pos = transform.position;
        //scoreの分だけグラフを伸ばす
        scale.x = score;
        //前回の描画位置と画像の半径から描画位置を確定
        pos.x += m_GraphX + scale.x / 2;
        //前回の描画位置を更新
        m_GraphX = pos.x;
        //描画位置とサイズと色を変更
        graph.transform.position = pos;
        graph.color = graphColor;
    }
}
