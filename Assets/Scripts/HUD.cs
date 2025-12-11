using UnityEngine;
using TMPro; // Needed for TextMeshPro

public class HUD : MonoBehaviour
{
    public TMP_Text goldText; // Drag the TextMeshPro object here

    void Update()
    {
        // Update the gold text every frame
        goldText.text = $"Gold: {GameManager.Instance.Money}";
    }
}
