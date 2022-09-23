using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    
    private　GimmickBase m_obj;
    //[SerializeField] [Header("GimmickSelectPart型のオブジェクトを設定")] private GameObject m_selectPart;
    private MainState m_state=MainState.SelectGimmickPart;
    //ギミックは正常にセットされているか
    bool m_SetGimmikBase=false;
    GameObject createObj;
    GimmickSelectPart gimmickSelectPart;
    Vector3 mousePosition;
    bool IsSelectGimmick=false;
    // Start is called before the first frame update
    void Start()
    {

        if (gimmickSelectPart)
        {
            Debug.Log(gimmickSelectPart.name);
        }

        //if(m_obj.GetComponent<GimmickBase>())
        //{
        //    Debug.Log("GB1　正常");
        //    m_SetGimmikBase = true;
        //    createObj= Instantiate(m_obj.gameObject, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        //    createObj.name = "ギミックです";
        //}
        //else
        //{
        //    Debug.Log("GB1  異常");
        //}


    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        switch (m_state)
        {
            //ギミックを選択するぱート
            case MainState.SelectGimmickPart:
                UpdateGimmick();
                break;
            case MainState.PutGimmickPart:
                UpdatePutGimmick();
                break;
            case MainState.PlayPart:
                
                break;
            case MainState.ResultPart:


                break;
        }
        

        
    }

    void UpdateGimmick()
    {
        //レイを飛ばしてギミック選択
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
        if (hit2d)
        {
            if(Input.GetMouseButtonDown(0))
            {
                var GimmickBase = hit2d.transform.gameObject.GetComponent<GimmickBase>();
                if (GimmickBase)
                {
                    m_obj = GimmickBase;
                   
                }
            }
            
        }
        

        
        
    }

    void UpdatePutGimmick()
    {
        //グリッド線の範囲内にマウスポインタが存在している場合
        if (640 < mousePosition.x && 1280 > mousePosition.x)
        {

            var over = mousePosition.x % 64;
            mousePosition.x -= over;
            over = mousePosition.y % 64;
            mousePosition.y -= over;
            if (m_SetGimmikBase)
            {
                //var screenPos = new Vector3(mousePosition.x, mousePosition.y, 1f);
                //var worldpos = Camera.main.ScreenToWorldPoint(screenPos);
                //createObj.transform.position = worldpos;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("左ポインターが押されました。");
                Debug.Log(mousePosition.x);
                m_SetGimmikBase = false;

            }

        }

        gameObject.transform.position = mousePosition;
    }
    public GameObject GetGimmickObject()
    {
        return m_obj.gameObject;
    }
}
