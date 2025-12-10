using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BellTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasTriggered = false; // Prevent spamming while inside trigger

    [Header("Pitch Settings")]
    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            // Randomize pitch for natural variation
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.Play();
            hasTriggered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Allow bell to ring again if player leaves and re-enters
            hasTriggered = false;
        }
    }
}
