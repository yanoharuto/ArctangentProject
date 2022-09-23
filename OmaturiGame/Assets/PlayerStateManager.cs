using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] [Header("�PP �}�E�X�|�C���^�[")] private GameObject m_mousePointer;
    [SerializeField] [Header("����ł���v���C���[(�����ςݔ�\���̂���)")] private GameObject m_player;
    private GameObject m_selectGimmick;//�I�񂾃M�~�b�N�̕ێ�
    
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


    public void SelectUpdate()
    {
        m_mouse.SelectMove();
        

        if (m_mouse.GetSelectGimmick()&&!IsSelect)
        {
            m_selectGimmick = m_mouse.GetSelectGimmick();
            IsSelect = true;
            Debug.Log(m_selectGimmick.name);
        }
    }
    public void PutUpdate()
    {
        m_mouse.PutUpdate();
        
    }




    public void PlayUpdate()
    {
        if(!PlayPartFirst)
        {
            m_player.SetActive(true);
            PlayPartFirst = true;
            Debug.Log("testtesteesttest");
        }
    }
    public void ResultUpdate()
    {

    }
}
