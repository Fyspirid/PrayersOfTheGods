using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSilverGuards : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabsToSpawn;
    [SerializeField] private float spawnRange;
    [SerializeField] private int numberOfObjects;
    [SerializeField] private float spawnInterval;
    public void SpawnObjects()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        WaitForSeconds waitTime = new WaitForSeconds(spawnInterval);

        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange),
                                                0f,
                                                Random.Range(-spawnRange, spawnRange));
            GameObject prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            yield return waitTime;
        }
    }
}
