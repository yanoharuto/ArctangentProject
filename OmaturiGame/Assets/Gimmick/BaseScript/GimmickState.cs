using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ギミックの状態
/// </summary>
public enum GimmickState
{   
    BeforePlacement,//配置前
    Standby, //配置後　動く前の待機状態
    Playing,     //起動後
    Played,
}