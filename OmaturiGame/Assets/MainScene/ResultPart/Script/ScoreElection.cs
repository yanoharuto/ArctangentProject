using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// これをアタッチしてあるオブジェクトを起点に棒グラフを表示する
/// </summary>
public class ScoreElection : MonoBehaviour
{
    private int m_ImageNum = 0;
    /// <summary>
    /// スコアのUIを出すよ
    /// </summary>
    /// <param name="score"></param>
    /// <param name="graphColor"></param>
    public void InstantiateBarGraph(Image image,int score,Vector3 between, Color graphColor)
    {
        Vector3 pos = transform.position;
        for (int i = 0; i < score; i++)
        {
            Image imageObj = Instantiate(image);
            Transform imageT = imageObj.transform;
            imageT.position = pos + between * m_ImageNum;
            imageT.SetParent(transform);
            imageObj.color = graphColor;
            m_ImageNum++;
        }
    }
}
