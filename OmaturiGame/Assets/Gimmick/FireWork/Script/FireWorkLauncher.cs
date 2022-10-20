using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkLauncher : GimmickBase
{
    [SerializeField] [Header("発射間隔")] private float m_FireSpan;
    [SerializeField] [Header("発射する弾")] private GameObject m_FireWork;
    private float m_Time = 0.0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_IsOvarlap = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        m_IsOvarlap = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        TriggerEvenet(collision.gameObject);
    }
    /// <summary>
    /// 花火発射
    /// </summary>
    private void Fire()
    {
        FireWork fireWork = Instantiate(m_FireWork).GetComponent<FireWork>();
        fireWork.SetRotateAndPosition(transform.position,transform.rotation.eulerAngles);
    }
    private void PrepareFire()
    {
        m_Time += Time.deltaTime;
        if (m_FireSpan - m_Time < 0)
        {
            Fire();
            m_Time = 0.0f;
        }
    }

    protected override void PlayUpdate()
    {
        PrepareFire();
    }
}
