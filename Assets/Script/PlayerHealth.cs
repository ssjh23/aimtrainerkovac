using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public void Damage(float damage)
    {
        health -= damage;
    }

    public void Targetdead()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public GameObject healthBarUI;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if(health <= 0)
        {
            health = 0;
            Targetdead();
            
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }

       
    }
    public float CalculateHealth()
        {
            return health/maxHealth;
        }

}