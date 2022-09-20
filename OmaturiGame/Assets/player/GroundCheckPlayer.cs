using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckPlayer : MonoBehaviour
{
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;
    //毎フレーム呼ぶ
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGroundEnter = true;
        //Debug.Log("何かが判定に入りました");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGroundStay = true;
        //Debug.Log("何かが判定に入り続けています");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGroundExit = true;
        //Debug.Log("何かが判定をでました");
    }
}
