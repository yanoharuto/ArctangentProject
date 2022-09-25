using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 設置アイテムの親クラス
/// </summary>
public class GimmickBase : MonoBehaviour
{
    [SerializeField] [Header("表示するときにMinとMaxの間の数字が出ると表示")]private float m_ElectionMax, m_ElectionMin;
    [SerializeField] [Header("回転させる物体")] private GameObject m_RotateObj;
    [SerializeField] [Header("ギミックの状態")] protected GimmickState m_GimmickState = GimmickState.BeforePlacement;
    private const float m_RotateAngle = 90.0f; //回転角
    private ElectionData m_ElectionData;

    protected bool m_IsOverlap = false;
    protected bool m_IsDestroy = false;
    /*to do どのプレイヤーの所有物か決める変数を設定する。*/
    public ElectionData ShowElectionData()
    {
        m_ElectionData.m_Max = m_ElectionMax;
        m_ElectionData.m_Min = m_ElectionMin;
        return m_ElectionData;
    }
    public void OnMouseEnter()
    {
        Debug.Log("あたった");
    }
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
    public void ChangeState()
    {
        switch (m_GimmickState)
        {
            case GimmickState.BeforePlacement:
                //配置前の状態で呼ぶとスタンバイ
                m_GimmickState = GimmickState.Standby;
                break;
            case GimmickState.Standby:
                //スタンバイ状態で呼ぶとハンマーに破壊されるかチェック
                m_GimmickState = GimmickState.HammerRun;
                break;
            case GimmickState.HammerRun:
                //破壊されなかったらそのまま動く
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
    /// ハンマーが起動する前に
    /// このギミックが破壊されるかどうか所得
    /// </summary>
    public bool IsDestroy()
    {
        return m_IsDestroy;
    }
    public void SetParent()
    {
        
    }
    /// <summary>
    /// プレイヤーが設置する前の最初の処理
    /// </summary>
    protected virtual void SetUp()
    {
    }
    /// <summary>
    /// 子クラスはこの関数をoverrideして動作する
    /// </summary>
    protected virtual void Run()
    {
    }
    /// <summary>
    /// ハンマーの処理
    /// </summary>
    protected virtual void HammerRun()
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
            case GimmickState.HammerRun:
                HammerRun();
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
        if(collision.gameObject.CompareTag("scaffold") ||
            collision.gameObject.CompareTag("dangerousObj") ||
            collision.gameObject.CompareTag("coin"))
        {
            m_IsOverlap = true;
        }
        if (m_GimmickState == GimmickState.HammerRun &&
            collision.gameObject.CompareTag("hammer")) 
        {
            m_IsDestroy = true;
        }
    }
    /// <summary>
    /// 重なりから外れたら
    /// </summary>
    /// 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "scaffold" ||
            collision.gameObject.tag == "dangerousObj" ||
            collision.gameObject.tag == "coin")
        {
            m_IsOverlap = false;
        }
    }

}