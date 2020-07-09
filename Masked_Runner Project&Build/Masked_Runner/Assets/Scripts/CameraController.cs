using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public int m_Speed = 5;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(m_Speed * Time.deltaTime, 0, 0);
        if(this.transform.position.x >= 430)
        {
            m_Speed = 0;
        }
    }

    public void UnMove(int moveSpeed)
    {
        m_Speed = moveSpeed;
    }

}
