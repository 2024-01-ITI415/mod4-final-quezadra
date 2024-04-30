using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            Collect();
        }
    }

    private void Collect()
    {
        isCollected = true;
        GameObject nearestCollectionArea = FindNearestCollectionArea();
        if (nearestCollectionArea != null)
        {
            transform.SetParent(nearestCollectionArea.transform);
            transform.localPosition = Vector3.zero;
            // Optionally, disable any colliders or scripts on the collected item
            Collider itemCollider = GetComponent<Collider>();
            if (itemCollider != null)
            {
                itemCollider.enabled = false;
            }
            // Optionally, play a sound or visual effect when collecting an item
            // For example: GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.LogWarning("No collection area found nearby.");
        }
    }

    private GameObject FindNearestCollectionArea()
    {
        GameObject[] collectionAreas = GameObject.FindGameObjectsWithTag("CollectionArea");
        GameObject nearestArea = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject area in collectionAreas)
        {
            float distance = Vector3.Distance(transform.position, area.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestArea = area;
            }
        }
        return nearestArea;
    }
}
