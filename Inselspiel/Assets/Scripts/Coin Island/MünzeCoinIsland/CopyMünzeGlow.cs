using UnityEngine;

public class CopyMünzeGlow : MonoBehaviour
{
    public Material coinMaterial;
    private float pulseSpeed = 4f;
    private float minIntensity = 0.2f;
    private float maxIntensity = 0.8f;

    void Update()
    {
        float emission = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(Time.time * pulseSpeed) + 1) / 2f);
        coinMaterial.SetColor("_EmissionColor", Color.yellow * emission);
    }
}