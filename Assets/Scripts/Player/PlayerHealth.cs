using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health, IDamagable
{
    private int maxPlayerHealth;
    public GameObject hurtPanel;
    public AudioClip healSoundFx;
    private AudioSource _audioSource;
    public AudioClip GameOverSoundFx;
    public GameObject _bgAudio;
    public void Start()
    {
        maxPlayerHealth = health;
        _audioSource = GetComponent<AudioSource>();
    }

    public override void GetDamage(int damage, Transform attackerTransform)
    {
        health -= damage;
        UpdateHealthSlider();
        if(takeDamage) {
            _audioSource.PlayOneShot(takeDamage, 0.4F);
        }
        if(hurtPanel){
            hurtPanel.GetComponent<HurtPanelController>().Show();
        }
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(int amount)
    {
        health += amount;
        health = (health > maxPlayerHealth)?maxPlayerHealth:health;
        if(healSoundFx) _audioSource.PlayOneShot(healSoundFx, .5f);
        UpdateHealthSlider();
    }

    public override void Die()
    {
        if(_bgAudio){
            _bgAudio.GetComponent<AudioSource>().clip = GameOverSoundFx;
            _bgAudio.GetComponent<AudioSource>().Play();    
        } 
        GameStateManager.Instance.SetGameState(GameStateManager.GameState.Over);
    }

    protected virtual void UpdateHealthSlider()
    {
        if(HealthSlider.self){
            HealthSlider.self.slider.value = health; 
        }
    }
}
