using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public int health = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            EndGame();
    }

    private void EndGame()
    {
        Debug.LogError("Game has ended");
    }
}
