using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlyer2 : InputControllerBase
{

    protected override void SetInputValue()
    {
        m_InputParam.m_LStickHValue = Input.GetAxis("L_Stick_H_2");
        m_InputParam.m_LStickVValue = Input.GetAxis("L_Stick_V_2");
        m_InputParam.m_AButton = Input.GetButtonDown("A2");
        m_InputParam.m_BButton = Input.GetButtonDown("B2");
        m_InputParam.m_XButton = Input.GetButtonDown("X2");
        m_InputParam.m_YButton = Input.GetButtonDown("Y2");
        m_InputParam.m_RButton = Input.GetButtonDown("RB2");
        m_InputParam.m_LButton = Input.GetButtonDown("LB2");
    }

}
