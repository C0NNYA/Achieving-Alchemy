using UnityEngine;

public class MoneyPickup : MonoBehaviour
{
    public int value = 10;

    public void Collect()
    {
        GameManager.Instance.AddMoney(value);
        Debug.Log($"Picked up ${value}. Total money (now): ${GameManager.Instance.Money}");

        Destroy(gameObject);
    }
}
