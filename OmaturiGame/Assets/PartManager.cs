using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PartManager : MonoBehaviour
{
    [SerializeField][Header("Playerのコントロールクラス")] private PlayerStateManager playerStateManager;
    [SerializeField] [Header("ギミックを表示する奴")] GimmickSelectPart m_gimmickSelect;
    [SerializeField] [Header("Result")] private ResultPart m_resultPart;
    [SerializeField] [Header("Play")] private PlayPart m_playePart;
    [SerializeField] [Header("Stage")] private GameObject m_stage;
    [SerializeField] [Header("Grid")] private GameObject m_grid;
    [SerializeField] [Header("text")] private Text text;
    private MainState m_state = MainState.SelectGimmickPart;//操作できる部分を切り替えるために必要
    private int m_WinnerNum;
    private bool m_MainEnd = false;
    GridLine gridLine;
    // Start is called before the first frame update
    void Start()
    {
        //最初から使用
        text.text = "select";
       

        //PutPartから描画
        m_stage.SetActive(false);
        //m_grid.SetActive(false);
        gridLine=m_grid.GetComponent<GridLine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_WinnerNum != 0 && !m_MainEnd)
        {
            m_resultPart.OnNextSceneChange(m_WinnerNum);
            m_MainEnd = true;
        }
        else if (!m_MainEnd) 
        {
            switch (m_state)
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
            playerStateManager.Run(m_state);
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
                m_state = MainState.SelectGimmickPart;
                m_gimmickSelect.ChangeGimmicksState(m_state);
            }
        }
    }
    private void PlayUpdate()
    {
        if (m_playePart.IsEnd())
        {
            m_state = MainState.ResultPart;
            m_gimmickSelect.ChangeGimmicksState(m_state);
            text.text = "Result";
        }
    }
    private void SelectUpdate()
    {
        m_gimmickSelect.ElectionGimmick();
        //プレイヤーが選択したかの取得
        if (playerStateManager.IsSelectGimmick())
        {
            m_state = MainState.PutGimmickPart;
            m_gimmickSelect.ChangeGimmicksState(m_state);
            text.text = "Put";
            m_stage.SetActive(true);
            gridLine.SetAllActive();
        }
    }
    private void PutUpdate()
    {
        if (m_gimmickSelect.PutedGimmickEnd())
        {
            m_state = MainState.PlayPart;
            text.text = "Play";
            m_gimmickSelect.ChangeGimmicksState(m_state);
            gridLine.UnSetAllActive();
        }
    }
}
