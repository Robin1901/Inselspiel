using UnityEngine;

public class CamCoinIslandDisplay : MonoBehaviour
{
    [Header("Camera Positions")]
    public Transform defaultPosition;
    public Transform coinIslandDisplayPosition;

    [Header("Settings")]
    private float transitionSpeed = 5f;
    private float maxInteractDistance = 1.25f;

    private bool isAtDisplay = false; 
    private bool moving = false;
    private Camera cam;

    private Transform player;

    void Awake()
    {
        cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("Keine Main Camera gefunden!");
            return;
        }

        if (defaultPosition != null)
        {
            cam.transform.position = defaultPosition.position;
            cam.transform.rotation = defaultPosition.rotation;
        }

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
        else Debug.LogWarning("Kein Spieler-Objekt mit Tag 'Player' gefunden!");
    }

    void Update()
    {
        if (isAtDisplay && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitDisplay();
        }

        if (moving)
        {
            Transform target = isAtDisplay ? coinIslandDisplayPosition : defaultPosition;
            if (target == null) return;

            cam.transform.position = Vector3.Lerp(cam.transform.position, target.position, Time.deltaTime * transitionSpeed);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, target.rotation, Time.deltaTime * transitionSpeed);

            if (Vector3.Distance(cam.transform.position, target.position) < 0.01f)
            {
                cam.transform.position = target.position;
                cam.transform.rotation = target.rotation;
                moving = false;
            }
        }
    }

    public void EnterDisplay()
    {
        Debug.Log("1");
        if (player == null) return;
        
        if (Vector3.Distance(player.position, coinIslandDisplayPosition.position) <= maxInteractDistance)
        {
            Debug.Log("EnterDisplay aufgerufen!");
            isAtDisplay = true;
            moving = true;

            if (GameManager.Instance != null) GameManager.Instance.SetInputBlocked(true);
        }
    }

    public void ExitDisplay()
    {
        isAtDisplay = false;
        moving = true;

        if (GameManager.Instance != null) GameManager.Instance.SetInputBlocked(false); // CHANGED
    }

    public bool IsAtDisplay()
    {
        return isAtDisplay;
    }
}