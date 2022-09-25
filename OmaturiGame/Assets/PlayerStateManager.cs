using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] [Header("１P マウスポインター")] private GameObject m_mousePointer;
    [SerializeField] [Header("操作できるプレイヤー(生成済み非表示のもの)")] private GameObject m_player;
    private GameObject m_selectGimmick;//選んだギミックの保持
    
    bool IsSelect;
    Pointer m_mouse;

    bool PlayPartFirst;

    // Start is called before the first frame update
    void Start()
    {
        IsSelect = false;
        PlayPartFirst = false;
        m_mouse=m_mousePointer.GetComponent<Pointer>();
        m_player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsSelectGimmick()
    {
        return IsSelect;
    }
    public bool IsPutGimmick()
    {
        return m_mouse.IsPutGimmick();
    }


    private void SelectUpdate()
    {
        m_mouse.gameObject.SetActive(true);
        m_mouse.SelectMove();

        Debug.Log(IsSelect);
        if (m_mouse.GetSelectGimmick() != null &&!IsSelect)
        {
            m_selectGimmick = m_mouse.GetSelectGimmick();
            IsSelect = true;
        }
        
    }
    private void PutUpdate()
    {
        m_mouse.PutUpdate();
        
    }




    private void PlayUpdate()
    {
        if(!PlayPartFirst)
        {
            m_player.SetActive(true);
            PlayPartFirst = true;
            m_mouse.gameObject.SetActive(false);
            Debug.Log("testtesteesttest");

        }
    }
    private void ResultUpdate()
    {

    }
    public void Run(MainState mainState)
    {
        switch(mainState)
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
