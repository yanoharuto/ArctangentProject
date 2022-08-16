using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動床
/// </summary>
public class MoveScaffold : GimmickBase
{
    [SerializeField] [Header("移動速度")] private float m_MoveSpeed;
    [SerializeField] [Header("終着点")] private Transform m_LastPosObj;
    [SerializeField] [Header("終着点で止まってから何秒経って動くか")] private float m_StopTime;
    [SerializeField] [Header("動く床のRigidBody")] private Rigidbody2D m_RigidBody2D;
    private MoveScaffoldState m_MoveScaffoldState = MoveScaffoldState.Wait;   //移動床の状態
    private Vector3 m_StartPosition;                                          //初期位置
    
    /// <summary>
    /// 設置したときの位置
    /// </summary>
    private void SetStartPos()
    {
        m_StartPosition = transform.position;
    }
    /// <summary>
    /// 停止状態になってからStopTimeまで待って戻る
    /// </summary>
    IEnumerator StopScaffold()
    {
        m_MoveScaffoldState = MoveScaffoldState.Stop;
        yield return new WaitForSeconds(m_StopTime);
        m_MoveScaffoldState = MoveScaffoldState.Return;
    }
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        if (m_MoveScaffoldState == MoveScaffoldState.Move)
        {
            transform.position += (m_LastPosObj.position - transform.position).normalized * m_MoveSpeed ;
            if (transform.position == m_LastPosObj.position) 
            {
                m_MoveScaffoldState = MoveScaffoldState.Stop;
            }
        }
        else if (m_MoveScaffoldState == MoveScaffoldState.Return)
        {
            transform.position += (m_StartPosition - transform.position).normalized * m_MoveSpeed;
            if (transform.position == m_StartPosition) 
            {
                m_MoveScaffoldState = MoveScaffoldState.Wait;
            }
        }
    }
    /// <summary>
    /// ゲーム開始時に呼んでもらう
    /// </summary>
    protected override void SetUp()
    {
        SetStartPos();
    }

    /// <summary>
    /// 設置したときの最初の状態にする
    /// </summary>
    protected override void Standby()
    {
        transform.position = m_StartPosition;
        m_MoveScaffoldState = MoveScaffoldState.Stop;
    }
    /// <summary>
    /// プレイヤーが乗ったらLastPositionに向かって移動し,し終わったら戻る
    /// </summary>
    protected override  void Run()
    {
        //移動
        if (m_MoveScaffoldState == MoveScaffoldState.Move ||
            m_MoveScaffoldState == MoveScaffoldState.Return)
        {
            Move();
        }
        //停止
        else if (m_MoveScaffoldState == MoveScaffoldState.Stop) 
        {
            StartCoroutine("StopScaffold");
        }
        Debug.Log(m_MoveScaffoldState);
    }
    /// <summary>
    /// プレイヤーが乗って待機中なら移動
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            if (m_MoveScaffoldState == MoveScaffoldState.Wait)
            {
                m_MoveScaffoldState = MoveScaffoldState.Move;
            }
        }
    }
}
