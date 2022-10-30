using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlyer1 : InputControllerBase
{
   
    protected override void SetInputValue()
    {
        m_InputParam.m_LStickHValue = Input.GetAxis("L_Stick_H_1");
        m_InputParam.m_LStickVValue = Input.GetAxis("L_Stick_V_1");
        m_InputParam.m_AButton = Input.GetButtonDown("A1");
        m_InputParam.m_BButton = Input.GetButtonDown("B1");
        m_InputParam.m_XButton = Input.GetButtonDown("X1");
        m_InputParam.m_YButton = Input.GetButtonDown("Y1");
        m_InputParam.m_RButton = Input.GetButtonDown("RB1");
        m_InputParam.m_LButton = Input.GetButtonDown("LB1");

    }

}
