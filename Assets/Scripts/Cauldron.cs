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

        // Spawn potion a bit above center
        Vector3 spawnPos = transform.position + Vector3.up * 0.5f;
        GameObject potion = Instantiate(potionPrefab, spawnPos, Quaternion.identity);

        // Add force so it pops out of the cauldron
        Rigidbody rb = potion.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 launchDir = transform.forward * 2f + Vector3.up * 3f; // tweak values as needed
            rb.AddForce(launchDir, ForceMode.Impulse);
        }


        isMixing = false;
    }
}
