﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PartManager : MonoBehaviour
{
    [SerializeField][Header("Playerのコントロールクラス")] private GameObject m_player;
    [SerializeField] [Header("ギミックを表示する奴")] GimmickSelectPart m_gimmickSelect;
    [SerializeField] [Header("Stage")] private GameObject m_stage;
    [SerializeField] [Header("Grid")] private GameObject m_grid;
    [SerializeField] [Header("text")] private Text text;
    private MainState m_state = MainState.SelectGimmickPart;//操作できる部分を切り替えるために必要
    PlayerStateManager playerStateManager;
    GridLine gridLine;
    // Start is called before the first frame update
    void Start()
    {
        //最初から使用
        text.text = "select";
        playerStateManager=m_player.GetComponent<PlayerStateManager>();
       

        //PutPartから描画
        m_stage.SetActive(false);
        //m_grid.SetActive(false);
        gridLine=m_grid.GetComponent<GridLine>();
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (m_state)
        {
            case MainState.SelectGimmickPart:
                playerStateManager.SelectUpdate();
                m_gimmickSelect.ElectionGimmick();
                //プレイヤーが選択したかの取得
                if (playerStateManager.IsSelectGimmick())
                {
                    m_state = MainState.PutGimmickPart;
                    text.text = "Put";
                    m_stage.SetActive(true);
                    gridLine.SetAllActive();
                }

                break;
            case MainState.PutGimmickPart:

                playerStateManager.PutUpdate();
                if(playerStateManager.IsPutGimmick())
                {
                    m_state = MainState.PlayPart;
                    text.text = "Play";

                    gridLine.UnSetAllActive();
                }

                break;
            case MainState.PlayPart:
                playerStateManager.PlayUpdate();
                break;
            case MainState.ResultPart:
                break;
        }

    }
}
