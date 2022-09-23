using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    //�{�^���̖��O���������₷���悤��`-----------------------------------
    const string m_inputVecNameX = "Horizontal";
    const string m_inputVecNameY = "Vertical";
    const string m_InputButtonA = "Xbox_A";
    //-----------------------------------------------------
    [SerializeField] [Header("�ړ����E")] private float LimmitX;
    [SerializeField] [Header("�ړ����E")] private float LimmitY;
    [SerializeField] [Header("�J����")]�@private Camera camera;
    //����p�|�C���^
    Vector3 m_TruePointerPosition;

    //������p���`��|�C���^
    Vector3 m_PointerPosition;

    bool IsPut;

    private GameObject m_gimmickObj;


    // Start is called before the first frame update
    void Start()
    {
        m_TruePointerPosition = new Vector3(0, 0, 0);
        gameObject.transform.position = m_TruePointerPosition;
        IsPut = false;
    }
     void Update()
    {
        //�|�C���^����
        var InputVec = new Vector3(Input.GetAxis(m_inputVecNameX) * 0.01f, Input.GetAxis(m_inputVecNameY) * 0.01f,0.0f);
        m_TruePointerPosition += InputVec;
        //transform.position = new Vector3(
        // //�G���A�w�肵�Ĉړ�����
        // Mathf.Clamp(transform.position.x+InputVec.x, -1*LimmitX, LimmitX),
        // Mathf.Clamp(transform.position.y + InputVec.y, -1 * LimmitY, LimmitY)
        // ,0);

        transform.position = m_TruePointerPosition;
        //Debug.Log(m_TruePointerPosition);
    }


    /// <summary>
    ///�I�����Ƀv���C���[�̑�����Ǌ�����N���X�ɌĂ΂�� 
    /// </summary>
    public void SelectMove()
    {

       
        //���C���΂��ăM�~�b�N�I��
        Ray ray = Camera.main.ScreenPointToRay(camera.WorldToScreenPoint(m_TruePointerPosition));

        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

        if (hit2d)
        {
            
            if (Input.GetButtonDown(m_InputButtonA))
            {

                //�M�~�b�N�x�[�X���ǂ����̔���
                var GimmickBase = hit2d.transform.gameObject.GetComponent<GimmickBase>();
                if (GimmickBase)
                {
                    //�^�Ȃ�擾
                    m_gimmickObj = GimmickBase.gameObject;

                }
            }

        }
    }
    //�u�����
    public void PutUpdate()
    {
        


        var TmpCursol = camera.WorldToScreenPoint(m_TruePointerPosition);
        m_PointerPosition = TmpCursol;

        //�O���b�h���͈͓̔��Ƀ}�E�X�|�C���^�����݂��Ă���ꍇ
        if (640 < TmpCursol.x && 1280 > TmpCursol.x)
        {

            var over = TmpCursol.x % 64;
            m_PointerPosition.x -= over;
            over = TmpCursol.y % 64;
            m_PointerPosition.y -= over;

            if (Input.GetButtonDown(m_InputButtonA))
            {
                Debug.Log("���|�C���^�[��������܂����B");
                IsPut = true;
            }

        }
        if(!IsPut)
        {
            m_gimmickObj.transform.position = camera.ScreenToWorldPoint(m_PointerPosition);
        }
        
        
    }





    public GameObject GetSelectGimmick()
    {
        return m_gimmickObj;
    }
    public bool IsPutGimmick()
    {
        return IsPut;
    }
}
