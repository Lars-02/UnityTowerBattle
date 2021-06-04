using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject spawner;
    public List<GameObject> units;

    public bool spawning;

    private readonly Queue<GameObject> unitQueue = new Queue<GameObject>();

    void Start()
    {
        InvokeRepeating("SpawnWave", 2f, 0.1f);
        InvokeRepeating("AddUnit", 0f, 16f);
    }

    private void SpawnWave()
    {
        if (!spawning)
            return;
        SpawnController spawnerController = spawner.GetComponent<SpawnController>();
        if (unitQueue.Count <= 0)
            return;
        if (spawnerController.SpawnUnit(unitQueue.Peek()))
            unitQueue.Dequeue();
    }

    private void AddUnit()
    {
        unitQueue.Enqueue(units[Random.Range(0, units.Count)]);
    }
}
