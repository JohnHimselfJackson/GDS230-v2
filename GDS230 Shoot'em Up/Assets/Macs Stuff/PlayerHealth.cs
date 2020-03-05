using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float armour;

    public void Damage(float damage)
    {
        //Takes damage from health
        health = health - damage;

        if (health <= 0)
        {
            //Invoke PlayerDead for animation duration
            PlayerDead();
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
}
