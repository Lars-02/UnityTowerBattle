using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private bool filled;
    private GameHandler gameHandler;

    public void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (!this.CompareTag(otherObject.tag))
        {
            filled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D otherObject)
    {
        if (!this.CompareTag(otherObject.tag))
        {
            filled = false;
        }
    }

    public bool SpawnUnit(GameObject unit)
    {
        if (filled)
            return false;

        Instantiate(unit, this.transform);
        return true;
    }

    public void GetLoot(int loot)
    {
        if (gameHandler == null)
            gameHandler = GetComponentInParent<GameHandler>();
        gameHandler.gold += loot;
    }
}
