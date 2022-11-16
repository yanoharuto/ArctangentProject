using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridLine : MonoBehaviour
{
    [SerializeField] [Header("底辺,上辺")] Vector2 m_heightVec;
    [SerializeField][Header("左辺,右辺")] Vector2 m_widthVec;
    [SerializeField] [Header("マスの大きさ")] int m_gridSize;
    //座標データ
    List<GameObject> objects = new List<GameObject>();

    private Camera mainCamera;
    void Start()
    {
        if(m_gridSize==0)
        {
            m_gridSize = 64;
        }
        mainCamera = Camera.main;
        //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)));
        //縦ライン
        var widthnum = m_heightVec.y - m_heightVec.x;
        for (int i = 0; i < (widthnum/m_gridSize); i++)
        {
            GameObject obj = new GameObject();
            obj.name = "LineY" + i;
            LineRenderer renderer = obj.AddComponent<LineRenderer>();
            renderer.endColor = Color.white;
            // 線の幅
            renderer.SetWidth(0.02f, 0.02f);
            // 頂点の数
            renderer.SetVertexCount(2);

            
            // 頂点を設定
            renderer.SetPosition(0,mainCamera.ScreenToWorldPoint(new Vector3(m_widthVec.x, i*m_gridSize, 1)));
            renderer.SetPosition(1, mainCamera.ScreenToWorldPoint(new Vector3(m_widthVec.y, i * m_gridSize, 1)));
            objects.Add(obj);
            Debug.Log(obj);
        }

        var heightnum = m_widthVec.y - m_widthVec.x;
        //横ライン
        for (int i = 0; i < (heightnum/ m_gridSize); i++)
        {
            GameObject obj = new GameObject();
            obj.name = "LineX" + i;
            LineRenderer renderer = obj.AddComponent<LineRenderer>();
            renderer.endColor = Color.white;
            // 線の幅
            renderer.SetWidth(0.02f, 0.02f);
            // 頂点の数
            renderer.SetVertexCount(2);


            // 頂点を設定
            renderer.SetPosition(0, mainCamera.ScreenToWorldPoint(new Vector3(i * m_gridSize　+　m_widthVec.x   ,m_heightVec.x , 1)));
            renderer.SetPosition(1, mainCamera.ScreenToWorldPoint(new Vector3(i * m_gridSize　+ m_widthVec.x , m_heightVec.y, 1)));
            objects.Add(obj);
            Debug.Log(obj);
        }
        Debug.Log(objects.Count);

        //UnSetAllActive();
    }


    void Update()
    {
        
    }
    public void UnSetAllActive()
    {
        foreach(var obj in objects)
        {
            obj.SetActive(false);
        }
    }
    public void SetAllActive()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }

    }

}