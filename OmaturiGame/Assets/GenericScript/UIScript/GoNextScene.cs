using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextScene : UIBase
{
    [Header("次のシーンの名前をください")]
    [SerializeField] private string m_NextScene;
    [SerializeField] [Header("フェードアウトのためのオブジェクト")]private GameObject m_FadeOutObj;
    /// <summary>
    /// 効果音を鳴らして次のシーンに行く
    /// </summary>
    override public void OnRun()
    {
        m_Audios.Play();
        StartCoroutine("SceneChange");
    }

    IEnumerator SceneChange()
    {
        //フェードアウトするためのオブジェクトを設置
        Instantiate(m_FadeOutObj);
        //SE終了まで待つ
        yield return new WaitWhile(() => m_Audios.isPlaying) ;
        SceneManager.LoadScene(m_NextScene);
        yield break;
    }
}
