using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class InputControllerBase : MonoBehaviour
{
    protected InputParameter m_InputParam;

    protected virtual void SetInputValue() { }

    /// <summary>
    ///�@���̃Q�[���R���g���[���[�̃{�^����
    /// </summary>
    /// <returns></returns>
    public InputParameter GetInputParam()
    {
        SetInputValue();

        return m_InputParam;
    }
}
