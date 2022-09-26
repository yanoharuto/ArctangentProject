using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : MonoBehaviour
{
    [SerializeField] private InputPlyer1 m_IPlayer1;
    [SerializeField] private GoNextScene m_NextScene;
    private void Update()
    {
        InputParameter player1 = m_IPlayer1.GetInputParam();
        if (player1.m_BButton||player1.m_AButton)
        {
            m_NextScene.OnRun();
        }
    }
}
