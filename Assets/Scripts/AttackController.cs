using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private Animator _animator;
    private UnitController _unit;

    private bool _isAttacking;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _unit = GetComponent<UnitController>();
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (this.CompareTag(otherObject.tag) || _isAttacking)
            return;
        StartCoroutine(Fight(otherObject.GetComponent<UnitController>()));
    }

    private IEnumerator Fight(UnitController enemy)
    {
        _isAttacking = true;
        while (enemy != null && _unit.health > 0 && enemy.health > 0)
        {
            enemy.ReceiveDamage(_unit.damage);
            _unit.ReceiveDamage(enemy.damage);
            enemy.AttackAnimation();
            _unit.AttackAnimation();
            yield return new WaitForSeconds(2);
        }
        _isAttacking = false;
    }
}
