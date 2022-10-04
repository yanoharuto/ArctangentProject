using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScaffoldObserver : GimmickBase
{
    [SerializeField] [Header("目的地")] private Transform m_Destination;
    [SerializeField] private MoveScaffold m_MoveScaffold;
    private Vector3 m_StartPos;
    private bool m_FirstRun = false; private void OnCollisionEnter2D(Collision2D collision)
    {
        m_IsOvarlap = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        m_IsOvarlap = false;
    }
    /// <summary>
    /// プレイヤーが乗ったらLastPositionに向かって移動し,し終わったら戻る
    /// </summary>
    protected override void Run()
    {
        if (m_IsDestroy)
        {
            Destroy(this.gameObject);
        }
        if(!m_FirstRun)
        {
            m_FirstRun = true;
            m_StartPos = transform.position;
        }
        m_MoveScaffold.Run(m_Destination.position,m_StartPos);
    }
    /// <summary>
    /// 設置したときの最初の位置と状態にする
    /// </summary>
    protected override void Standby()
    {
        if (!m_IsPut)
        {
            Destroy(this.gameObject);
        }

        m_MoveScaffold.Standby();
    }

    protected override void Played()
    {
        m_MoveScaffold.Played(m_StartPos);
    }
}
