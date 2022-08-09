using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 設置アイテムの親クラス
/// </summary>
public class GimmickBase : MonoBehaviour
{
    [SerializeField] [Header("回転させる物体")] private GameObject m_RotateObj;
    [SerializeField] [Header("ギミックの状態")]private GimmickState m_GimmickState = GimmickState.BeforePlacement;
    private const float m_RotateAngle = 90.0f; //回転角
    private bool m_IsOverlap = false;
    /*to do どのプレイヤーの所有物か決める変数を設定する。*/

   /* /// <summary>
    /// ハンマーにぶつかったら破壊する
    /// </summary>
    /// <param name="_ObjTagName">ぶつかった物体のタグ名</param>
    private void DestroyByHummer(string _ObjTagName)
    {
        if (_ObjTagName == "hammer")
        {
            Destroy(this);
        }
    }*/

    /// <summary>
    /// z軸で回転する
    /// </summary>
    public void PitchRotate()
    {
       m_RotateObj.transform.Rotate(new Vector3(0, 0, m_RotateAngle));
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
    /// オブジェクト同士が重なってるかどうか報告
    /// </summary>
    /// <returns></returns>
    public bool IsOverlapObject()
    {
        return m_IsOverlap;
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

    /// <summary>
    /// 設置時に重なってたら報告出来るようにする
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="scaffold"||
            collision.gameObject.tag=="dangerousObj"||
            collision.gameObject.tag=="coin")
        {
            m_IsOverlap = true;
        }
    }
    /// <summary>
    /// 重なりから外れたら
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "scaffold" ||
            collision.gameObject.tag == "dangerousObj"||
            collision.gameObject.tag == "coin")
        {
            m_IsOverlap = false;
        }
    }
   /* /// <summary>
    /// ゲーム開始前にハンマーと重なってたら破壊
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(m_GimmickState==GimmickState.Standby)
        {
            DestroyByHummer(collision.tag);
        }
    }*/
}