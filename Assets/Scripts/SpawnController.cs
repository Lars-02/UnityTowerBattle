using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private bool filled;

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
        GetComponentInParent<GameHandler>().gold += loot;
    }
}
