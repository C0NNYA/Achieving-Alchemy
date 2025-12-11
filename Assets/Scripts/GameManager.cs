using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Money { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadMoney();
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        SaveMoney();
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetInt("PlayerMoney", Money);
        PlayerPrefs.Save();
    }

    private void LoadMoney()
    {
        Money = PlayerPrefs.GetInt("PlayerMoney", 0);
    }
}
