using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ギミックの状態
/// </summary>
public enum GimmickState
{
    Standby, //アクションシーン以外なら待機状態
    Run,     //起動後の行動
    BeforePlacement//配置前
}