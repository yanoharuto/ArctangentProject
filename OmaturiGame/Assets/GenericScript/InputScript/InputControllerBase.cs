using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class InputControllerBase : MonoBehaviour
{
    protected InputParameter m_InputParam;

    protected virtual void SetLStickValue() { }
    protected virtual void SetButtonValue() { }

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
