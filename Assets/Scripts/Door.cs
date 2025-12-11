using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Scene loader")]
    public string sceneToLoad;          // Name of the scene to load
    public string destinationSpawnPoint; // Spawn point name in the new scene

    public void Interact()
    {
        Debug.Log("INTERACT WITH DOOR: " + gameObject.name);

        // Save where the player should spawn in the next scene
        SceneTransition.spawnPointName = destinationSpawnPoint;

        // Load the new scene
        Object.FindAnyObjectByType<SceneLoader>().LoadSceneByName(sceneToLoad);
    }
}
