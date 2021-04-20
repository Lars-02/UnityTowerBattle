using System;
using System.Collections;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public GameObject healthbar;
    private Animator _animator;
    private HealtbarController healthbarController;

    private bool isWalking = true;
    private bool isAttackingBase = false;
    public int cost = 100;
    public int loot = 80;
    public int healthMax = 100;
    public int health = 100;
    public int damage = 10;
    public int piercing = 10;
    public int armor = 10;
    public float speed = 1f;


    void Start()
    {
        if (healthMax < health)
            health = healthMax;
        healthbarController = Instantiate(healthbar, this.transform).GetComponentInChildren<HealtbarController>();
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("doMove");
    }

    void Update()
    {
        if (isWalking)
            transform.Translate(speed / 100, 0, 0);
    }

    public void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.isTrigger || IsOwnBase(otherObject.tag))
            return;
        if (otherObject.CompareTag("EnemyBase") || otherObject.CompareTag("PlayerBase"))
            isAttackingBase = true;
        isWalking = false;
    }

    public void OnTriggerExit2D(Collider2D otherObject)
    {
        if (otherObject.isTrigger || IsOwnBase(otherObject.tag) || isAttackingBase)
            return;
        isWalking = true;
        _animator.SetTrigger("doMove");
    }

    public void ReceiveDamage(UnitController attacker)
    {
        health -= Math.Max(damage - (int) (Math.Max(Math.Min((armor - attacker.piercing) / 100, 1), 0) * damage), 10);
        healthbarController.SetHealth((float)health / healthMax);
        if (health <= 0)
            StartCoroutine(Die());
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger("doAttack");
    }

    private IEnumerator Die()
    {
        GetComponentInParent<SpawnController>().GetLoot(this.loot);
        _animator.SetTrigger("doDie");
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    public bool IsOwnBase(string colliderTag)
    {
        if (colliderTag == "PlayerBase" && this.CompareTag("Player") || colliderTag == "EnemyBase" && this.CompareTag("Enemy"))
            return true;
        return false;
    }

    public void AttackingBase(bool attacking)
    {
        isAttackingBase = attacking;
    }

    public bool IsAttackingBase()
    {
        return isAttackingBase;
    }
}
