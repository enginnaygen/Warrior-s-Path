using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stamina : MonoBehaviour
{

    [SerializeField] int staminaAmmount;
    [SerializeField] DataContainer staminaValues;
    [SerializeField] public TextMeshProUGUI infoStaminaPlayer, infoStaminaEnemy;


    [SerializeField] bool player;
    // Start is called before the first frame update
    void Start()
    {
        infoStaminaPlayer = FindObjectOfType<PlayerNotEnoughStamina>().GetComponent<TextMeshProUGUI>();
        infoStaminaEnemy = FindObjectOfType<EnemyNotEnoughStamina>().GetComponent<TextMeshProUGUI>();

        if(player)
        {
            staminaAmmount = staminaValues.stamina;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseStamina(int consumeMinStamina, int consumeMaxStamina)
    {
        staminaAmmount -= Random.Range(consumeMinStamina, consumeMaxStamina);
    }

    public void IncreaseStamina(int increaseAmount)
    {
        //staminaAmmount = 0;
        staminaAmmount += increaseAmount;
    }

    public int GetStaminaAmount()
    {
        return staminaAmmount;
    }

    public void EqualMaxStamina(int maxStaminaValue)
    {
        staminaAmmount = maxStaminaValue;
    }

    /*public void UpdateStaminaValue(int improveAmount)
    {
        staminaAmmount += improveAmount;
    }*/
}
