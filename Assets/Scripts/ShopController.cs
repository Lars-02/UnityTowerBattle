using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public GameObject spawner;

    private GameHandler gameHandler;
    private Queue<GameObject> unitQueue = new Queue<GameObject>();
    private SpawnController spawnerController;
    private bool closed;

    void Start()
    {
        gameHandler = GetComponentInParent<GameHandler>();
        spawnerController = spawner.GetComponent<SpawnController>();
        InvokeRepeating("CallSpawner", 2.0f, 0.1f);
    }

    public void AddUnitToQueue(GameObject unit)
    {
        if (closed)
            return;
        UnitController unitController = unit.GetComponent<UnitController>();
        if (unitController.cost > gameHandler.gold)
            return;
        gameHandler.gold -= unitController.cost;
        unitQueue.Enqueue(unit);
    }

    private void CallSpawner()
    {
        if (unitQueue.Count <= 0)
            return;
        if (spawnerController.SpawnUnit(unitQueue.Peek()))
            unitQueue.Dequeue();
    }

    public void CloseShop()
    {
        CancelInvoke("CallSpawner");
        closed = true;
    }
}
