using UnityEditor;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    // --- Movement Settings ---
    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float runSpeed = 5f;

    // --- Mouse Look Settings ---
    [SerializeField] Transform headTransform; // Assign in Inspector
    [SerializeField] float mouseSensitivity = 2f;
    [SerializeField] float xRotation = 0f;
    [SerializeField] float yRotation = 0f;

    public float jumpSpeed = 8.0f;
    public float gravity = 9.8f;
    private float verticalSpeed = 0.0f;

    // --- Components ---
    public CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMovement();
        HandleHeadRotation();
        EndGame();

        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalSpeed = jumpSpeed;
            }
        }
    }

    void HandleMovement()
    {
        characterController.transform.Translate (0,1,0);
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //Vector3 move = transform.right * horizontal + transform.forward * vertical;
        //float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        //characterController.Move(move * speed * Time.deltaTime);

        //verticalSpeed -= gravity * Time.deltaTime;
        //move.y = verticalSpeed;

        //characterController.Move(move * Time.deltaTime);
    }

    void EndGame()
    {



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quitting");
            Application.Quit();
            Debug.Log("Suceeded");
        }

    }

    void HandleHeadRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Apply yaw to player body
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

        // Apply pitch to head/camera
        headTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}