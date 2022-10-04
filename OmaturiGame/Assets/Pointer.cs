using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    //ボタンの名前を検索しやすいよう定義-----------------------------------
    const string m_inputVecNameX = "Horizontal";
    const string m_inputVecNameY = "Vertical";
    const string m_InputButtonA = "Xbox_A";
    //-----------------------------------------------------
    [SerializeField] [Header("入力情報ゲッター")] private InputControllerBase InputGetter;
    [SerializeField] [Header("移動限界")] private float LimmitX;
    [SerializeField] [Header("移動限界")] private float LimmitY;
    [SerializeField] [Header("gimmick管理場")] private GimmickSelectPart m_GimmickSelectPart;
    [SerializeField] [Header("カメラ")]　private Camera camera;
    //操作用ポインタ
    Vector3 m_TruePointerPosition;

    //仮操作用兼描画ポインタ
    Vector3 m_PointerPosition;

    bool IsPut;

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
        InputParameter inputParam = InputGetter.GetInputParam();
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
        InputParameter inputParam = InputGetter.GetInputParam();

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
                    //真なら取得
                    m_gimmickObj = GimmickBase.gameObject;
                    GimmickBase.OnPut();
                }
            }

        }
    }
    //置く状態
    public void PutUpdate()
    {

        InputParameter inputParam = InputGetter.GetInputParam();

        var TmpCursol = camera.WorldToScreenPoint(m_TruePointerPosition);
        m_PointerPosition = TmpCursol;

        //グリッド線の範囲内にマウスポインタが存在している場合
        if (640 < TmpCursol.x && 1280 > TmpCursol.x)
        {

            var over = TmpCursol.x % 64;
            m_PointerPosition.x -= over;
            over = TmpCursol.y % 64;
            m_PointerPosition.y -= over;
            //回転
            if(inputParam.m_LButton)
            {
                m_gimmickObj.GetComponent<GimmickBase>().PitchRotate();
            }
            else if(inputParam.m_RButton)
            {
                m_gimmickObj.GetComponent<GimmickBase>().PitchRotate();
            }
            if (inputParam.m_AButton)
            {
                m_GimmickSelectPart.RecieveGimmick(m_gimmickObj.GetComponent<GimmickBase>());
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
