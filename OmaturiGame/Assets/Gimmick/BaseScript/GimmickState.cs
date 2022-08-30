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
    Hammer,  //ハンマーの行動
    Run,     //起動後
}