using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePosition : MonoBehaviour
{
    [SerializeField] Transform upPoint;
    [SerializeField] Transform downPoint;

    bool isUp = true;

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
