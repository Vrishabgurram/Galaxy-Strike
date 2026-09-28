using UnityEngine;

public class SpawnOnTrigger : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    private bool hasSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (hasSpawned) return;

        Debug.Log("Spawn trigger hit by player");

        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        hasSpawned = true;
        Destroy(gameObject);
    }
}
