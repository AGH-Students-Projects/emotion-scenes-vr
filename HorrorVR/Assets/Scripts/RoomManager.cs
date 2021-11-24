using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;

    [SerializeField] private GameObject[] rooms;
    private GameObject roomToDestroy;
    private GameObject currentRoom;
    private GameObject newRoom;
    private Transform whereSpawnNewRoom;

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
        if (roomToDestroy != null) Destroy(roomToDestroy, 5f);
            roomToDestroy = currentRoom;
            currentRoom = newRoom;
            newRoom = Instantiate(rooms[Random.Range(0, rooms.Length)], roomPosition.position, roomPosition.rotation);

        
    }
}
