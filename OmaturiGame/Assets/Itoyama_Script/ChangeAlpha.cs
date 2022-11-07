using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ChangeAlpha : MonoBehaviour
{
    [SerializeField] [Tooltip("完全表示までの時間")] private float fadeTime = 1.0f;
    private float timer = 0;

    GameObject titleObj;
    TitleAdministrator titleAdministrator;
    void Start()
    {
        this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
    }

    void Update()
    {
        titleObj = GameObject.Find("タイトル名");
        titleAdministrator=titleObj.GetComponent<TitleAdministrator>();
        if(titleAdministrator.titleButtonTrriger)
        {
            timer += Time.deltaTime;
            this.gameObject.GetComponent<CanvasGroup>().alpha = timer / fadeTime;
        }
    }
}
