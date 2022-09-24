using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] [Header("タイトルのカーソルUI")] private Cursor m_Cursor;
    [SerializeField] [Header("ゲームコントローラーの入力状況所得用")] private GetInputXBoxController m_GetInput;


    // Update is called once per frame
    void Update()
    {
        InputParameter iParam = m_GetInput.GetInputParam();
        
        if (iParam.m_LStickHValue > 0)
        {
            m_Cursor.OnUIMove(1);
        }
        else if (iParam.m_LStickHValue < 0)
        {
            m_Cursor.OnUIMove(0);
        }
        if (iParam.m_BButton)
        {
            m_Cursor.OnRunButton();
        }
    }
    
}
