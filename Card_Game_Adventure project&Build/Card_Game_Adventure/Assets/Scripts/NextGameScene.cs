using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextGameScene : MonoBehaviour
{
    public void LoadToBattleScene()
    {
        SceneManager.LoadScene("BattleScene");
    }

    public void LoadToHowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void LoadToTitle()
    {
        GameManager.instance.checkWaveCount = true;
        SceneManager.LoadScene("TitleScene");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
