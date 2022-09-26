using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPart : MonoBehaviour
{
    [SerializeField] [Header("ゴール")] private Goal m_Gorl;
    [SerializeField] private int m_PlayersNum ;

    /// <summary>
    /// ゴールした数と死んだ人の数がplayerの数と同じならレース終了
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