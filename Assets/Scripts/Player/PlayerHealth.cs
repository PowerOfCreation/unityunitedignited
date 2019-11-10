using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health, IDamagable
{
    public int playerHealth = 10;

    public override void GetDamage(int damage)
    {
        playerHealth -= damage;
        HealthSlider.self.slider.value = playerHealth; 

        if (playerHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        GameStateManager.Instance.SetGameState(GameStateManager.GameState.Over);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
