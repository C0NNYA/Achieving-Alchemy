using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    void Start()
    {
        if (!string.IsNullOrEmpty(SceneTransition.spawnPointName))
        {
            GameObject spawnPoint = GameObject.Find(SceneTransition.spawnPointName);
            if (spawnPoint != null)
            {
                transform.position = spawnPoint.transform.position;
                transform.rotation = spawnPoint.transform.rotation;
            }
            else
            {
                Debug.LogWarning("Spawn point not found: " + SceneTransition.spawnPointName);
            }
        }
    }
}
