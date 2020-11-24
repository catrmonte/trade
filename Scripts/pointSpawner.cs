using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointSpawner : MonoBehaviour
{
    public GameObject[] spawnDrops;
    private int spawnCounter = 1;
    public GameObject orbPrefab;

    public static pointSpawner instance;

    void Awake() { instance = this; }


    public void SpawnOrb()
    {
        if (spawnCounter % 5 == 0)
        {
            // Spawn High Point one
        }
        else
        {
            // Spawn Regular one
            Instantiate(orbPrefab, spawnDrops[spawnCounter-1].transform.position, Quaternion.identity);
        }
        
        // Check if spawn counter needs to wrap around
        if (spawnCounter == 10)
        {
            spawnCounter = 1;
        }
        else
        {
            spawnCounter++;
        }

    }
}
