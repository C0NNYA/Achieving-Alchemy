using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Sun Settings")]
    public Light sun;
    [Range(0, 24)] public float currentTime = 12f;
    public float timeSpeed = 1f;

    [Header("Lighting Settings")]
    public AnimationCurve sunIntensityCurve;
    public Gradient sunColorGradient;

    [Header("Night Settings")]
    public float nightStart = 18f; // 6 PM
    public float nightEnd = 6f;    // 6 AM
    private bool isNight = false;

    void Update()
    {
        // Only progress time if it's not night
        if (!isNight)
        {
            currentTime += Time.deltaTime * timeSpeed;
            if (currentTime >= 24f) currentTime = 0f;
        }

        // Check if night should start
        if (currentTime >= nightStart || currentTime < nightEnd)
        {
            isNight = true;
        }

        // Rotate sun
        float sunAngle = (currentTime / 24f) * 360f - 90f;
        sun.transform.rotation = Quaternion.Euler(sunAngle, -30f, 0f);

        // Adjust sun intensity and color
        sun.intensity = sunIntensityCurve.Evaluate(currentTime / 24f);
        sun.color = sunColorGradient.Evaluate(currentTime / 24f);
    }

    // Call this method when the player sleeps
    public void Sleep()
    {
        isNight = false;          // Unlock time progression
        currentTime = 6f;         // Reset to morning (6 AM)
    }
}
