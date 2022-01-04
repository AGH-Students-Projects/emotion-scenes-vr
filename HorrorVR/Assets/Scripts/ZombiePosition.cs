using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePosition : MonoBehaviour
{
    [SerializeField] Transform upPoint;
    [SerializeField] Transform downPoint;

    bool isUp = true;

    static int roomCounter = 0;
    [SerializeField] int chanceToScare;

    private void Start()
    {
        roomCounter++;
        int x = Random.Range(0, chanceToScare);
        Debug.Log("Counter: " + roomCounter + ", rand: " + x + ",init chance: " + chanceToScare);
        if (roomCounter > x)
        {
            roomCounter = 0;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void MoveUp()
    {
        if (!isUp)
        {
            isUp = true;
            transform.position = upPoint.transform.position;
            transform.LookAt(downPoint);

        }
    }

    public void MoveDown()
    {
        if (isUp)
        {
            isUp = false;
            transform.position = downPoint.transform.position;
            transform.LookAt(upPoint);

        }
    }
}
