using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Character : MonoBehaviour
{
    // Set variables and function to use in Stats_Player

    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected bool isDead;

    private void Start()
    {
        InitVariables(100);
    }
    public virtual void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;
            Die();
        }
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }
    public void Die()
    {
        isDead = true;
    }
    private void SetHealthTo(int healthToSet)
    {
        health = healthToSet;
        CheckHealth();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckHealth();
    }
    public void Heal(int heal)
    {
        health += heal;
        CheckHealth();
    }
    public void InitVariables(int _maxHealth)
    {
        maxHealth = _maxHealth;
        SetHealthTo(maxHealth);
        isDead = false;
    }
}
