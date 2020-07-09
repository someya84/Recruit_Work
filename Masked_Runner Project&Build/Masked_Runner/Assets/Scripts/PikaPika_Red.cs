using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikaPika_Red : MonoBehaviour
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
            FindObjectOfType<ScoreManager>().AddPoint(35);
            AudioSource.PlayClipAtPoint(getpikapika,Camera.main. transform.position);
            Destroy(this.gameObject);
        }
    }
}
