using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSysteme : MonoBehaviour
{

    private int health;
    private int maxHealth;

    

    public HealthSysteme(int health)
    {
        this.health = health;
        this.maxHealth = 100;
    }
    

    public int gethealth()
    {
        return health;
    }


    public void damage(int damage)
    {
        health -= damage;

        if(health < 0)
        {
            health = 0;
            
            Debug.Log("Tod");
        }
    }

    public void heal(int heal)
    {
        health += heal;
       if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void setHealth(int health)
    {
        this.health = health;
    }
}
