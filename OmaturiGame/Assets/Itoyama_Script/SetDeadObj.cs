using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDeadObj : MonoBehaviour
{
    public int deadPlayerNum = 0;
    void OnBecameInvisible()
    {
        if (this.transform.position.y < -6.0)
        {
            deadPlayerNum++;
        }
    }

    public void Clear()
    {
        deadPlayerNum = 0;
    }
}
