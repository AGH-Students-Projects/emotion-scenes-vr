using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorBehaviour : MonoBehaviour
{
    [SerializeField] Transform leftWall;
    [SerializeField] Transform leftPoint;
    [SerializeField] Transform rightWall;
    [SerializeField] Transform rightPoint;
    [SerializeField] bool shouldMove;
    [SerializeField] float speed;
    [SerializeField] float closeSpeed;

    private Vector3 leftInitPosition;
    private Vector3 rightInitPosition;

    static int roomCounter = 0;
    [SerializeField] int chanceToScare;


    // Start is called before the first frame update
    void Start()
    {
        leftInitPosition = leftWall.position;
        rightInitPosition = rightWall.position;
        roomCounter++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            int x = Random.Range(0, chanceToScare);
            Debug.Log("Counter: " + roomCounter + ", rand: " + x);
            if (roomCounter > x)
            {
                StartCoroutine(MoveWalls());
                roomCounter = 0;
            }
            GetComponent<BoxCollider>().enabled = false;           
        }
    }

    IEnumerator MoveWalls()
    {
        if (shouldMove)
        {
            shouldMove = false;
            while (Vector3.Distance(leftWall.position, leftPoint.position) > 0.001f && Vector3.Distance(rightWall.position, rightPoint.position) > 0.001f)
            {
                leftWall.position = Vector3.MoveTowards(leftWall.position, leftPoint.position, speed);
                rightWall.position = Vector3.MoveTowards(rightWall.position, rightPoint.position, speed);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(1.5f);
            while (Vector3.Distance(leftWall.position, leftInitPosition) > 0.001f && Vector3.Distance(rightWall.position, rightInitPosition) > 0.001f)
            {
                leftWall.position = Vector3.MoveTowards(leftWall.position, leftInitPosition, closeSpeed);
                rightWall.position = Vector3.MoveTowards(rightWall.position, rightInitPosition, closeSpeed);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
