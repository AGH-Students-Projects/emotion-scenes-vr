using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;

    [SerializeField] private GameObject[] rooms;
    [SerializeField] private GameObject finalRoom;
    [SerializeField] private int maxRooms;
    private GameObject roomToDestroy;
    private GameObject currentRoom;
    private GameObject newRoom;
    private Transform whereSpawnNewRoom;
    private int allRoomCounter = 0;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnNewRoom(Transform roomPosition)
    {
        allRoomCounter++;
        if (roomToDestroy != null) Destroy(roomToDestroy, 5f);
        roomToDestroy = currentRoom;
        currentRoom = newRoom;
        if (allRoomCounter >= maxRooms)
        {
            newRoom = Instantiate(finalRoom, roomPosition.position, roomPosition.rotation);
        }
        else
        {
            newRoom = Instantiate(rooms[Random.Range(0, rooms.Length)], roomPosition.position, roomPosition.rotation);
        }
        

        
    }
}
