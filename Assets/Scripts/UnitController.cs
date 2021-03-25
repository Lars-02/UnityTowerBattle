using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private Animator _animator;

    private bool isWalking = true;
    private bool isAttackingBase = false;
    public int health = 100;
    public int armor = 10;
    public int damage = 10;
    public float speed = 1f;


    void Start()
    {
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

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            StartCoroutine(Die());
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger("doAttack");
    }

    private IEnumerator Die()
    {
        _animator.SetTrigger("doDie");
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    private bool IsOwnBase(string colliderTag)
    {
        if (colliderTag == "PlayerBase" && this.CompareTag("Player") || colliderTag == "EnemyBase" && this.CompareTag("Enemy"))
            return true;
        return false;
    }

    public bool IsAttackingBase()
    {
        return isAttackingBase;
    }
}
