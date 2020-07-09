using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void OnGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
