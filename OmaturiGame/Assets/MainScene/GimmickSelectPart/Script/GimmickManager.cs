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
    /// <summary>
    /// 呼ぶたびに設置したオブジェクトの状態を遷移
    /// </summary>
    public void ChangeElectionGimmickState()
    {

        foreach (GimmickBase EGB in m_ElectionGimmickList)
        {
            EGB.ChangeState();
        }

        //配置されなかった奴は消す
        m_ElectionGimmickList.Clear();
    }
    public void ChangePutedGimmickState()
    {
        //破壊しないギミックのリスト
        List<GimmickBase> NonDestroyGimmick = new List<GimmickBase>();
        foreach (GimmickBase PGB in m_PutedGimmickList)
        {
            if (!PGB.IsDestroy())
            {
                //破壊しないギミックを登録
                NonDestroyGimmick.Add(PGB);
            }
            PGB.ChangeState();
        }
        //受け渡し。渡されなかったギミックは起動時に破壊される
        m_PutedGimmickList = NonDestroyGimmick;
    }
    public void HidePutedGimick(MainState mainState)
    {
        foreach(GimmickBase PGB in m_PutedGimmickList)
        {
            switch(mainState)
            {
                case MainState.SelectGimmickPart:
                    PGB.OnUpperOrHide(false);
                    break;
                case MainState.PutGimmickPart:
                    PGB.OnUpperOrHide(true);
                    break;
                case MainState.PlayPart:
                    PGB.OnUpperOrHide(true);
                    break;
                case MainState.ResultPart:
                    PGB.OnUpperOrHide(false);
                    break;
            }
        }
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