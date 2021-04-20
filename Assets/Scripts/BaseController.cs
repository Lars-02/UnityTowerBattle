using System.Collections;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public GameObject healthbar;
    public int health = 1000;

    private Animator _animator;
    private bool _isAttacking;

    void Start()
    {
        _animator = GetComponent<Animator>();
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
            ReceiveDamage(attacker.damage);
            yield return new WaitForSeconds(2);
        }
        _isAttacking = false;
        attacker.AttackingBase(false);
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
