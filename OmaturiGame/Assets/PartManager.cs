using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PartManager : MonoBehaviour
{
    [SerializeField][Header("Player�̃R���g���[���N���X")] private GameObject m_player;
    [SerializeField] [Header("Stage")] private GameObject m_stage;
    [SerializeField] [Header("Grid")] private GameObject m_grid;
    [SerializeField] [Header("text")] private Text text;
    private MainState m_state = MainState.SelectGimmickPart;//����ł��镔����؂�ւ��邽�߂ɕK�v
    PlayerStateManager playerStateManager;
    GridLine gridLine;
    // Start is called before the first frame update
    void Start()
    {
        //�ŏ�����g�p
        text.text = "select";
        playerStateManager=m_player.GetComponent<PlayerStateManager>();
       

        //PutPart����`��
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
                //�v���C���[���I���������̎擾
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
