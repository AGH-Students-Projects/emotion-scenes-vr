using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMovement : MonoBehaviour
{

    private float minTurnAngle = -90.0f;
    private float maxTurnAngle = 90.0f;

    private float turnSpeed = 4.0f;
    private float rotX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseAiming();
    }

    void MouseAiming()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }
}
