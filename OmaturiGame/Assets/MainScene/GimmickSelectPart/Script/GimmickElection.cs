using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ギミックを選出しUIに表示　
/// </summary>
public class GimmickElection: MonoBehaviour
{
    [SerializeField] [Header("gimmick表示位置")]
    private List<Transform> m_DisplayPositions = new List<Transform>();
    [SerializeField] [Header("実装するGimmick")]
    private List<GimmickBase> m_GimmickList = new List<GimmickBase>();
    private GimmickManager m_GimmickManager;
    /// <summary>
    /// Gimmickを表示する
    /// </summary>
    public void Election()
    {
        foreach (Transform pos in m_DisplayPositions)
        {
            //ギミックに設定されたキーをランダムに生成
            float num = Random.Range(1.0f, 101.0f);
            //numに該当するオブジェクトを検索
            foreach (GimmickBase gimmick in m_GimmickList)
            {
                //ギミックに設定された数値を参照
                ElectionData Data = gimmick.ShowElectionData();
           
                if (Data.m_Min < num && Data.m_Max > num)
                {
                    //数値内なら真、ギミックを生成してポジションに置く
                    GameObject Gimmick = Instantiate(gimmick.gameObject);
                    Gimmick.transform.position = pos.position;
                    m_GimmickManager.AddElectionGimick(Gimmick.GetComponent<GimmickBase>());
                }
            }
        }
    }
    public void OnSetGimmickManager(GimmickManager _GimmickManager)
    {
        m_GimmickManager = _GimmickManager;
    }
}
