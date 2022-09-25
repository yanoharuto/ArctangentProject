using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動床
/// </summary>
public class MoveScaffold : MonoBehaviour
{
    [SerializeField] [Header("終着点で止まってから何秒経って動くか")] private float m_StopTime;
    [SerializeField] [Header("移動時間")] private float m_MoveTime;
    private MoveScaffoldState m_MoveScaffoldState = MoveScaffoldState.PlayerWait;
    private float m_RemainingMoveTime = 0;
    /// <summary>
    /// 停止状態になってからStopTimeまで待って戻るコルーチン
    /// </summary>
    IEnumerator Stop(float _stopTime)
    {
        m_MoveScaffoldState = MoveScaffoldState.Stop;
        yield return new WaitForSeconds(_stopTime);
        m_MoveScaffoldState = MoveScaffoldState.Return;
        yield break;
    }
    /// <summary>
    /// 移動するよ　移動時間過ぎたら止まるよ
    /// </summary>
    private void Move(Vector3 moveVec)
    {
        transform.position += moveVec;
        m_RemainingMoveTime -= Time.deltaTime;
        if (m_RemainingMoveTime < 0) 
        {
            switch(m_MoveScaffoldState)
            {
                case MoveScaffoldState.Move:
                    m_MoveScaffoldState = MoveScaffoldState.Stop;
                    break;

                case MoveScaffoldState.Return:
                    m_MoveScaffoldState = MoveScaffoldState.PlayerWait;
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (m_MoveScaffoldState == MoveScaffoldState.PlayerWait)
            {
                m_MoveScaffoldState = MoveScaffoldState.Move;
            }
        }
    }
    /// <summary>
    /// 現在の移動床の状態
    /// </summary>
    /// <returns></returns>
    public MoveScaffoldState GetMoveState()
    {
        return m_MoveScaffoldState;
    }
    /// <summary>
    /// ラウンドが終わったら戻してね
    /// </summary>
    /// <param name="_startPos"></param>
    public void Standby(Vector3 _startPos)
    {
        transform.position = _startPos;
        m_MoveScaffoldState = MoveScaffoldState.PlayerWait;
    }
    /// <summary>
    /// 足場の状態によってやることが変わる
    /// </summary>
    /// <param name="destination">移動量</param>
    /// <param name="stopTime">動いた後この時間分止まる</param>
    /// <param name="moveTime">この時間分動く</param>
    public void Run(Vector3 destination)
    {
        Vector3 moveVec = destination - transform.position;
        moveVec = moveVec.normalized;
        switch (m_MoveScaffoldState)
        {
            case MoveScaffoldState.PlayerWait:
                m_RemainingMoveTime = m_MoveTime;
                break;
            case MoveScaffoldState.Move:
                Move(moveVec);
                break;

            case MoveScaffoldState.Stop:
                StartCoroutine("Stop",m_StopTime);
                m_RemainingMoveTime = m_MoveTime;
                break;
            case MoveScaffoldState.Return:
                Move(moveVec);
                break;
        }
    }


}
