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
    public void InstantiateBarGraph(GameObject barImage,int score,Color graphColor)
    {
        //描画位置はこのオブジェクトの位置から
        Image image = barImage.GetComponent<Image>();
        image.color = graphColor;
        for (int i = 0; i < score; i++)
        {
            GameObject imageObj = Instantiate(barImage.gameObject);
            imageObj.transform.SetParent(transform);
            
        }
    }
}
