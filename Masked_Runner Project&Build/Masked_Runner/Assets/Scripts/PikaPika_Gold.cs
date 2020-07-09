using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikaPika_Gold : MonoBehaviour
{
    [SerializeField] private AudioClip getpikapika;

    private void Start()
    {
        //getpikapika = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<ScoreManager>().AddPoint(45);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(getpikapika,Camera.main. transform.position);
        }
    }
}
