using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyMove : MonoBehaviour
{
    Vector2 vector2 = new Vector2();
    float rad;
    // Start is called before the first frame update
    void Start()
    {
        vector2 = this.transform.position;
        rad = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        rad += 0.0005f;
        if (rad > 2.0f)
        {
            rad = 0.0f;
        }
        Vector2 oval = new Vector2();
        Vector2 setPos = new Vector2();
        oval.x = (Mathf.Cos(rad * Mathf.PI)) * 0.3f;
        oval.y = -Mathf.Abs((Mathf.Sin(rad * Mathf.PI)) * 0.1f);
        setPos = vector2;
        setPos += oval;
        this.transform.position = setPos;
    }
}
