using UnityEngine;

public class MagnetCollect : MonoBehaviour
{
    private float magnetRange = 1.5f;

    void Start()
    {
        GetComponent<SphereCollider>().radius = magnetRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            if (other.TryGetComponent<CopyMünzeMagnet>(out CopyMünzeMagnet coin))
            {
                coin.StartMagnet(this.transform.parent);
            }
        }
    }

    void Update()
    {
        magnetRange = CoinIslandManager.Instance.magnetRadius;
        Debug.Log(magnetRange);
        GetComponent<SphereCollider>().radius = magnetRange;
    }
}