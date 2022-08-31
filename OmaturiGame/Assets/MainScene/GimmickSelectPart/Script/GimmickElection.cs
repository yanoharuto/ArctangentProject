using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ギミックを選出しUIに表示　
/// Mouseに触れられるようにする
/// </summary>
public class GimmickElection: MonoBehaviour
{
    [SerializeField] [Header("gimmick表示位置")]
    private List<Transform> m_DisplayPositions = new List<Transform>();
    [SerializeField] [Header("実装するGimmick")]
    private List<GimmickBase> m_GimmickList = new List<GimmickBase>();
    public void Election()
    {
        foreach (Transform pos in m_DisplayPositions)
        {
            foreach(GimmickBase gimmick in m_GimmickList)
            {
                ElectionData Data = gimmick.ShowElectionData();
                float num = Random.Range(1.0f, 101.0f);
                if (Data.m_Min < num && Data.m_Max > num)
                {
                    gimmick.SetPos(pos.position);
                }
            }
        }
    }
}
