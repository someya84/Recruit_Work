using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] Button RankingButton;
    [SerializeField] Button ConectButton;
    [SerializeField] Button RetryButton;
    
    void Start()
    {
        RankingButton.gameObject.SetActive(false);
        ConectButton.gameObject.SetActive(true);
        RetryButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRankingButton()
    {
        RankingButton.gameObject.SetActive(true);
        ConectButton.gameObject.SetActive(false);
        RetryButton.gameObject.SetActive(true);
    }
}
