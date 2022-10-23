using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PartManager : MonoBehaviour
{
    [SerializeField] [Header("Playerのコントロールクラス")] private PlayerStateManager m_1PStateManager;
    [SerializeField] [Header("Playerのコントロールクラス")] private PlayerStateManager m_2PStateManager;
    [SerializeField] [Header("ギミックを更新したりするのに使う")]private GimmickManager m_GManager;
    [SerializeField] [Header("ギミックを表示する奴")] GimmickSelectPart m_gimmickSelect;
    [SerializeField] [Header("ラウンドを更新するよう")] private RoundUpdater m_RoundUpdater;
    [SerializeField] [Header("Result")] private ResultPart m_resultPart;
    [SerializeField] [Header("Play")] private PlayPart m_playePart;
    [SerializeField] [Header("Stage")] private GameObject m_stage;
    [SerializeField] [Header("Grid")] private GameObject m_grid;
    [SerializeField] [Header("text")] private Text text;
    private MainState m_State = MainState.SelectGimmickPart;//操作できる部分を切り替えるために必要
    private const int m_PlayerNum = 2;//デバッグするときはいじって
    private bool m_MainEnd = false;
    private bool m_FirstRound = true;
    GridLine gridLine;
    private void ResultUpdate()
    {
        m_resultPart.Run();
        if (m_resultPart.IsDisplayEnd())
        {   
            //ラウンド更新
            m_RoundUpdater.OnCountRound();

            m_MainEnd = m_resultPart.GetWin() ;
            //ラウンド終了していないなら
            if (!m_RoundUpdater.IsMainEnd())
            {
                m_State = MainState.SelectGimmickPart;
            }
            else
            {
                m_MainEnd = true;
            }
            m_FirstRound = false;
        }
    }
    //遊び終わったら破壊予定のギミックを破壊する
    private void PlayUpdate()
    {
        if (m_playePart.IsEnd())
        {
            //破壊予定のギミックを破壊する
            m_GManager.OnDestroyGimmick();
            m_State = MainState.ResultPart;
        }
    }
    private void SelectUpdate()
    {
        m_gimmickSelect.ElectionGimmick(m_FirstRound);
        m_GManager.UpdateElectionGimmick(m_State);
        //プレイヤーが選択したかの取得
        if (m_1PStateManager.IsSelectGimmick()&&m_2PStateManager.IsSelectGimmick())
        {
            m_State = MainState.PutGimmickPart;
            m_stage.SetActive(true);
            gridLine.SetAllActive();

        }
    }
    private void PutUpdate()
    {
        m_GManager.UpdateElectionGimmick(m_State);
        if (m_gimmickSelect.PutedGimmickEnd())
        {
            m_State = MainState.PlayPart;
            gridLine.UnSetAllActive();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //PutPartから描画
        m_stage.SetActive(false);
        //m_grid.SetActive(false);
        gridLine=m_grid.GetComponent<GridLine>();
        //初期化
        m_gimmickSelect.OnInit(m_PlayerNum,m_GManager);
        m_playePart.OnInit(m_PlayerNum);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = m_State.ToString();
        if (m_MainEnd)
        {
            m_resultPart.OnNextSceneChange();
        }
        else if (!m_MainEnd) 
        {      
            m_1PStateManager.Run(m_State);
            m_2PStateManager.Run(m_State);
            m_GManager.UpdatePutGimmick(m_State);
            switch (m_State)
            {
                case MainState.SelectGimmickPart:
                    SelectUpdate();
                    break;
                case MainState.PutGimmickPart:
                    PutUpdate();
                    break;
                case MainState.PlayPart:
                    PlayUpdate();
                    break;
                case MainState.ResultPart:
                    ResultUpdate();
                    break;
            }

        }
    }

  
}
