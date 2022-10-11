using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PartManager : MonoBehaviour
{
    [SerializeField] [Header("Playerのコントロールクラス")] private PlayerStateManager playerStateManager;
    [SerializeField] [Header("ギミックを更新したりするのに使う")]private GimmickManager m_GManager;
    [SerializeField] [Header("ギミックを表示する奴")] GimmickSelectPart m_gimmickSelect;
    [SerializeField] [Header("Result")] private ResultPart m_resultPart;
    [SerializeField] [Header("Play")] private PlayPart m_playePart;
    [SerializeField] [Header("Stage")] private GameObject m_stage;
    [SerializeField] [Header("Grid")] private GameObject m_grid;
    [SerializeField] [Header("text")] private Text text;
    private MainState m_State = MainState.SelectGimmickPart;//操作できる部分を切り替えるために必要
    private const int m_PlayerNum = 2;
    private int m_WinnerNum;
    private bool m_MainEnd = false;
    GridLine gridLine;
    // Start is called before the first frame update
    void Start()
    {
        //PutPartから描画
        m_stage.SetActive(false);
        //m_grid.SetActive(false);
        gridLine=m_grid.GetComponent<GridLine>();
        //初期化
        m_gimmickSelect.OnFirstInit(m_PlayerNum,m_GManager);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = m_State.ToString();
        if (m_WinnerNum != 0 && !m_MainEnd)
        {
            m_resultPart.OnNextSceneChange(m_WinnerNum);
            m_MainEnd = true;
        }
        else if (!m_MainEnd) 
        {
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
            playerStateManager.Run(m_State);
            m_GManager.UpdatePutGimmick(m_State);
        }
    }

    private void ResultUpdate()
    {
        m_resultPart.Run();
        if (m_resultPart.IsDisplayEnd())
        {
            m_WinnerNum = m_resultPart.OnGetWinnerNum();
            
            if (m_WinnerNum == 0)
            {
                m_State = MainState.SelectGimmickPart;
            }
        }
    }
    private void PlayUpdate()
    {
        if (m_playePart.IsEnd())
        {
            m_State = MainState.ResultPart;
        }
    }
    private void SelectUpdate()
    {
        m_gimmickSelect.ElectionGimmick();
        m_GManager.UpdateElectionGimmick(m_State);
        //プレイヤーが選択したかの取得
        if (playerStateManager.IsSelectGimmick())
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
}
