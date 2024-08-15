using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotion : MonoBehaviour // bu healthPotion buttonunun ustunde, combatta iciliyor
{
    [SerializeField] TextMeshProUGUI healthPotionAmount;
    [SerializeField] DataContainer playerData;
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] AudioClip drinkSFX;
    void Start()
    {
        healthPotionAmount.text = "x" + playerData.healthPotion;
    }

    public void UseHealthPotion()
    {
        if (playerData.healthPotion > 0 && playerHealthSlider.maxValue > FindObjectOfType<Player>().GetComponent<Health>().GetHealth())
        {
            playerData.healthPotion -= 1;
            healthPotionAmount.text = "x" + playerData.healthPotion;
            FindObjectOfType<Player>().GetComponent<Health>().IncreaseHealth(2); // bu sonradan ayarlanabilir

            AudioSource.PlayClipAtPoint(drinkSFX, Camera.main.transform.position,0.5f);


            /*if (playerHealthSlider.maxValue < FindObjectOfType<Player>().GetComponent<Health>().GetHealth())
            {
                FindObjectOfType<Player>().GetComponent<Health>().EqualMaxHealth((int)playerHealthSlider.maxValue);
            }*/


            FindObjectOfType<ShowHealths>().ShowHealth();

            PlayerPrefs.SetInt("healthPotion", playerData.healthPotion);

        }

    }
}
