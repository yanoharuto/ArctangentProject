using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //ラウンド数
    [SerializeField] private int m_MaxRound;
    //ギミック選択部分
    [SerializeField] private GimmickSelectPart m_GSelectPart;
    //プレイヤーが遊ぶ部分
    [SerializeField] private PlayPart m_PlayPart;
    //最初は選ぶパートからスターと
    [SerializeField] private MainState m_State = MainState.SelectGimmickPart;
    
    //パートごとにギミックの動きを変える
    private GimmickManager m_GManager;
    //プレイヤーパートが始まったか
    private bool m_IsStartPlayPart;
    
    private void PlayLoop()//実質メインループ
    {
      
        
        //状態によって処理の分岐
        switch (m_State)
        {
            //ギミックを選択するぱート
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
                Debug.Log("Playpart");
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
