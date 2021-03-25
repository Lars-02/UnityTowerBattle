using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject spawner;

    public GameObject archer;

    void Start()
    {
        InvokeRepeating("SpawnWave", 2.0f, 1f);
    }

    void SpawnWave()
    {
        SpawnController spawnerController = spawner.GetComponent<SpawnController>();
        if (spawnerController.filled)
            return;
        spawnerController.SpawnUnit(archer);
    }
}
