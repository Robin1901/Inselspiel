using UnityEngine;
using UnityEngine.InputSystem;

public class CharMove : MonoBehaviour
{
    private float speed = 5f;
    private float jumpHight = 1.5f;
    private float gravity = -20f;
    private float sprint = 10f;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;

    public AudioSource source;
    public AudioClip sprung;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void onMove(InputAction.CallbackContext context)
    {
        if (GameManager.Instance != null && GameManager.Instance.inputBlocked)
        {
            moveInput = Vector2.zero;
            return;
        }

        moveInput = context.ReadValue<Vector2>();
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (GameManager.Instance != null && GameManager.Instance.inputBlocked) return;

        if (context.performed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -1.5f * gravity);
            if (source != null) source.Play();
        }
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.inputBlocked)
        {
            return;
        }

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        float currentSpeed = speed;
        if (Keyboard.current != null && Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed = sprint;
        }

        controller.Move(move * currentSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}