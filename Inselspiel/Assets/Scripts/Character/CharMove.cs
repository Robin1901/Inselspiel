using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

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

    public Image fadeScreen;
    private bool isRespawning = false;

    private float airSpeedMultiplier = 1f;
    private float airSpeedTarget = 1f;
    private float airSpeedSmooth = 1.5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void onMove(InputAction.CallbackContext context)
    {
        if (CoinIslandManager.Instance != null && CoinIslandManager.Instance.inputBlocked)
        {
            moveInput = Vector2.zero;
            return;
        }

        moveInput = context.ReadValue<Vector2>();
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (CoinIslandManager.Instance != null && CoinIslandManager.Instance.inputBlocked) return;

        if (context.performed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -1.7f * gravity);
            if (source != null) source.Play();
        }
    }

    void Update()
    {
        if (CoinIslandManager.Instance != null && CoinIslandManager.Instance.inputBlocked) return;

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        float currentSpeed = speed;
        if (Keyboard.current != null && Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed = sprint;
        }

        if (!controller.isGrounded && velocity.y < 0)
        {
            airSpeedTarget = 0.35f;
        }
        else
        {
            airSpeedTarget = 1f;
        }

        airSpeedMultiplier = Mathf.Lerp(airSpeedMultiplier, airSpeedTarget, Time.deltaTime * airSpeedSmooth);

        controller.Move(move * currentSpeed * airSpeedMultiplier * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (transform.position.y < -40.0f && !isRespawning)
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        isRespawning = true;

        float duration = 1.75f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float alpha = timer / duration;
            fadeScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        controller.enabled = false;
        transform.position = new Vector3(0, 2, 0);
        velocity = Vector3.zero;
        controller.enabled = true;

        yield return new WaitForSeconds(0.5f);

        fadeScreen.color = new Color(0, 0, 0, 0);
        airSpeedMultiplier = 1f;

        isRespawning = false;
    }
}