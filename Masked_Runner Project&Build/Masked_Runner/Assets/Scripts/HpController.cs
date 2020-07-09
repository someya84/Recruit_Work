using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    [HideInInspector] private int hp = 3;
    public GameObject Heart;
    public GameObject Heart1;
    public GameObject Heart2;
    public Text GameResult;
    [SerializeField] public GameObject ReturnButton;

    private void Start()
    {
        GameResult.enabled = false;
        ReturnButton.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            hp--;
            switch (hp)
            {
                case 2:
                    Destroy(Heart2);
                    break;

                case 1:
                    Destroy(Heart1);
                    break;

                case 0:
                    Destroy(Heart);
                    GameResult.enabled = true;
                    ReturnButton.SetActive(false);
                    GameResult.color = new Color(255.0f, 0f, 0f,1.0f);
                    GameResult.text = "GameOver";
                    Destroy(this.gameObject);
                    FindObjectOfType<CameraController>().UnMove(0);
                    break;

            }

        }
    }
}
