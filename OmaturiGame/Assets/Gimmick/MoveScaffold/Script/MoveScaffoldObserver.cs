using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScaffoldObserver : GimmickBase
{
    [SerializeField] [Header("目的地")] private Transform m_Destination;
    [SerializeField] private MoveScaffold m_MoveScaffold;
    private Vector3 m_StartPos;
    /// <summary>
    /// ゲーム開始時に呼んでもらう
    /// </summary>
    protected override void SetUp()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    protected override void HammerRun()
    {
        m_StartPos = transform.position;
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
        switch (m_MoveScaffold.GetMoveState())
        {
            case MoveScaffoldState.PlayerWait:
                m_MoveScaffold.Run(m_Destination.position);
                break;
            case MoveScaffoldState.Move:
                m_MoveScaffold.Run(m_Destination.position);
                break;
            case MoveScaffoldState.Stop:
                m_MoveScaffold.Run(m_StartPos);
                break;
            case MoveScaffoldState.Return:
                m_MoveScaffold.Run(m_StartPos);
                break;
        }
    }
    /// <summary>
    /// 設置したときの最初の位置と状態にする
    /// </summary>
    protected override void Standby()
    {
        m_MoveScaffold.Standby(m_StartPos);
    }
}
