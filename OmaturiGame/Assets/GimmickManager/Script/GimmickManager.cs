using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour,GiveGimmick
{
    private List<GimmickBase> GimmickBases = new List<GimmickBase>();

    public void ChangeGimmicksState()
    {
        foreach (GimmickBase GB in GimmickBases)
        {
            GB.ChangeGimmickState();
            GimmickBases.RemoveAll(null);
        }
    }

    public void RecieveGimmick(GimmickBase gimmickBase)
    {
        GimmickBases.Add(gimmickBase);
    }
    public void ClearGimmick()
    {
        GimmickBases.Clear();
    }
}

public interface GiveGimmick
{
    public void RecieveGimmick(GimmickBase gimmickBase);
}