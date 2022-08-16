using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 動く床の状態
/// </summary>
public enum MoveScaffoldState
{
    Move,//移動中
    Wait,//乗り込み待ち
    Stop,//停止中
    Return//元の位置に戻ってる
}
