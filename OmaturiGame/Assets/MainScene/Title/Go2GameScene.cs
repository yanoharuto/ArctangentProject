using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go2GameScene : MonoBehaviour
{
    [SerializeField] string m_NextScene;
    [SerializeField] GameObject m_TutorialObj;
    [SerializeField] AudioSource m_Audio;
    public void OnClickGo2GameSceneButton()
    {
        m_Audio.Play();
        SceneManager.LoadScene(m_NextScene);
    }
    public void OnPlayTutorial()
    {
        Instantiate(m_TutorialObj);
    }
}
