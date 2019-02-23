using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int healthPoints = 100;
    private int maxHealth;
    [SerializeField] Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentHealth()
    {
        return healthPoints;
    }

    public void Damage(int damage)
    {
        healthPoints -= damage;
        if (healthBar)
        {
            UpdateHealthBar();
        }

        if (healthPoints < 0) healthPoints = 0;
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)healthPoints / (float)maxHealth;
    }
}
