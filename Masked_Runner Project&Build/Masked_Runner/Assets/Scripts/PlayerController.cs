using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_Speed = 3;
    [SerializeField] private float m_JampPower = 700;
    [SerializeField] private GameObject rabbitMask;
    [SerializeField] private GameObject birdMask;
    [SerializeField] private GameObject JumpSymbol;
    [SerializeField] private GameObject JumpSymbol1;
    [SerializeField] private GameObject JumpSymbol2;
    [SerializeField] private GameObject JumpSymbol3;
    Rigidbody rg;
    private bool jumpingFlug = true;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rabbitMask.SetActive(false);
        birdMask.SetActive(false);
        JumpSymbol.SetActive(false);
        JumpSymbol1.SetActive(false);
        JumpSymbol2.SetActive(false);
        JumpSymbol3.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(m_Speed * Time.deltaTime, 0, 0);

        Jumping();

        if(this.transform.position.x >= 445)
        {
            m_Speed = 0;
        }
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpingFlug == true)
        {
            jumpingFlug = false;
            rg.AddForce(transform.up * m_JampPower);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpingFlug = true;
        }

        if (collision.gameObject.CompareTag("GameClear"))
        {
            Debug.Log("hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RabbitMask"))
        {
            rabbitMask.SetActive(true);
            m_JampPower *= 1.3f;
            Invoke("OffRabbitMask", 10);
        }

        if (other.gameObject.CompareTag("BirdMask"))
        {
            birdMask.SetActive(true);
            JumpSymbol.SetActive(true);
            JumpSymbol1.SetActive(true);
            JumpSymbol2.SetActive(true);
            JumpSymbol3.SetActive(true);
            Invoke("OffBirdMask", 10);
        }
    }

    void OffRabbitMask()
    {
        rabbitMask.SetActive(false);
        m_JampPower /= 1.3f;
    }

    void OffBirdMask()
    {
        birdMask.SetActive(false);
        JumpSymbol.SetActive(false);
        JumpSymbol1.SetActive(false);
        JumpSymbol2.SetActive(false);
        JumpSymbol3.SetActive(false);
    }

}
