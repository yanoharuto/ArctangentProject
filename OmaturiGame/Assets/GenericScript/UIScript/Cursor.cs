using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] List<UIBase> m_ButtonUI = new List<UIBase>();
    [SerializeField] [Header("こいつの移動時のSE鳴らす用")] private AudioSource m_Audio;
    private int m_Num = 0;

    private void Start()
    {
        transform.position = m_ButtonUI[0].transform.position;
    }
    public void OnUIMove(int ListNum)
    {
        transform.position = m_ButtonUI[ListNum].transform.position;
        m_Num = ListNum;
        m_Audio.Play();
    }
    /// <summary>
    /// 決定ボタンを押したら次のシーンに行くかチュートリアル再生
    /// </summary>
    public void OnRunButton()
    {
        m_ButtonUI[m_Num].OnRun();
    }
}
