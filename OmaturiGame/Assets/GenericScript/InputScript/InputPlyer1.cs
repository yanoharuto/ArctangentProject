using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlyer1 : InputControllerBase
{
   
    protected override void SetInputValue()
    {
        m_InputParam.m_LStickHValue = Input.GetAxis("L_Stick_H_1");
        m_InputParam.m_LStickVValue = Input.GetAxis("L_Stick_V_1");
        m_InputParam.m_AButton = Input.GetButton("A1");
        m_InputParam.m_BButton = Input.GetButton("B1");
        m_InputParam.m_XButton = Input.GetButton("X1");
        m_InputParam.m_YButton = Input.GetButton("Y1");
        m_InputParam.m_RButton = Input.GetButton("RB1");
        m_InputParam.m_LButton = Input.GetButton("LB1");

    }

}
