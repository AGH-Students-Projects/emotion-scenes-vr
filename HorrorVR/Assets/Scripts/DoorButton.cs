using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] DoorController door;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Hand"))
        {
            StartCoroutine(door.openDoor());
        }
    }
}
