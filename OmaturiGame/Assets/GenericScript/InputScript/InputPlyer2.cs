using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlyer2 : InputControllerBase
{

    protected override void SetInputValue()
    {
        m_InputParam.m_LStickHValue = Input.GetAxis("L_Stick_H_2");
        m_InputParam.m_LStickVValue = Input.GetAxis("L_Stick_V_2");
        m_InputParam.m_AButton = Input.GetKeyDown("A2");
        m_InputParam.m_BButton = Input.GetKeyDown("B2");
        m_InputParam.m_XButton = Input.GetKeyDown("X2");
        m_InputParam.m_YButton = Input.GetKeyDown("Y2");
        m_InputParam.m_RButton = Input.GetKeyDown("RB2");
        m_InputParam.m_LButton = Input.GetKeyDown("LB2");
    }

}
