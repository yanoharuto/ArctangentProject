using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private int m_MaxRound;
    [SerializeField] private PlayPart m_PlayPart;
    [SerializeField] private GimmickSelectPart m_GSelectPart;
    [SerializeField] private MainState m_State = MainState.SelectGimmickPart;
    private GimmickManager m_GManager;
    private bool m_IsStartPlayPart;
    private void PlayLoop()
    {
        switch (m_State)
        {
            case MainState.SelectGimmickPart:
                //ギミック選出
                m_GSelectPart.ElectionGimmick();
                //ギミックを二つ選んだなら
                if (m_GSelectPart.IsSelectGimmickEnd())
                {
                    m_State = MainState.PlayPart;
                    //ギミックをHammerRunに
                    m_GSelectPart.ChangeGimmicksState();
                }
                break;
            case MainState.PlayPart:
                if(!m_IsStartPlayPart)
                {
                    m_IsStartPlayPart = true;
                    //ギミックをRun状態に
                    m_GSelectPart.ChangeGimmicksState();
                }
                if (m_PlayPart.IsEnd())
                {           
                    m_IsStartPlayPart = false;
                    m_State = MainState.ResultPart;
                    //ギミックをStandby状態にする
                    m_GSelectPart.ChangeGimmicksState();
                }
                break;
            case MainState.ResultPart:


                break;
        }
    }
    private void Update()
    {

        PlayLoop();
    }
    private void Start()
    {
        m_GManager = this.gameObject.AddComponent<GimmickManager>();
        m_GSelectPart.InitGimmickManager(m_GManager);
    }
}
