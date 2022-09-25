using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPart : MonoBehaviour
{
    [SerializeField] [Header("�S�[��")] private Goal m_Gorl;
    [SerializeField] private int m_PlayersNum ;

    /// <summary>
    /// �S�[���������Ǝ��񂾐l�̐���player�̐��Ɠ����Ȃ烌�[�X�I��
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        if (m_Gorl.ShowGorlNum() == m_PlayersNum)
        {
            m_Gorl.Clear();
            return true;
        }
        return false;
    }
}