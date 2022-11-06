using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleNameExit : MonoBehaviour
{
    void OnCollisionExit(Collision other)
    {
        TitleAdministrator::SetTriggerTrue();
    }
}
