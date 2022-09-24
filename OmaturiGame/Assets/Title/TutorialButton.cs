using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : UIBase
{
    [SerializeField] [Header("チュートリアル再生するオブジェクトをください")] GameObject m_TutorialObj;
    override public void OnRun()
    {
        m_Audios.Play();
        Instantiate(m_TutorialObj);
    }
}
