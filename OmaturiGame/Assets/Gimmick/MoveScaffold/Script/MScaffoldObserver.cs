using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MScaffoldObserver : GimmickBase
{
    [SerializeField] [Header("移動するオブジェクト")] private GameObject m_MoveObj;
    [SerializeField] [Header("移動速度")] private float m_MoveSpeed;
    [SerializeField] [Header("目的地")] private GameObject m_Destination;
    [SerializeField] [Header("終着点で止まってから何秒経って動くか")] private float m_StopTime;
    private MoveScaffold m_MoveScaffold;

    private void Start()
    {
        m_MoveScaffold = m_MoveObj.GetComponent<MoveScaffold>();
        m_MoveScaffold.SetMoveParameter(m_StopTime, m_MoveSpeed, m_Destination);
    }
    /// <summary>
    /// ゲーム開始時に呼んでもらう
    /// </summary>
    protected override void SetUp()
    {

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
        m_MoveScaffold.Run();
    }
    /// <summary>
    /// 設置したときの最初の状態にする
    /// </summary>
    protected override void Standby()
    {
        m_MoveScaffold.Standby(transform.position);
    }
}
