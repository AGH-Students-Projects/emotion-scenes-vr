using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMovement : MonoBehaviour
{

    private float minTurnAngle = -90.0f;
    private float maxTurnAngle = 90.0f;

    [SerializeField] float turnSpeed = 2.0f;
    [SerializeField] float moveSpeed = 2.0f;

    private float gravity = -9.81f;
    private float rotX;

    [SerializeField] Camera camera;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        CharacterMovement();
        if(Input.GetMouseButtonDown(1))
        {
            Action();
        }
    }

    void CameraMovement()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        camera.transform.eulerAngles = new Vector3(-rotX, camera.transform.eulerAngles.y, 0);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);
    }

    void CharacterMovement()
    {
        Vector3 dir = new Vector3(0, 0, 0);

        dir.x = Input.GetAxis("Horizontal");
        dir.y = gravity;
        dir.z = Input.GetAxis("Vertical");
        Vector3 direction = transform.TransformDirection(dir);
        controller.Move(direction * moveSpeed * Time.deltaTime);

    }

    void Action()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red,5);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);
        if(hitData.collider.CompareTag("DoorButton"))
        {
            DoorButton button = hitData.collider.GetComponent<DoorButton>();
            if (button) button.OpenDoor();
        }
    }
}
