using Mirror;
using System;
using UnityEngine;
using Zenject;

public class PlayerHealth : NetworkBehaviour
{
    private int _maxHealth;

    public int CurrentHealth { get; private set; }

    [Inject]
    private void Construct(PlayerConfigSO playerConfig)
    {
        _maxHealth = playerConfig.MaxHealth;
        CurrentHealth = _maxHealth;
    }

    public void GetDamage(int damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth < 0)
        {
            Death();
        }
    }

    private void Death()
    {
        CurrentHealth = _maxHealth;
    }
}