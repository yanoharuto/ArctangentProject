using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go2GameScene : MonoBehaviour
{
    [SerializeField] string m_NextScene;

    public void OnClickGo2GameSceneButton()
    {
        SceneManager.LoadScene(m_NextScene);
    }
}
