using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボタンとかのUIのスクリプトはこいつを継承してると多分便利
/// </summary>
public abstract class UIBase : MonoBehaviour
{
    
    [SerializeField] protected AudioSource m_Audios;
    virtual public void OnRun() { } 
}
