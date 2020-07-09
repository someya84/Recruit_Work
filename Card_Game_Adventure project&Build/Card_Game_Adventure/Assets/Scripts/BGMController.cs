using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    static BGMController instance;

    /// <summary>
    /// シングルトン化
    /// </summary>
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //checkWaveCountがtrueだったらBGMを消す処理
        if (GameManager.instance.checkWaveCount)
        {
            Destroy(gameObject);
        }
    }
}
