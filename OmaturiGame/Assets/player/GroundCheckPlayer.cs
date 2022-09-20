using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckPlayer : MonoBehaviour
{
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;
    //–ˆƒtƒŒ[ƒ€ŒÄ‚Ô
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
        //Debug.Log("‰½‚©‚ª”»’è‚É“ü‚è‚Ü‚µ‚½");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGroundStay = true;
        //Debug.Log("‰½‚©‚ª”»’è‚É“ü‚è‘±‚¯‚Ä‚¢‚Ü‚·");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGroundExit = true;
        //Debug.Log("‰½‚©‚ª”»’è‚ğ‚Å‚Ü‚µ‚½");
    }
}
