using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [Header("Potion Setup")]
    public GameObject potionPrefab;     // What the cauldron should output
    public float mixTime = 2f;          // Wait time before potion appears

    private List<GameObject> plantsInside = new List<GameObject>();
    private bool isMixing = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the thing entering is a plant
        if (other.CompareTag("Plant"))
        {
            plantsInside.Add(other.gameObject);

            // When 2 plants are inside, start mixing
            if (plantsInside.Count >= 2 && !isMixing)
            {
                StartCoroutine(MixCoroutine());
            }
        }
    }

    private IEnumerator MixCoroutine()
    {
        isMixing = true;

        // Wait
        yield return new WaitForSeconds(mixTime);

        // Remove plant objects
        foreach (GameObject plant in plantsInside)
        {
            Destroy(plant);
        }
        plantsInside.Clear();

        // Spawn potion slightly above the cauldron
        Vector3 spawnPos = transform.position + Vector3.up * 0.5f;
        Instantiate(potionPrefab, spawnPos, Quaternion.identity);

        isMixing = false;
    }
}
