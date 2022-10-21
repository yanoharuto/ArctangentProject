using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 設置後のギミックに仕事をさせるよ
/// </summary>
public class GimmickManager : MonoBehaviour
{
    [SerializeField] private List<GimmickBase> m_ElectionGimmickList = new List<GimmickBase>();//選出したギミックリスト
    [SerializeField] private List<GimmickBase> m_PutedGimmickList = new List<GimmickBase>();//選出したギミックリスト
    [SerializeField] private List<GimmickBase> m_DestroyGimmickList = new List<GimmickBase>();
    /// <summary>
    /// ギミックを隠したりする
    /// </summary>
    /// <param name="mainState"></param>
    private void DisplayPutGimick(GimmickBase _Gimmick,MainState mainState)
    {
        switch (mainState)
        {
            case MainState.SelectGimmickPart:
                _Gimmick.OnUpperOrHide(false);
                break;
            case MainState.PutGimmickPart:
                _Gimmick.OnUpperOrHide(true);
                break;
            case MainState.PlayPart:
                _Gimmick.OnUpperOrHide(true);
                break;
            case MainState.ResultPart:
                _Gimmick.OnUpperOrHide(false);
                break;
        }
    }
    /// <summary>
    /// 設置前の表示しただけのギミックの更新
    /// </summary>
    public void UpdateElectionGimmick(MainState _MainState)
    {
        //破壊しないギミックのリスト
        List<GimmickBase> nonDestroyGimmick = new List<GimmickBase>();
        foreach (GimmickBase EGB in m_ElectionGimmickList)
        {
            if (!EGB.GetPrepareDestroyFlag())
            {
                //破壊しないギミックを登録
                nonDestroyGimmick.Add(EGB);
            }
            else
            {
                m_DestroyGimmickList.Add(EGB);
            }
            EGB.GimmickUpdate(_MainState);
        }
        //受け渡し。渡されなかったギミックは起動時に破壊される
        m_ElectionGimmickList = nonDestroyGimmick;
    }
    /// <summary>
    /// 設置後のギミックの更新
    /// </summary>
    public void UpdatePutGimmick(MainState _MainState)
    {
        //破壊しないギミックのリスト
        List<GimmickBase> nonDestroyGimmick = new List<GimmickBase>();
        foreach (GimmickBase PGB in m_PutedGimmickList)
        {
            if (!PGB.GetPrepareDestroyFlag())
            {
                //破壊しないギミックを登録
                nonDestroyGimmick.Add(PGB);
            }
            else
            {
                m_DestroyGimmickList.Add(PGB);
            }
            PGB.GimmickUpdate(_MainState);
            //ギミックを隠すよ
            DisplayPutGimick(PGB, _MainState);
        }
        //受け渡し。渡されなかったギミックは起動時に破壊される
        m_PutedGimmickList = nonDestroyGimmick;
    }
    /// <summary>
    /// 破壊予定のギミックを破壊する
    /// </summary>
    public void OnDestroyGimmick()
    {
        foreach(GimmickBase gimmick in m_DestroyGimmickList)
        {
            gimmick.SetSelfDestroy();
        }
        m_DestroyGimmickList.Clear();
    }
    /// <summary>
    /// ギミックを配置したときに使う
    /// </summary>
    /// <param name="gimmickBase"></param>
    public void AddPutedGimick(GimmickBase gimmickBase)
    {
        m_PutedGimmickList.Add(gimmickBase);
    }
    /// <summary>
    /// ギミックを選出させたときに使う
    /// ギミックのリストに追加するよ
    /// </summary>
    /// <param name="gimmickBase"></param>
    public void AddElectionGimick(GimmickBase gimmickBase)
    {
        m_ElectionGimmickList.Add(gimmickBase);
    }
}
