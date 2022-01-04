using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PCMovement : MonoBehaviour
{

    private float minTurnAngle = -90.0f;
    private float maxTurnAngle = 90.0f;

    [SerializeField] float turnSpeed = 2.0f;
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float rayDistance;
    [SerializeField] Transform destination;

    private float gravity = -9.81f;
    private float rotX;

    [SerializeField] Camera playerCamera;
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
            PushButton();
        } 
        if(Input.GetMouseButtonDown(0))
        {
            PickUp();
        }
    }

    void CameraMovement()
    {
        float y = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        playerCamera.transform.eulerAngles = new Vector3(-rotX, playerCamera.transform.eulerAngles.y, 0);
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

    void PushButton()
    {
        RaycastHit hitData = ShootRay();
        if(hitData.distance < rayDistance && hitData.collider.CompareTag("DoorButton"))
        {
            DoorButton button = hitData.collider.GetComponent<DoorButton>();
            if (button) button.OpenDoor();
        }
    }

    private RaycastHit ShootRay()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);
        return hitData;
    }

    private void PickUp()
    {
        RaycastHit hitData = ShootRay();
        if (hitData.distance < rayDistance && hitData.collider.GetComponent<XRGrabInteractable>())
        {            
            if(destination.childCount > 0)
            {
                Transform[] cubes = destination.GetComponentsInChildren<Transform>();
                foreach(Transform cube in cubes)
                {
                    if(Vector3.Distance(cube.position, destination.position) > 5f)
                    {
                        Destroy(cube.gameObject);
                    }
                }
                if (destination.childCount > 0) return;
            }

            hitData.collider.GetComponent<Rigidbody>().useGravity = false;
            hitData.collider.GetComponent<BoxCollider>().isTrigger = true;
            hitData.collider.transform.position = destination.position;
            hitData.collider.transform.SetParent(destination);


        }
    }
}
