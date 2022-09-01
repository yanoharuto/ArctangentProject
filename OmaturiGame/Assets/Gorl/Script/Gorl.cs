using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorl : MonoBehaviour
{
    private int m_GorlPlayerNum = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            m_GorlPlayerNum++;
        }
    }
    /// <summary>
    /// ゴールしたPlayerの数
    /// </summary>
    /// <returns></returns>
    public int ShowGorlNum()
    {
        return m_GorlPlayerNum;
    }
    /// <summary>
    /// PlayPartが終了したらクリア人数を0に
    /// </summary>
    public void Clear()
    {
        m_GorlPlayerNum = 0;
    }
}
