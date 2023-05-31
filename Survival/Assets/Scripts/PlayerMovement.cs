using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float sprintSpeed;
    public float jumpHeight;
    public float gravity = -9.81f;
    public LayerMask groundMask;
    [SerializeField, Range(1, 100)] public float sensitivityX, sensitivityY;

    CharacterController controller;
    Transform playerBody;
    Transform groundCheck;
    Transform camera;
    float groundDistance = 0.25f;
    Vector2 movement;
    Vector3 velocity;
    bool isGrounded;
    bool isSprinting;
    Vector2 mouse;

    float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();
        playerBody = transform.GetChild(0);
        groundCheck = transform.GetChild(1);
        camera = transform.GetChild(2);
        camera.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        RotateCamera();
        MovePlayer();
    }

    private void RotateCamera()
    {
        xRotation -= mouse.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        camera.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouse.x);
    }

    private void MovePlayer()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) velocity.y = -2f;

        Vector3 direction = playerBody.right * movement.x + playerBody.forward * movement.y;
        float speed = walkSpeed;
        if (isSprinting) speed = sprintSpeed;
        else speed = walkSpeed;
        controller.Move(direction * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void OnMove(InputValue value) => movement = value.Get<Vector2>();

    public void OnSprint(InputValue value)
    {
        if (value.Get<float>() == 1) isSprinting = true;
        else isSprinting = false;
    }

    public void OnJump(InputValue value)
    {
        if (isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    public void OnLook(InputValue value)
    {
        mouse.x = value.Get<Vector2>().x * Time.deltaTime * sensitivityX;
        mouse.y = value.Get<Vector2>().y * Time.deltaTime * sensitivityY;
    }
}
