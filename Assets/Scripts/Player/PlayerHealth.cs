﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private ImplantAbility implant;

    public float health;
    public float maxHealth;
    public float armour;
    public Slider healthSlider;
    public Animator heartBeatAnim;

    void Start()
    {
        implant = FindObjectOfType<ImplantAbility>();    
    }

    public void Damage(float damage)
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");

        if (implant.shieldOn == true)
        {
            implant.DamageShield(damage);
            return;
        }

        //Takes damage from health
        health = health - damage;

        if (health <= 0)
        {
            //Invoke PlayerDead for animation duration
            PlayerDead();
        }
        else
        {
            print("player has " + health + " remaining"); 
        }
    }

    void PlayerDead()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        SceneManager.LoadScene(2);
        //Revive animation
        //Opt-in ads
        //End game menu
        //Pause Gameplay
    }

    public void Heal(float healAmount)
    {
        health += maxHealth * healAmount;
        
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    void Update()
    {
        healthSlider.value = health;

        if (health > 0)
        {
            //Beat();
        }
    }

    public void Beat()
    {
        heartBeatAnim.SetBool("Healthy", true);
    }
}
