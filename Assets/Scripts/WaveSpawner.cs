using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject archer;

    public bool spawning;

    void Start()
    {
        InvokeRepeating("SpawnWave", 2.0f, 1f);
    }

    void SpawnWave()
    {
        if (!spawning)
            return;
        SpawnController spawnerController = spawner.GetComponent<SpawnController>();
        spawnerController.SpawnUnit(archer);
    }
}
