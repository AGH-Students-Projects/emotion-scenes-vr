using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Transform openPos;
    [SerializeField] GameObject door;
    [SerializeField] GameObject room;
    [SerializeField] float speed;
    [SerializeField] bool spawnRoom;

    private bool isOpen = false;
    
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = this.transform.position;
    }

    public IEnumerator openDoor()
    {
        Debug.Log("openDoorMethod");

        if (spawnRoom)
        {
            Debug.Log("spawning");
            spawnRoom = false;
            RoomManager.instance.spawnNewRoom(this.transform);
        }

        if (!isOpen)
        {
            Debug.Log("opening");
            isOpen = !isOpen;

            while(Vector3.Distance(door.transform.position, openPos.position) > 0.001f && isOpen)
            {
                Debug.Log("opening2222222");
                door.transform.position = Vector3.MoveTowards(door.transform.position, openPos.position, Time.deltaTime * speed);
                yield return new WaitForSeconds(0.1f);
            }            
        }

    }

    public IEnumerator closeDoor()
    {
        if (isOpen)
        {
            isOpen = !isOpen;

            while (Vector3.Distance(door.transform.position, Vector3.zero) > 0.001f && !isOpen)
            {
                door.transform.position = Vector3.MoveTowards(door.transform.position, initialPosition, Time.deltaTime * speed * 5);
                yield return new WaitForSeconds(0.1f);
            }            
        }
    }

    private void spawnRoomInLocation()
    {
        GameObject newRoom = Instantiate(room, this.transform);
    }
    
}
