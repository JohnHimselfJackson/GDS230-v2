using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float armour;
    public Slider healthSlider;
    public Animator heartBeatAnim;

    public void Damage(float damage)
    {
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
