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
    private GimmickState m_GimmickState = GimmickState.BeforePlacement;
    /*to do どのプレイヤーの所有物か決める変数を設定する。*/

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
    /// プレイヤーが設置したら呼んでもらう
    /// </summary>
    protected virtual void SetUp()
    {
    }
    /// <summary>
    /// アクションシーンが終了したら呼んで
    /// </summary>
    protected virtual void Standby()
    {
    }
    /// <summary>
    /// 呼ぶとギミックの状態が変わる
    /// </summary>
    public void ChangeGimmickState()
    {
        switch (m_GimmickState)
        {
            case GimmickState.BeforePlacement:
                //配置前の状態で呼ぶとスタンバイ
                m_GimmickState = GimmickState.Standby;
                break;
            case GimmickState.Standby:
                //スタンバイ状態で呼ぶと動く
                m_GimmickState = GimmickState.Run;
                break;
            case GimmickState.Run:
                //動いてる状態で呼ぶとスタンバイ
                m_GimmickState = GimmickState.Standby;
                break;
        }
    }
    /// <summary>
    /// ギミックの状態によって更新内容変更
    /// </summary>
    private void Update()
    {
        switch(m_GimmickState)
        {
            case GimmickState.BeforePlacement:
                SetUp();
                break;
            case GimmickState.Standby:
                Standby();
                break;
            case GimmickState.Run:
                Run();
                break;
        }
    }
}