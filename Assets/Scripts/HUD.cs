using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TMP_Text goldText;

    void Update()
    {
        goldText.text = $"Gold: {GameManager.Instance.Money}";
    }
}
