using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombie : MonoBehaviour
{
    [SerializeField] ZombiePosition zombie;
    [SerializeField] bool isUpTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (isUpTrigger)
                zombie.MoveDown();
            else
                zombie.MoveUp();
        }
    }
}
