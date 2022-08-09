using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkLauncher : GimmickBase
{
    [SerializeField] [Header("発射間隔")] private float m_FireSpan;
    [SerializeField] [Header("発射する弾")] private GameObject m_Bullet;
    private float m_Time = 0.0f;

    /// <summary>
    /// 花火発射
    /// </summary>
    private void Fire()
    {
        Instantiate(m_Bullet);
    }

    /// <summary>
    /// スパン過ぎたら花火発射
    /// </summary>
    protected override void Run()
    {
        m_Time += Time.time;
        Debug.Log(m_Time);
        if (m_Time < m_FireSpan)
        {
            Fire();
            m_Time = 0.0f;
        }
    }
    /// <summary>
    /// 準備
    /// </summary>
    protected override void Standby()
    {
        m_Time = 0.0f;
    }

    protected override void SetUp()
    {
    }
}
