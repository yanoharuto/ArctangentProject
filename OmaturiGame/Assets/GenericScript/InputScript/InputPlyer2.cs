using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlyer2 : InputControllerBase
{

    protected override void SetInputValue()
    {
        m_InputParam.m_LStickHValue = Input.GetAxis("L_Stick_H_2");
        m_InputParam.m_LStickVValue = Input.GetAxis("L_Stick_V_2");
        m_InputParam.m_AButton = Input.GetButton("A2");
        m_InputParam.m_BButton = Input.GetButton("B2");
        m_InputParam.m_XButton = Input.GetButton("X2");
        m_InputParam.m_YButton = Input.GetButton("Y2");
        m_InputParam.m_RButton = Input.GetButton("RB2");
        m_InputParam.m_LButton = Input.GetButton("LB2");
    }

}
