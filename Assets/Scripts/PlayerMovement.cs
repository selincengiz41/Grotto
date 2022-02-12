using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    private CharacterController controller;
    public float speed = 10f;

    //CameraController
    public float mouseSensitivity = 200f;
    private float xRotation = 0f;

    //Jump & Gravity
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isGrounded;

    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask obstacleLayer;
    public float JumpHeight = 0.1f;
    public float GravityDivide = 100f;
    public float jumpSpeed = 30f;
    public float aTimer;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        //Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        //Check character is grounded
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);

        //Movement
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;
        controller.Move(moveVelocity);

        //CameraController
        //Left-Right 
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0);
        //Up-Down
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //Gravity

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime / GravityDivide;
            aTimer += Time.deltaTime/3;
            speed = Mathf.Lerp(10,jumpSpeed,aTimer);


        }
        else
        {
            speed = 10f;
            velocity.y = -0.05f;
            aTimer = 0;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity / GravityDivide);

        }

        controller.Move(velocity);



    }
}
