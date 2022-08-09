using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkLauncher : GimmickBase
{
    [SerializeField] [Header("発射間隔")] private float m_FireSpan;
    [SerializeField] [Header("発射する弾")] private GameObject m_FireWork;
    private float m_Time = 0.0f;
    /// <summary>
    /// 花火発射
    /// </summary>
    private void Fire()
    {
        Debug.Log("Fire");
        FireWork fireWork = Instantiate(m_FireWork).GetComponent<FireWork>();
        fireWork.Rotate(transform.rotation.eulerAngles);
    }

    /// <summary>
    /// スパン過ぎたら花火発射
    /// </summary>
    protected override void Run()
    {
        m_Time += Time.deltaTime;
        if (m_FireSpan - m_Time < 0)
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
