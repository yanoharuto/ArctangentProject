using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/// <summary>
/// ギミックを選出しUIに表示　
/// </summary>
public class GimmickElection: MonoBehaviour
{
    [SerializeField] [Header("gimmick表示位置")]
    private List<Transform> m_DisplayPositions = new List<Transform>();
    [SerializeField] [Header("実装するGimmick")]
    private List<GimmickBase> m_GimmickList = new List<GimmickBase>();
    [SerializeField] [Header("二ターン目から表示するギミック群")]
    private List<GimmickBase> m_FirstIgnoreGimmickList = new List<GimmickBase>();
    private GimmickManager m_GimmickManager;
    /// <summary>
    /// Gimmickを表示する
    /// </summary>
    public void Election(bool _First)
    {
        var gimmickArray = _First ? m_GimmickList.ToArray() : m_GimmickList.Union<GimmickBase>(m_FirstIgnoreGimmickList);

        foreach (Transform pos in m_DisplayPositions)
        {
            int num = Random.Range(0, gimmickArray.ToArray().Length);
            //num番目にあったギミックを設置
            GameObject Gimmick = Instantiate(gimmickArray.ToArray()[num].gameObject);
            Gimmick.transform.position = pos.position;
            m_GimmickManager.AddElectionGimick(Gimmick.GetComponent<GimmickBase>());

        }
    }
    public void OnSetGimmickManager(GimmickManager _GimmickManager)
    {
        m_GimmickManager = _GimmickManager;
    }
}
