using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Sunny settings")]
    public Light sun;
    [Range(0, 24)] public float currentTime = 12f;
    public float timeSpeed = 1f;

    [Header("Light bright")]
    public AnimationCurve sunIntensityCurve;
    public Gradient sunColorGradient;

    [Header("Night Night")]
    public float nightStart = 18f;
    public float nightEnd = 6f;
    private bool isNight = false;

    void Update()
    {
        if (!isNight)
        {
            currentTime += Time.deltaTime * timeSpeed;
            if (currentTime >= 24f) currentTime = 0f;
        }

        if (currentTime >= nightStart || currentTime < nightEnd)
        {
            isNight = true;
        }

        float sunAngle = (currentTime / 24f) * 360f - 90f;
        sun.transform.rotation = Quaternion.Euler(sunAngle, -30f, 0f);

        sun.intensity = sunIntensityCurve.Evaluate(currentTime / 24f);
        sun.color = sunColorGradient.Evaluate(currentTime / 24f);
    }

    public void Sleep()
    {
        isNight = false;
        currentTime = 6f;
    }
}
