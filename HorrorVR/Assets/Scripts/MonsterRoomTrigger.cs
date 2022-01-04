using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRoomTrigger : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    [SerializeField] int chanceToScare;
    private Renderer zombieRenderer;
    static int roomCounter = 0;

    private void Start()
    {
        roomCounter++;
        zombieRenderer = zombie.GetComponentInChildren<Renderer>();
        zombie.SetActive(false);
        //Debug.Log(roomCounter);
    }

    private void Update()
    {
        if(zombieRenderer.isVisible)
        {
            Destroy(zombie, 1.5f);
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cube") )
        {
            int x = Random.Range(0, chanceToScare);
            Debug.Log("Counter: " + roomCounter + ", rand: " + x);
            if (roomCounter > x)
            {                
                zombie.SetActive(true);
                roomCounter = 0;
            }
            GetComponent<BoxCollider>().enabled = false;

        }
    }

    
}
