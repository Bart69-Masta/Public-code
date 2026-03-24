using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class NEWMOVE : MonoBehaviour
{
    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float runSpeed = 5f;
    public float speed = 1.0f;

    public float jumpSpeed = 8.0f;
    public float gravity = 9.8f;
    private float verticalSpeed = 0.0f;

    public GameObject Finish;

    public NEWMOVE targetScript;

    // --- Components ---
    public CharacterController characterController;

    private void Start()
    {
        Finish = GameObject.FindWithTag("Finish");
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //characterController.transform.localposition(1,0,0);
        HandleMovement();
        EndGame();

        //transform.position += Vector3.right * speed * Time.deltaTime;

        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalSpeed = jumpSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            DisableScript();
            Debug.Log("movement disabled");
        }


        else if (other.gameObject.tag == "Trap")
        {
            DisableScript();
            Debug.Log("ded to trap");
        }

        else
        {
            Debug.Log("no script to disable");
        }
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        characterController.Move(move * speed * Time.deltaTime);

        verticalSpeed -= gravity * Time.deltaTime;
        move.y = verticalSpeed;

        characterController.Move(move * Time.deltaTime);
    }

    void EndGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quitting"); ;
            Application.Quit();
            Debug.Log("Suceeded");
        }
    }

    public void DisableScript()
    {
        if (targetScript != null)
        {
            targetScript.enabled = false; // Disable the script
            Debug.Log("TargetScript has been disabled.");
        }

        else
        {
            Debug.LogWarning("TargetScript reference is missing!");
        }
    }


}
