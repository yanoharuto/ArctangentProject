using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    
    [SerializeField] [Header("�ݒu�\�M�~�b�N")] private�@GameObject m_obj;
    //�M�~�b�N�͐���ɃZ�b�g����Ă��邩
    bool m_SetGimmikBase=false;
    GameObject createObj;
    // Start is called before the first frame update
    void Start()
    {
        if(m_obj.GetComponent<GimmickBase>())
        {
            Debug.Log("GB1�@����");
            m_SetGimmikBase = true;
            createObj= Instantiate(m_obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            createObj.name = "�M�~�b�N";
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
                var screenPos = new Vector3(mousePosition.x, mousePosition.y, 1f);
                var worldpos = Camera.main.ScreenToWorldPoint(screenPos);
                createObj.transform.position = worldpos;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("���|�C���^�[��������܂����B");
                Debug.Log(mousePosition.x);
                m_SetGimmikBase = false;
            }

        }

        gameObject.transform.position = mousePosition;

       

    }
}
