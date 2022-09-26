using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 設置アイテムの親クラス
/// </summary>
public class GimmickBase : MonoBehaviour
{
    [SerializeField] [Header("表示するときにMinとMaxの間の数字が出ると表示")]private float m_ElectionMax, m_ElectionMin;
    [SerializeField] protected AudioSource m_Audio;
    [SerializeField] BoxCollider2D m_Collider;
    [SerializeField] SpriteRenderer m_Sprite;
    protected GimmickState m_GimmickState = GimmickState.BeforePlacement;
    private const float m_RotateAngle = 90.0f; //回転角
    private ElectionData m_ElectionData;
    protected bool m_IsPut = false;
    protected bool m_IsDestroy = false;
    /*to do どのプレイヤーの所有物か決める変数を設定する。*/

    IEnumerator DestroyForPlayer()
    {
        m_Collider.enabled = false;
        m_Audio.Play();
        yield return new WaitWhile(() => m_Audio.isPlaying);
        gameObject.SetActive(false);
        m_IsDestroy = true ;
        yield break;
    }
    /// <summary>
    /// ギミックの状態によって更新内容変更
    /// </summary>
    private void Update()
    {
        
        switch (m_GimmickState)
        {
            case GimmickState.BeforePlacement:
                SetUp();
                break;
            case GimmickState.Standby:
                Standby();
                break;
            case GimmickState.Playing:
                Run();
                break;
            case GimmickState.Played:
                Played();
                break;
        }
    }

    /// <summary>
    /// 設置時に重なってたら報告出来るようにする
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_GimmickState == GimmickState.Playing &&
            collision.gameObject.CompareTag("hammer"))
        {
            Debug.Log("hammer");
            m_IsDestroy = true;
        }
    }

    /// <summary>
    /// プレイヤーが設置する前の最初の処理
    /// </summary>
    protected virtual void SetUp() { }
    /// <summary>
    /// 子クラスはこの関数をoverrideして動作する
    /// </summary>
    protected virtual void Run() { }
    /// <summary>
    /// アクションシーンが終了したら呼んで
    /// </summary>
    protected virtual void Standby() {  }
    protected virtual void Played() { }
    /// <summary>
    /// 選出するときに参考にするデータ
    /// </summary>
    /// <returns></returns>
    public ElectionData ShowElectionData()
    {
        m_ElectionData.m_Max = m_ElectionMax;
        m_ElectionData.m_Min = m_ElectionMin;
        return m_ElectionData;
    }
    public void OnMouseEnter()
    {
        Debug.Log("あたった");
    }
    /// <summary>
    /// z軸で回転する
    /// </summary>
    public void PitchRotate()
    {
       transform.Rotate(new Vector3(0, 0, m_RotateAngle));
    }
    public void OnUpperOrHide(bool upper)
    {
        Color color = m_Sprite.color;
        if (upper)
        {
            color.a = 255;
            m_Sprite.color = color;
            m_Collider.enabled = true;
        }
        else
        {
            color.a = 0;
            m_Sprite.color = color;
            m_Collider.enabled = false;
        }
    }

    /// <summary>
    /// 呼ぶとギミックの状態が変わる
    /// </summary>
    public void ChangeState()
    {
        switch (m_GimmickState)
        {
            case GimmickState.BeforePlacement:
                //配置前の状態で呼ぶとスタンバイ
                m_GimmickState = GimmickState.Standby;

                break;
            case GimmickState.Standby:
                //スタンバイ状態で呼ぶとハンマーに破壊されるかチェック
                m_GimmickState = GimmickState.Playing;
                break;
            case GimmickState.Playing:
                //動いてる状態で呼ぶとスタンバイ
                m_GimmickState = GimmickState.Standby;
                break;
            case GimmickState.Played:
                m_GimmickState = GimmickState.Played;
                break;
        }
    }
    /// <summary>
    /// ハンマーが起動する前に
    /// このギミックが破壊されるかどうか所得
    /// </summary>
    public bool IsDestroy()
    {
        return m_IsDestroy;
    }
    /// <summary>
    /// 設置したときに呼んでね
    /// </summary>
    public void OnPut()
    {
        m_IsPut = true;
    }
    public bool IsPut()
    {
        return m_IsPut;
    }
}