using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTrigger : MonoBehaviour
{
    [SerializeField] ParticleSystem spiders;
    static int roomCounter = 0;
    [SerializeField] int chanceToScare;

    private void Start()
    {
        roomCounter++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            int x = Random.Range(0, chanceToScare);
            Debug.Log("Counter: " + roomCounter + ", rand: " + x);
            if (roomCounter > x)
            {
                spiders.Play();
                roomCounter = 0;
            }
            GetComponent<BoxCollider>().enabled = false;
        }

    }
}
