using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPart : MonoBehaviour
{
    [SerializeField] [Header("�S�[��")] private Gorl m_Gorl;
    [SerializeField] private List<player> m_Players = new List<player>();

    /// <summary>
    /// �S�[���������Ǝ��񂾐l�̐���player�̐��Ɠ����Ȃ烌�[�X�I��
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        if (m_Gorl.ShowGorlNum() == m_Players.Count)
        {
            m_Gorl.Clear();
            return true;
        }
        return false;
    }
}