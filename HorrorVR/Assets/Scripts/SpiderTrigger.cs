using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTrigger : MonoBehaviour
{
    [SerializeField] ParticleSystem spiders;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            spiders.Play();
        }
    }
}
