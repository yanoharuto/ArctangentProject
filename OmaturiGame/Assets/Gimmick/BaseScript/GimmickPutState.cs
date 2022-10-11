using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ギミックの状態
/// </summary>
public enum GimmickPutState
{   
    Select,//配置前
    Put,   //配置先考え中
    FinishPut//配置後
}