using UnityEngine;

public class UnitInstancer : MonoBehaviour
{
    public GameObject unit;
    public GameObject spawner;
    public int cost;

    private int InQueue;

    void Start()
    {
        InvokeRepeating("CallSpawner", 2.0f, 0.1f);
    }

    public void OnMouseDown()
    {
        InQueue++;
    }

    private void CallSpawner()
    {
        SpawnController spawnerController = spawner.GetComponent<SpawnController>();
        if (InQueue <= 0 || spawnerController.filled)
            return;
        if (spawnerController.SpawnUnit(unit))
            InQueue--;
    }
}
