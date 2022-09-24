using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private int m_GoalPlayerNum = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            Debug.Log("Goal");
            m_GoalPlayerNum++;
        }
    }
    /// <summary>
    /// ゴールしたPlayerの数
    /// </summary>
    /// <returns></returns>
    public int ShowGorlNum()
    {
        return m_GoalPlayerNum;
    }
    /// <summary>
    /// PlayPartが終了したらクリア人数を0に
    /// </summary>
    public void Clear()
    {
        m_GoalPlayerNum = 0;
    }
}
