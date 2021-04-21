using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject archer;
    public GameObject swordsman;
    public GameObject guard;
    public GameObject wizard;

    public bool spawning;

    private Queue<GameObject> unitQueue = new Queue<GameObject>();

    void Start()
    {
        InvokeRepeating("SpawnWave", 2f, 0.1f);
        InvokeRepeating("Group1", 0f, 20f);
        InvokeRepeating("Group2", 30f, 14f);
        InvokeRepeating("Group3", 60f, 24f);
        InvokeRepeating("Group4", 120f, 20f);
        InvokeRepeating("Group5", 240f, 26f);
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

    private void Group1()
    {
        unitQueue.Enqueue(swordsman);
        unitQueue.Enqueue(swordsman);
    }

    private void Group2()
    {
        CancelInvoke("Group1");
        unitQueue.Enqueue(swordsman);
        unitQueue.Enqueue(archer);
    }

    private void Group3()
    {
        CancelInvoke("Group2");
        unitQueue.Enqueue(guard);
        unitQueue.Enqueue(guard);
        unitQueue.Enqueue(guard);
    }

    private void Group4()
    { 
        CancelInvoke("Group3");
        unitQueue.Enqueue(guard);
        unitQueue.Enqueue(wizard);
        unitQueue.Enqueue(archer);
    }

    private void Group5()
    {
        CancelInvoke("Group4");
        unitQueue.Enqueue(guard);
        unitQueue.Enqueue(archer);
        unitQueue.Enqueue(wizard);
        unitQueue.Enqueue(swordsman);
    }
}
