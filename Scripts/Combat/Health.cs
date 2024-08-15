using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int healthAmount;
    [SerializeField] DataContainer healthValues;
    [SerializeField] bool player;

    private void Start()
    {
        if(player)
        {
            healthAmount = healthValues.health;

        }
    }
    public int GetHealth()
    {
        return healthAmount;
    }

    public void DecreaseHealth(int minDecreaseAmount, int maxDecreaseAmount)
    {
        int decreaseAmount = Random.Range(minDecreaseAmount, maxDecreaseAmount);
        healthAmount -= decreaseAmount;
    }

    public void IncreaseHealth(int increaseAmount)
    {
        healthAmount += increaseAmount;
    }

    public void EqualMaxHealth(int maxHealth)
    {
        healthAmount = maxHealth;
    }

    /*public void UpdateHealthValue(int improveAmount)
    {
        healthAmount += improveAmount;
    }*/
}
