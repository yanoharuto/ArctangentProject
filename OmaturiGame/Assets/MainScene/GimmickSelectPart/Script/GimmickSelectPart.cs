using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickSelectPart : MonoBehaviour
{   
    [SerializeField] private GimmickElection m_GElection;
    private int m_SelectGimmickNum = 0;
    private GimmickManager m_GManager;

    private void Start()
    {
        m_GManager = this.gameObject.AddComponent<GimmickManager>();
    }
    /// <summary>
    /// 設置するギミックをマネージャーのリストに追加
    /// </summary>
    /// <param name="AddGimmick"></param>
    public void RecieveGimmick(GimmickBase AddGimmick)
    {
        m_SelectGimmickNum++;
        m_GManager.AddGimmick(AddGimmick);
    }
    /// <summary>
    /// ギミックを二つ設置したかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsGimmickSelect()
    {
        if (m_SelectGimmickNum == 2)
        {
            m_SelectGimmickNum = 0;
            return true;
        }
        return false;
    }
    public void ChangeGimmicksState()
    {
        m_GManager.ChangeProcess();
    }
    /// <summary>
    /// プレイヤーが選択するギミックを選出
    /// </summary>
    public void ElectionBeforePlacementGimmick()
    {
        m_GElection.Election();
    }
}
