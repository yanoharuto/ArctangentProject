using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAButtonScript : MonoBehaviour
{
    GameObject titleObj;
    TitleAdministrator titleAdministrator;

    private float rad;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        rad = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        titleObj = GameObject.Find("ƒ^ƒCƒgƒ‹–¼");
        titleAdministrator = titleObj.GetComponent<TitleAdministrator>();
        if(!titleAdministrator.titleButtonTrriger)
        {
            rad += 0.001f;
            if(rad>2.0f)
            {
                rad = 0.0f;
            }
            this.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Abs(Mathf.Sin(rad * Mathf.PI));
        }
        else
        {
            this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        }
    }
}
