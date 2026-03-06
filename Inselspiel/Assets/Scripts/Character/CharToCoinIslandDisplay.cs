using UnityEngine;

public class CharToCoinIslandDisplay : MonoBehaviour
{
    public Camera mainCam;
    public Camera displayCam;

    private float maxInteractDistance = 2f;
    private bool isAtDisplay = false;
    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        if (mainCam != null) mainCam.enabled = true;
        if (displayCam != null) displayCam.enabled = false;
    }

    void Update()
    {
        if (isAtDisplay && Input.GetKeyDown(KeyCode.E))
        {
            ExitDisplay();
        }
    }

    public void EnterDisplay()
    {
        if (Vector3.Distance(transform.position, displayCam.transform.position) > maxInteractDistance) return;

        if (mainCam == null || displayCam == null) return;

        isAtDisplay = true;

        mainCam.enabled = false;
        displayCam.enabled = true;

        if (controller != null) controller.enabled = false;

        if (CoinIslandManager.Instance != null) CoinIslandManager.Instance.SetInputBlocked(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ExitDisplay()
    {
        isAtDisplay = false;

        if (mainCam != null) mainCam.enabled = true;
        if (displayCam != null) displayCam.enabled = false;

        if (controller != null) controller.enabled = true;

        if (CoinIslandManager.Instance != null) CoinIslandManager.Instance.SetInputBlocked(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}