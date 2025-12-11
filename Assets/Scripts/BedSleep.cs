using UnityEngine;

public class BedSleep : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Call your DayNightCycle sleep method
        Object.FindAnyObjectByType<DayNightCycle>().Sleep();
        Debug.Log("Player slept. Time reset to morning.");
    }
}
