using UnityEngine;

public class HealtbarController : MonoBehaviour
{
    private Transform bar;

    public void SetHealth(float health)
    {
        if (bar == null)
            bar = this.GetComponent<Transform>();
        bar.localScale = new Vector3(health, 1f);
    }
}
