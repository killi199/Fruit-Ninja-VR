using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // Array für die Prefabs der zu erstellenden Objekte
    public float spawnInterval = 1.0f; // Intervall zwischen den Spawns
    public Vector3 spawnOffset = Vector3.zero; // Offset zur Position des Spawners
    public Vector3 randomRotationRange = new Vector3(0f, 360f, 0f); // Bereich für die zufällige Rotation
    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector3 spawnPosition = GetRandomSpawnPosition();
            Quaternion spawnRotation = Quaternion.Euler(RandomRotation());
            GameObject randomPrefab = GetRandomPrefab();

            _ = Instantiate(randomPrefab, spawnPosition, spawnRotation);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Bounds spawnerBounds = _renderer.bounds;

        float x = Random.Range(-spawnerBounds.extents.x, spawnerBounds.extents.x);
        float z = Random.Range(-spawnerBounds.extents.z, spawnerBounds.extents.z);

        Vector3 spawnPosition = transform.position + spawnOffset + new Vector3(x, 0f, z);

        return spawnPosition;
    }

    GameObject GetRandomPrefab()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        return prefabs[randomIndex];
    }

    Vector3 RandomRotation()
    {
        float x = Random.Range(randomRotationRange.x, randomRotationRange.y);
        float y = Random.Range(randomRotationRange.x, randomRotationRange.y);
        float z = Random.Range(randomRotationRange.x, randomRotationRange.y);

        return new Vector3(x, y, z);
    }
}
