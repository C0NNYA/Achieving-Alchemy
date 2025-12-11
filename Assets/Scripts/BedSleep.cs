using UnityEngine;

public class BedSleep : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Object.FindAnyObjectByType<DayNightCycle>().Sleep();
        Debug.Log("Player slept. Time reset to morning.");
    }
}
