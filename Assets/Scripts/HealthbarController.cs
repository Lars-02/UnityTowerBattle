using System;
using UnityEngine;

public class HealthbarController : MonoBehaviour
{
    private Transform bar;

    public void SetHealth(float health)
    {
        if (bar == null)
            bar = this.GetComponent<Transform>();
        bar.localScale = new Vector3(Math.Max(health, 0), 1f);
    }
}
