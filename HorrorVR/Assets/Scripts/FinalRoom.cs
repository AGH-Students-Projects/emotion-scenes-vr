using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetComponent<DoorController>().openDoor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
