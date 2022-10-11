using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 設置アイテムの親クラス
/// </summary>
public class GimmickBase : MonoBehaviour
{
    [SerializeField] [Header("表示するときにMinとMaxの間の数字が出ると表示")]private float m_ElectionMax, m_ElectionMin;
    [SerializeField] protected BoxCollider2D m_Collider;
    [SerializeField] SpriteRenderer m_Sprite;
    protected GimmickPutState m_PutState = GimmickPutState.Select;
    private const float m_RotateAngle = 90.0f; //回転角
    private ElectionData m_ElectionData;
    protected bool m_IsOvarlap = false;
    protected bool m_IsDestroy = false;
    /*to do どのプレイヤーの所有物か決める変数を設定する。*/

    /// <summary>
    /// 設置時にハンマー以外が重なってたら報告出来るようにする
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameObject.CompareTag("hammer"))
        {
            m_IsOvarlap = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        m_IsOvarlap = false;
    }
    /// ハンマーが置かれたら自滅準備
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hammer"))
        {
            //設置後の自分自身が設置後のハンマーに当たっているなら自滅準備 
            if (m_PutState == GimmickPutState.FinishPut &&
                other.gameObject.GetComponent<Hammer>().GetPutState() == GimmickPutState.FinishPut) 
            {
                PreparingSelfDestruction();
            }
        }
    }
    /// <summary>
    /// 自滅準備
    /// 画像のアルファを下げて隠す
    /// 死ぬ予定フラグを立てる
    /// </summary>
    /// <returns></returns>
    protected void PreparingSelfDestruction()
    {
        m_Collider.enabled = false;
        OnUpperOrHide(false);
        m_IsDestroy = true;
    }
    /// <summary>
    /// 子クラスはこの関数をoverrideして動作する
    /// </summary>
    /// 設置前
    protected virtual void SelectUpdate() { }
    protected virtual void PutUpdate()
    {
        Debug.Log("PutUpdate");
        if (m_PutState == GimmickPutState.Select)
        {
            PreparingSelfDestruction();
        }
    }
    ///設置後　ハンマーが置いてあったら破壊
    protected virtual void OtherSelectUpdate() 
    {
        if (m_IsDestroy)
        {
            PreparingSelfDestruction();
        }
    }
    protected virtual void OtherPutUpdate() { }
    protected virtual void PlayUpdate() {  }
    protected virtual void ResultUpdate() { }
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
    /// <summary>
    /// z軸回転する
    /// </summary>
    /// <param name="_LRotate">反時計回りか</param>
    public void PitchRotate(bool _LRotate)
    {
        if (_LRotate)
        {
            transform.Rotate(new Vector3(0, 0, m_RotateAngle));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -m_RotateAngle));
        }
    }
    /// <summary>
    /// 見せたり隠したりする
    /// </summary>
    /// <param name="upper"></param>
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
    /// 設置状況の更新
    /// </summary>
    public void OnUpdatePutState()
    {
        switch(m_PutState)
        {
            case GimmickPutState.Select:
                m_PutState = GimmickPutState.Put;
                break;
            case GimmickPutState.Put:
                m_PutState = GimmickPutState.FinishPut;
                break;
        }
    }
    /// <summary>
    /// 設置状況の所得
    /// </summary>
    /// <returns></returns>
    public GimmickPutState GetPutState()
    {
        return m_PutState;
    }    /// <summary>
    /// メインの進捗状況によって更新内容を変える
    /// </summary>
    public void GimmickUpdate(MainState _MainState)
    {
        switch (_MainState)
        {
            case MainState.SelectGimmickPart:
                if (m_PutState == GimmickPutState.Select)
                {
                    //画面に表示されただけの状態
                    SelectUpdate();
                }
                else
                {
                    OtherSelectUpdate();
                }
                break;
            case MainState.PutGimmickPart:
                if (m_PutState == GimmickPutState.Put)
                {
                    //設置後のアプデ
                    OtherPutUpdate();
                }
                ///設置されることがないオブジェクトは破壊する
                else if (m_PutState == GimmickPutState.Select) 
                {
                    PreparingSelfDestruction();
                }
                else
                {
                    PutUpdate();
                }
                break;
            case MainState.PlayPart:
                PlayUpdate();
                break;
            case MainState.ResultPart:
                ResultUpdate();
                break;
        }
    }
    /// <summary>
    /// ギミック同士が重なり合っているかどうか
    /// </summary>
    /// <returns></returns>
    public bool GetOverLap()
    {
        return m_IsOvarlap;
    }
    /// <summary>
    /// 破壊されるかどうか渡す
    /// </summary>
    /// <returns></returns>
    public bool GetDestroyFlag()
    {
        return m_IsDestroy;
    }

}
