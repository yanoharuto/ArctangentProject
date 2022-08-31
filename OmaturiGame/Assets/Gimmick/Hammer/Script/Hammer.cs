using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// hammerのタグが付いたオブジェクトに大きめの当たり判定をつければ
/// その当たり判定に当たったギミックはDestroy
/// こいつも消える
/// </summary>
public class Hammer : GimmickBase
{
    protected override void SetUp()
    { 
    }
    protected override void Standby()
    {      
        m_IsDestroy = true;
    }
    protected override void HammerRun()
    {
        //後でアニメーションとか入れるかもね
    }  
    protected override void Run()
    {
        if(m_IsDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}