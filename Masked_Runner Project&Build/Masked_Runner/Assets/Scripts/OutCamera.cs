using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutCamera : MonoBehaviour
{
    [SerializeField] private int m_Speed = 6;
    public Text GameResult;
    [SerializeField] private Button ReturnButton;

    // Start is called before the first frame update
    void Start()
    {
        GameResult.enabled = false;
        ReturnButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(m_Speed * Time.deltaTime, 0, 0);
        if (this.transform.position.x >= 430)
        {
            m_Speed = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GameOver");

            GameResult.enabled = true;
            ReturnButton.gameObject.SetActive(true);
            GameResult.color = new Color(255.0f, 0f, 0f, 1.0f);
            GameResult.text = "GameOver";
            FindObjectOfType<CameraController>().UnMove(0);
        }
    }
}
