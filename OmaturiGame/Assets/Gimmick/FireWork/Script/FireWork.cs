using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 花火クラス
/// </summary>
public class FireWork : MonoBehaviour
{
    [SerializeField] [Header("移動速度")][Range(1.0f,100.0f)] private float m_MoveSpeed;
    private bool m_MoveFlag;
    public void SetRotateAndPosition(Vector3 _Position,Vector3 _Rotation)
    {
        transform.Rotate(_Rotation);
        transform.position = _Position;
    }
    private void Move()
    {
        transform.position += transform.up * m_MoveSpeed * Time.deltaTime;
    }
    private void SetMove()
    {
        m_MoveFlag = true;
    }
    private void Update()
    {
        if (m_MoveFlag)
        {
            Move();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this);
        }
    }
    /// <summary>
    /// 見えなくなったら消す
    /// </summary>
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}