using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private int m_MaxRound;
    private GimmickSelectPart m_GSelectPart;
    private MainState m_State = MainState.SelectGimmickPart;
    private bool m_IsChangeState = false;
    private void PlayLoop()
    {
        switch(m_State)
        {
            case MainState.SelectGimmickPart:
                    m_State = MainState.PlayPart;
                    //ハンマー起動状態に遷移
                    m_GSelectPart.ChangeGimmicksState();
                break;
            case MainState.PlayPart:
                    m_GSelectPart.ChangeGimmicksState();
                break;
            case MainState.ResultPart:

                break;
        }
    }
    private void Update()
    {

        PlayLoop();
    }
}
