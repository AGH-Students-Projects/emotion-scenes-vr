using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;

    private bool ifShouldSpawnRoom;
    [SerializeField] private GameObject[] rooms;
    private GameObject currentRoom;
    private GameObject newRoom;
    private Transform whereSpawnNewRoom;

    private void Awake()
    {
        instance = this;
        ifShouldSpawnRoom = true;
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
        
            if (currentRoom != null) Destroy(currentRoom, 5f);
            ifShouldSpawnRoom = false;
            currentRoom = newRoom;
            newRoom = Instantiate(rooms[Random.Range(0, rooms.Length)], roomPosition.position, roomPosition.rotation);

        
    }
}
