using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieStats : Stats_Character
{
    [SerializeField]private int damage;
    public float attackSpeed;
    [SerializeField]private bool canAttack;


    private void Start()
    {
        InitVariables(30);
    }
    public void DealDamage(Stats_Character statsToDamage)
    {
        statsToDamage.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    public override void InitVariables(int _maxHealth)
    {
        maxHealth = _maxHealth;
        SetHealthTo(maxHealth);
        isDead = false;
        damage = 10;
        attackSpeed = 1.5f;
        canAttack = true;
    }
}
