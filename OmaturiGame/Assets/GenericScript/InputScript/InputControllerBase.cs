using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class InputControllerBase : MonoBehaviour
{
    protected InputParameter m_InputParam;

    protected virtual void SetInputValue() { }

    /// <summary>
    ///　今のゲームコントローラーのボタン状況
    /// </summary>
    /// <returns></returns>
    public InputParameter GetInputParam()
    {
        SetInputValue();

        return m_InputParam;
    }
}
