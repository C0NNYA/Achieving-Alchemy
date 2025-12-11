using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Scene loader")]
    public string sceneToLoad;
    public string destinationSpawnPoint;
    public void Interact()
    {
        Debug.Log("INTERACT WITH DOOR: " + gameObject.name);

        SceneTransition.spawnPointName = destinationSpawnPoint;

        Object.FindAnyObjectByType<SceneLoader>().LoadSceneByName(sceneToLoad);
    }
}
