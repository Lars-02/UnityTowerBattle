using System;
using System.Collections;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public GameObject healthbar;
    public int maxHealth = 1000;
    public int health = 1000;
    public int armor = 40;
    private HealthbarController healthbarController;

    private Animator _animator;
    private bool _isAttacking;

    void Start()
    {
        if (maxHealth < health)
            health = maxHealth;
        _animator = GetComponent<Animator>();
        healthbarController = Instantiate(healthbar, this.transform).GetComponentInChildren<HealthbarController>();
    }

    public void OnTriggerEnter2D(Collider2D otherObject)
    {
        UnitController unit = otherObject.GetComponent<UnitController>();
        if (unit.IsOwnBase(this.tag) || _isAttacking)
            return;
        StartCoroutine(Fight(unit));
    }

    private IEnumerator Fight(UnitController attacker)
    {
        _isAttacking = true;
        attacker.AttackingBase(true);
        while (attacker != null && health > 0 && attacker.health > 0)
        {
            attacker.AttackAnimation();
            ReceiveDamage(attacker);
            yield return new WaitForSeconds(2);
        }
        _isAttacking = false;
        attacker.AttackingBase(false);
    }

    public void ReceiveDamage(UnitController attacker)
    {
        health -= Math.Max(attacker.damage - (int)(Math.Max(Math.Min((armor - attacker.piercing) / 100, 1), 0) * attacker.damage), 10);
        healthbarController.SetHealth((float)health / maxHealth);
        if (health <= 0)
            EndGame();
    }

    private void EndGame()
    {
        Debug.LogError("Game has ended");
    }
}
