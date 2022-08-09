using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 設置アイテムの親クラス
/// </summary>
public class GimmickBase : MonoBehaviour
{
    [SerializeField] [Header("回転させる物体")] private GameObject m_RotateObj;
    private const float m_RotateAngle = 90.0f; //回転角
    protected bool m_IsAfterDeployment = false;//設置したかどうか
    /*to do どのプレイヤーの所有物か決める変数を設定する。*/

    /// <summary>
    /// プレイヤーが設置したら呼んでもらう
    /// </summary>
    public void SetUp()
    {
        m_IsAfterDeployment = true;
    }
    /// <summary>
    /// z軸で回転する
    /// </summary>
    public void PitchRotate()
    {
       m_RotateObj.transform.Rotate(new Vector3(0, 0, m_RotateAngle));
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
    /// <summary>
    /// メインシーン終了時に元に戻しておきたいことを書く
    /// </summary>
    protected virtual void ResetState()
    {

    }

}