using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 花火クラス
/// </summary>
public class FireWork : MonoBehaviour
{
    [SerializeField] [Header("移動速度")][Range(0.0f,1.0f)] private float m_MoveSpeed;
    
    public void Rotate(Vector3 _Rotation)
    {
       transform.Rotate(_Rotation);
        Debug.Log(transform.rotation.eulerAngles);
    }
    private void Move()
    {
        transform.position += transform.up * m_MoveSpeed ;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this);
        }
    }
}
