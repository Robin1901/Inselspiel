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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
           
    }

    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (context.performed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -1.5f * gravity);
        }
    }
    

    // Update is called once per frame
    void Update()
    {

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);   

        // sprint when Left Shift is held (only changes horizontal speed)
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
