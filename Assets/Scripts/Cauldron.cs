using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [Header("Brew setting")]
    public GameObject potionPrefab;
    public float mixTime = 2f;

    private List<GameObject> plantsInside = new List<GameObject>();
    private bool isMixing = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plant"))
        {
            plantsInside.Add(other.gameObject);

            if (plantsInside.Count >= 2 && !isMixing)
            {
                StartCoroutine(MixCoroutine());
            }
        }
    }

    private IEnumerator MixCoroutine()
    {
        isMixing = true;

        yield return new WaitForSeconds(mixTime);

        foreach (GameObject plant in plantsInside)
        {
            Destroy(plant);
        }
        plantsInside.Clear();

        Vector3 spawnPos = transform.position + Vector3.up * 0.5f;
        GameObject potion = Instantiate(potionPrefab, spawnPos, Quaternion.identity);

        Rigidbody rb = potion.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 launchDir = transform.forward * 2f + Vector3.up * 3f;
            rb.AddForce(launchDir, ForceMode.Impulse);
        }


        isMixing = false;
    }
}
