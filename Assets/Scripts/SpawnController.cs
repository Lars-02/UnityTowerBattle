using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public bool filled;

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
}
