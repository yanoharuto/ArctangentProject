using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go2GameScene : MonoBehaviour
{
    [SerializeField] string m_NextScene;
    [SerializeField] GameObject m_TutorialObj;
    [SerializeField] [Header("チュートリアルとPlayGameのSE")] List<AudioSource> m_Audios = new List<AudioSource>();
    public void OnClickGo2GameSceneButton()
    {
        m_Audios[0].Play();
        SceneManager.LoadScene(m_NextScene);
    }
    public void OnPlayTutorial()
    {
        m_Audios[1].Play();
        Instantiate(m_TutorialObj);
    }
}
