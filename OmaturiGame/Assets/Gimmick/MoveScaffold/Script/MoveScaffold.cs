using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動床
/// </summary>
public class MoveScaffold : MonoBehaviour
{
    [SerializeField] [Header("移動床の状態")] private MoveScaffoldState m_MoveScaffoldState = MoveScaffoldState.Wait;
    private GameObject m_Destination;
    private Vector3 m_MoveValue;
    private float m_StopTime;

    public void Standby(Vector3 _startPos)
    {
        transform.position = _startPos;
        m_MoveScaffoldState = MoveScaffoldState.Wait;
    }
    public void Run()
    {
        switch (m_MoveScaffoldState)
        {
            case MoveScaffoldState.Wait:
                break;
            case MoveScaffoldState.Move:
                Move(m_MoveValue);
                break;
            case MoveScaffoldState.Return:

                Move(-m_MoveValue);
                break;
            case MoveScaffoldState.Stop:

                break;
        }
    }
    /// <summary>
    /// 停止状態になってからStopTimeまで待って戻るコルーチン
    /// </summary>
    IEnumerator StopScaffold(float _stopTime)
    {
        m_MoveScaffoldState = MoveScaffoldState.Stop;
        yield return new WaitForSeconds(_stopTime);
        m_MoveScaffoldState = MoveScaffoldState.Return; 
        Debug.Log("Return");
        yield break;
    }
    /// <summary>
    /// 移動や止まるときに必要なパラメーターをもらう
    /// </summary>
    /// <param name="_stopTime"></param>
    /// <param name="_moveSpeed"></param>
    /// <param name="_destination"></param>
    public void SetMoveParameter(float _stopTime, float _moveSpeed, GameObject _destination)
    {
        m_StopTime = _stopTime;
        m_Destination = _destination;
        m_MoveValue = (_destination.transform.position - transform.position).normalized * _moveSpeed ;
    }
    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="_moveValue">移動量</param>
    private void Move(Vector3 _moveValue)
    {
        transform.position += _moveValue;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (m_MoveScaffoldState == MoveScaffoldState.Wait)
            {
                m_MoveScaffoldState = MoveScaffoldState.Move;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject == m_Destination &&
            m_MoveScaffoldState == MoveScaffoldState.Move))
        {
            m_MoveScaffoldState = MoveScaffoldState.Stop;
            StartCoroutine("StopScaffold", m_StopTime);
        }
        else if (collision.gameObject == transform.parent.gameObject &&
             m_MoveScaffoldState == MoveScaffoldState.Return)
        {
            Debug.Log("Moveend");
            m_MoveScaffoldState = MoveScaffoldState.Wait;
        }
    }
}
