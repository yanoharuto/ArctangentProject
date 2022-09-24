using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleInput : MonoBehaviour
{
   
    [SerializeField] List<Transform> m_ButtonT;
    [SerializeField] [Header("こいつの移動時のSE鳴らす用")] private AudioSource m_Audio;
    [SerializeField] [Header("JoyStickの入力の名前")] private string m_JoyStickInputName;
    [SerializeField] [Header("決定するときのボタンの名前")] private string m_DecisionInputName;
    [SerializeField] [Header("次のシーンに進むためのスクリプト")] private Go2GameScene m_Go2GameScene;
    private int m_Num = 0;
    // Update is called once per frame
    void Update()
    {   
        //if (Input.GetKeyDown(m_JoyStickInputName))
        //{
        //    RunJoystickDown();
        //    if(Input.GetKeyDown(m_DecisionInputName))
        //    {
        //        RunButton();
        //    }
        //}
        transform.position = m_ButtonT[m_Num % 2].position;
    }
    /// <summary>
    /// 決定ボタンを押したら次のシーンに行くかチュートリアル再生
    /// </summary>
    private void RunButton()
    {
        if (m_Num % 2 == 0)   
        {
            m_Go2GameScene.OnClickGo2GameSceneButton();
        }
        else
        {
            m_Go2GameScene.OnPlayTutorial();
        }
        
    }
    /// <summary>
    /// こいつを移動させる
    /// </summary>
    private void RunJoystickDown()
    {
        m_Audio.Play();
        m_Num++;

    }
}
