using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    
    [SerializeField] [Header("設置可能ギミック")] private　GameObject m_obj;
    //ギミックは正常にセットされているか
    bool m_SetGimmikBase=false;
    GameObject createObj;
    // Start is called before the first frame update
    void Start()
    {
        if(m_obj.GetComponent<GimmickBase>())
        {
            Debug.Log("GB1　正常");
            m_SetGimmikBase = true;
            createObj= Instantiate(m_obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            createObj.name = "ギミック";
        }
        else
        {
            Debug.Log("GB1  異常");
        }


    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Input.mousePosition;
        //グリッド線の範囲内にマウスポインタが存在している場合
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
                Debug.Log("左ポインターが押されました。");
                Debug.Log(mousePosition.x);
                m_SetGimmikBase = false;
            }

        }

        gameObject.transform.position = mousePosition;

       

    }
}
