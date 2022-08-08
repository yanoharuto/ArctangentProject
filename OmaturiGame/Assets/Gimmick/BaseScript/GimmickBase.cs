using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 設置アイテムの親クラス
/// </summary>
public class GimmickBase : MonoBehaviour
{
    private const float RotateAngle = 90.0f;
    /*to do どのプレイヤーの所有物か決める変数を設定する。*/

    /// <summary>
    /// z軸で回転する
    /// </summary>
    public void PitchRotate()
    {
        transform.Rotate(new Vector3(0, 0, RotateAngle));
    }
    /// <summary>
    /// ハンマーにぶつかったら破壊する
    /// </summary>
    /// <param name="_CollisionObjTagName">ぶつかった物体のタグ名</param>
    protected void DestroyByHummer(string _CollisionObjTagName)
    {
        if(_CollisionObjTagName=="Hummer")
        {
           Destroy(this);
        }
    }
    /// <summary>
    /// 子クラスはこの関数をoverrideして動作する
    /// </summary>
    protected virtual void Run() 
    {

    }
}