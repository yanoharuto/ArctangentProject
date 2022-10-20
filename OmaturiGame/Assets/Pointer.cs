using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] [Header("移動限界")] private float LimmitX;
    [SerializeField] [Header("移動限界")] private float LimmitY;
    [SerializeField] [Header("gimmick管理場")] private GimmickSelectPart m_GimmickSelectPart;
    [SerializeField] [Header("カメラ")]　private Camera camera;
    [SerializeField] [Header("入力情報ゲッター")] private InputControllerBase InputGetter;
    //操作用ポインタ
    Vector3 m_TruePointerPosition;

    //仮操作用兼描画ポインタ
    Vector3 m_PointerPosition;

    bool IsPut;
    InputParameter inputParam;

    [SerializeField] private GameObject m_gimmickObj;

    // Start is called before the first frame update
    void Start()
    {
        m_TruePointerPosition = new Vector3(0, 0, 0);
        gameObject.transform.position = m_TruePointerPosition;
        IsPut = false;
    }
    private void OnEnable()
    {
        IsPut = false;
        m_gimmickObj = null;
    }
    void Update()
    {
        inputParam = InputGetter.GetInputParam();
        //ポインタ操作
        var InputVec = new Vector3(inputParam.m_LStickHValue * 0.01f, inputParam.m_LStickVValue * 0.01f,0.0f);
        m_TruePointerPosition += InputVec;
        //transform.position = new Vector3(
        // //エリア指定して移動する
        // Mathf.Clamp(transform.position.x+InputVec.x, -1*LimmitX, LimmitX),
        // Mathf.Clamp(transform.position.y + InputVec.y, -1 * LimmitY, LimmitY)
        // ,0);

        transform.position = m_TruePointerPosition;
        //Debug.Log(m_TruePointerPosition);
    }


    /// <summary>
    ///選択時にプレイヤーの操作を管轄するクラスに呼ばれる 
    /// </summary>
    public void SelectMove()
    {

        inputParam = InputGetter.GetInputParam();
        //レイを飛ばしてギミック選択
        Ray ray = Camera.main.ScreenPointToRay(camera.WorldToScreenPoint(m_TruePointerPosition));

        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

        if (hit2d)
        {
            
            if (inputParam.m_AButton)
            {

                //ギミックベースかどうかの判定
                var GimmickBase = hit2d.transform.gameObject.GetComponent<GimmickBase>();
                if (GimmickBase)
                {
                    GimmickBase.OnUpdatePutState();
                    //真なら取得
                    m_gimmickObj = GimmickBase.gameObject;

                }
            }

        }
    }
    //置く状態
    public void PutUpdate()
    {

        inputParam = InputGetter.GetInputParam();

        var TmpCursol = camera.WorldToScreenPoint(m_TruePointerPosition);
        m_PointerPosition = TmpCursol;
        //グリッド線の範囲内にマウスポインタが存在している場合
        //if (640 < TmpCursol.x && 1280 > TmpCursol.x)
        {

            var over = TmpCursol.x % 64;
            m_PointerPosition.x -= over;
            over = TmpCursol.y % 64;
            m_PointerPosition.y -= over;
            //ギミックの基本機能を所得
            GimmickBase gimmick = m_gimmickObj.GetComponent<GimmickBase>();
            
            //LRを押したら回転
            if (inputParam.m_LButton)
            {

                gimmick.PitchRotate(true);
            }
            if (inputParam.m_RButton)
            {
                gimmick.PitchRotate(false);
            }
            //Aボタンを押して何かとかぶっていないなら
            if (inputParam.m_AButton&&!gimmick.GetOverLap())
            {
                gimmick.OnUpdatePutState();
                m_GimmickSelectPart.OnRecieveGimmick(m_gimmickObj.GetComponent<GimmickBase>());
            }
            if(m_gimmickObj.GetComponent<GimmickBase>().GetOverLap())
            {
                Debug.Log("置けません");
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

}
