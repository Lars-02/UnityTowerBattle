using System;
using System.Collections;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public GameObject healthbar;
    public int health = 2000;
    public int armor = 40;

    private HealthbarController healthbarController;
    private int maxHealth;
    private bool isAttacking;
    private bool invulnerable;

    void Start()
    {
        maxHealth = health;
        healthbarController = Instantiate(healthbar, this.transform).GetComponentInChildren<HealthbarController>();
        InvokeRepeating("HealBase", 2f, 1f);
    }

    public void OnTriggerEnter2D(Collider2D otherObject)
    {
        UnitController unit = otherObject.GetComponent<UnitController>();
        if (unit.IsOwnBase(this.tag) || isAttacking)
            return;
        StartCoroutine(Fight(unit));
    }

    private void HealBase()
    {
        health += 1;
        if (health < 1000)
            health += 1;
        if (health < 500)
            health += 1;
        if (health < 200)
            health += 2;
        if (health > maxHealth)
            health = maxHealth;
    }

    private IEnumerator Fight(UnitController attacker)
    {
        isAttacking = true;
        attacker.AttackingBase(true);
        while (attacker != null && health > 0 && attacker.health > 0 && !invulnerable)
        {
            attacker.AttackAnimation();
            ReceiveDamage(attacker);
            yield return new WaitForSeconds(2);
        }
        isAttacking = false;
        attacker.AttackingBase(false);
    }

    public void ReceiveDamage(UnitController attacker)
    {
        health -= Math.Max(attacker.damage - (int)(Math.Max(Math.Min((armor - attacker.piercing) / 100, 1), 0) * attacker.damage), 10);
        healthbarController.SetHealth((float)health / maxHealth);
        if (health <= 0)
            GetComponentInParent<GameHandler>().EndGame(this.tag);
    }

    public void MakeInvulnerable()
    {
        CancelInvoke("HealBase");
        invulnerable = true;
    }
}
