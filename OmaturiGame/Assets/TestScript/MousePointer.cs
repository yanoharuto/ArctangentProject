using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    
    [SerializeField] [Header("�ݒu�\�M�~�b�N")] private�@GimmickBase m_obj;
    [SerializeField][Header("GimmickSelectPart�^�̃I�u�W�F�N�g��ݒ�")] private GameObject m_selectPart;
    //�M�~�b�N�͐���ɃZ�b�g����Ă��邩
    bool m_SetGimmikBase=false;
    GameObject createObj;
    GimmickSelectPart gimmickSelectPart;
    // Start is called before the first frame update
    void Start()
    {
        gimmickSelectPart = m_selectPart.GetComponent<GimmickSelectPart>();
        if (gimmickSelectPart)
        {
            Debug.Log(gimmickSelectPart.name);
        }

        if(m_obj.GetComponent<GimmickBase>())
        {
            Debug.Log("GB1�@����");
            m_SetGimmikBase = true;
            createObj= Instantiate(m_obj.gameObject, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            createObj.name = "�M�~�b�N�ł�";
        }
        else
        {
            Debug.Log("GB1  �ُ�");
        }


    }

    // Update is called once per frame
    void Update()
    {

        var mousePosition = Input.mousePosition;
        //�O���b�h���͈͓̔��Ƀ}�E�X�|�C���^�����݂��Ă���ꍇ
        if(640 < mousePosition.x&& 1280 > mousePosition.x)
        {

            var over = mousePosition.x % 64;
            mousePosition.x -= over;
            over = mousePosition.y % 64;
            mousePosition.y -= over;
            if(m_SetGimmikBase)
            {
                //var screenPos = new Vector3(mousePosition.x, mousePosition.y, 1f);
                //var worldpos = Camera.main.ScreenToWorldPoint(screenPos);
                //createObj.transform.position = worldpos;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("���|�C���^�[��������܂����B");
                Debug.Log(mousePosition.x);
                m_SetGimmikBase = false;
                gimmickSelectPart.RecieveGimmick(createObj);
            }

        }

        gameObject.transform.position = mousePosition;

       

    }
}
