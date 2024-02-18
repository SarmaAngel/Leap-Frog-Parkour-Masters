using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    private List<GameObject> collectibles = new List<GameObject>();

    void Start()
    {
        GameObject[] foundCollectibles = GameObject.FindGameObjectsWithTag("Collect");
        foreach (GameObject collectible in foundCollectibles)
        {
            collectibles.Add(collectible);
        }

        StartCoroutine(ActivateCollectibles());

        foreach (GameObject collectible in collectibles)
        {
            collectible.SetActive(false);
        }
    }

    IEnumerator ActivateCollectibles()
    {
        for (int i = 0; i < collectibles.Count; i++)
        {
            GameObject collectible = collectibles[i];
            if (collectible != null)
            {
                collectible.SetActive(true);
                yield return new WaitForSeconds(15);
                collectible.SetActive(false);
                collectibles.Remove(collectible);
                i--; // Decrement the index as we have removed an item from the list
            }
        }
    }
}
