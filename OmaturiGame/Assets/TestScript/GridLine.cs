using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridLine : MonoBehaviour
{

    //�c�̃|�C���g��1080/64
    private const int HightGridNumber = 17;
    //���̃|�C���g��1920/64
    private const int WidthGridNumber =11;

    //���W�f�[�^
    List<GameObject> objects = new List<GameObject>();

    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
        //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)));
        //�c���C��
        for (int i = 0; i < HightGridNumber; i++)
        {
            GameObject obj = new GameObject();
            obj.name = "LineY" + i;
            LineRenderer renderer = obj.AddComponent<LineRenderer>();
            // ���̕�
            renderer.SetWidth(0.02f, 0.02f);
            // ���_�̐�
            renderer.SetVertexCount(2);

            
            // ���_��ݒ�
            renderer.SetPosition(0,mainCamera.ScreenToWorldPoint(new Vector3(640, i*64, 1)));
            renderer.SetPosition(1, mainCamera.ScreenToWorldPoint(new Vector3(1280, i * 64, 1)));
            objects.Add(obj);
            Debug.Log(i);
        }


        //�����C��
        for (int i = 0; i < WidthGridNumber; i++)
        {
            GameObject obj = new GameObject();
            obj.name = "LineX" + i;
            LineRenderer renderer = obj.AddComponent<LineRenderer>();
            // ���̕�
            renderer.SetWidth(0.02f, 0.02f);
            // ���_�̐�
            renderer.SetVertexCount(2);


            // ���_��ݒ�
            renderer.SetPosition(0, mainCamera.ScreenToWorldPoint(new Vector3(i * 64�@+�@640   ,0   , 1)));
            renderer.SetPosition(1, mainCamera.ScreenToWorldPoint(new Vector3(i * 64�@+�@640�@,1080, 1)));
            objects.Add(obj);
            Debug.Log(i);
        }
    }


    void Update()
    {
        
    }
}