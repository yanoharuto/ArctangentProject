using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlyer1 : MonoBehaviour
{
    private InputParameter m_InputParam;

    private void SetLStickValue()
    {
        m_InputParam.m_LStickHValue = Input.GetAxis("L_Stick_H");
        m_InputParam.m_LStickVValue = Input.GetAxis("L_Stick_V");
    }
    private void SetButtonValue()
    {
        m_InputParam.m_AButton = Input.GetKeyDown("joystick button 0");
        m_InputParam.m_BButton = Input.GetKeyDown("joystick button 1");
        m_InputParam.m_XButton = Input.GetKeyDown("joystick button 2");
        m_InputParam.m_YButton = Input.GetKeyDown("joystick button 3"); 
        m_InputParam.m_RButton = Input.GetKeyDown("joystick button 5");
        m_InputParam.m_LButton = Input.GetKeyDown("joystick button 6");
    }
    /// <summary>
    ///　今のゲームコントローラーのボタン状況
    /// </summary>
    /// <returns></returns>
    public InputParameter GetInputParam()
    {
        SetLStickValue();
        SetButtonValue();
        
        return m_InputParam;
    }
}
