using UnityEngine;
using UnityEngine.InputSystem;

public class CharMove : MonoBehaviour
{
    private float speed = 5f;
    private float jumpHight = 2f;
    private float gravity = -9.81f;

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


    // Update is called once per frame
    void Update()
    {
        
    }
}
