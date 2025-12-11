using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallCollisionSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasCollided = false;

    [Header("Randomise Pitch")]
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasCollided)
        {
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.Play();
            hasCollided = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasCollided = false;
        }
    }
}
