using UnityEngine;

public class CamCoinIslandDisplay : MonoBehaviour
{
    public Transform defaultPosition;
    public Transform coinIslandDisplayPosition;

    private float transitionSpeed = 7.5f;
    private float maxInteractDistance = 10f;

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


            if (Vector3.Distance(cam.transform.position, target.position) < 0.01f)
            {
                cam.transform.position = target.position;

                if (!isAtDisplay)
                {
                    cam.transform.rotation = target.rotation;
                }

                moving = false;
            }
        }
    }

    public void EnterDisplay()
    {
        if (player == null) return;

        if (Vector3.Distance(player.position, coinIslandDisplayPosition.position) <= maxInteractDistance)
        {
            isAtDisplay = true;
            moving = true;

            if (CoinIslandManager.Instance != null) CoinIslandManager.Instance.SetInputBlocked(true);
        }
    }

    public void ExitDisplay()
    {
        isAtDisplay = false;
        moving = true;

        if (CoinIslandManager.Instance != null) CoinIslandManager.Instance.SetInputBlocked(false);
    }

    public bool IsAtDisplay()
    {
        return isAtDisplay;
    }
}