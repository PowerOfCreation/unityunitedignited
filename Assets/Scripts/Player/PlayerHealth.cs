using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health, IDamagable
{
    private int maxPlayerHealth;

    public void Start()
    {
        maxPlayerHealth = health;
    }

    public override void GetDamage(int damage)
    {
        health -= damage;
        UpdateHealthSlider();

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(int amount)
    {
        health += amount;
        health = (health > maxPlayerHealth)?maxPlayerHealth:health;
        UpdateHealthSlider();
    }

    public override void Die()
    {
        GameStateManager.Instance.SetGameState(GameStateManager.GameState.Over);
    }

    protected virtual void UpdateHealthSlider()
    {
        HealthSlider.self.slider.value = health; 
    }
}
