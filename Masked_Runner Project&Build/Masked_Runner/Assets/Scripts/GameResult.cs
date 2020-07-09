using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    public Text GameResultText;
    public Button ResultButton;
    

    void Start()
    {
        GameResultText.enabled = false;
        ResultButton.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameResultText.enabled = true;
            ResultButton.gameObject.SetActive(true);

            GameResultText.text = "GameClear";
            
        }
    }

    
}
