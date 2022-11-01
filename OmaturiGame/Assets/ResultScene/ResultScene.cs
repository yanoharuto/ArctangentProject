using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
    [SerializeField] private InputPlyer1 m_IPlayer1;
    [SerializeField] private GoNextScene m_NextScene;
    private GameObject onePObj; //1Pのゲームクリアのグラフィックのオブジェクト
    private GameObject twoPObj; //2Pのゲームクリアのグラフィックのオブジェクト
    private void Start()
    {
        onePObj = transform.GetChild(0).gameObject; //1Pのゲームクリアのグラフィックのオブジェクト
        twoPObj = transform.GetChild(1).gameObject; //2Pのゲームクリアのグラフィックのオブジェクト
        onePObj.SetActive(false); //1Pのゲームクリアのグラフィックのオブジェクトを非表示
        twoPObj.SetActive(false); //2Pのゲームクリアのグラフィックのオブジェクトを非表示
    }
    private void Update()
    {
        //if(onePObj == null) <----- ここでどちらが勝利したかどうかを調べる
        //{
        //    onePObj.SetActive(true); //1Pのゲームクリアのグラフィックのオブジェクトを表示
        //}
        //else
        //{
        //    twoPObj.SetActive(true); //2Pのゲームクリアのグラフィックのオブジェクトを表示
        //}
        InputParameter player1 = m_IPlayer1.GetInputParam();
        if (player1.m_BButton||player1.m_AButton)
        {
            m_NextScene.OnRun();
        }
    }
}
