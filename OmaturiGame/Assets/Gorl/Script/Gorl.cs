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
    /// �S�[������Player�̐�
    /// </summary>
    /// <returns></returns>
    public int ShowGorlNum()
    {
        return m_GorlPlayerNum;
    }
    /// <summary>
    /// PlayPart���I��������N���A�l����0��
    /// </summary>
    public void Clear()
    {
        m_GorlPlayerNum = 0;
    }
}
