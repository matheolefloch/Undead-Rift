using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Player : Stats_Character
{
    private PlayerHUD hud;

    private void Start()
    {
        GetReferences();
        InitVariables(100);
    }
    private void GetReferences()
    {
        hud = GetComponent<PlayerHUD>();
    }
    public override void CheckHealth()
    {
        base.CheckHealth();
        hud.UpdateHealth(health, maxHealth);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
}
