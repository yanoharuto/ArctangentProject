using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScaffoldObserver : GimmickBase
{
    [SerializeField] [Header("目的地")] private Transform m_Destination;
    [SerializeField] private MoveScaffold m_MoveScaffold;
    [SerializeField] private SpriteRenderer m_AllowSprite;
    private Vector3 m_StartPos;
    private bool m_FirstRun = false; 
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
        Debug.Log(collision.gameObject);
        TriggerEvenet(collision.gameObject);
    }
    public override void OnUpperOrHide(bool _upper)
    {
        Color color = m_Sprite.color;
        if (_upper)
        {
            color.a = 255;
            m_Collider.enabled = true;
        }
        else
        {
            color.a = 0;
            m_Collider.enabled = false;
        }
        m_Sprite.color = color;
        m_AllowSprite.color = color;
    }
    /// <summary>
    /// プレイヤーが乗ったらLastPositionに向かって移動し,し終わったら戻る
    /// </summary>
    protected override void OtherPutUpdate()
    {
        m_MoveScaffold.Standby();
    }
    /// <summary>
    /// 設置したときの最初の位置と状態にする
    /// </summary>
    protected override void PlayUpdate()
    {
        if (m_IsPrepareDestroy)
        {
            Destroy(this.gameObject);
        }
        if (!m_FirstRun)
        {
            m_FirstRun = true;
            m_StartPos = transform.position;
        }
        m_MoveScaffold.Run(m_Destination.position, m_StartPos);
    }

    protected override void ResultUpdate()
    {
        m_MoveScaffold.Played(m_StartPos);
    }
}
