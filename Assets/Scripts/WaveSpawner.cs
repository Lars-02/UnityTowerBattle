using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject archer;
    public GameObject swordsman;
    public GameObject guard;
    public GameObject wizard;

    public bool spawning;

    void Start()
    {
        InvokeRepeating("SpawnWave", 2f, 8f);
    }

    void SpawnWave()
    {
        if (!spawning)
            return;
        SpawnController spawnerController = spawner.GetComponent<SpawnController>();
        spawnerController.SpawnUnit(archer);
    }
}
