using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeStaminaValues : MonoBehaviour //buttonlarin textlerinde
{
    [SerializeField] AttackSO attackType, passType;

    [SerializeField] bool pass;

    private void Start()
    {
        TakeStaminaValue();
    }
    public void TakeStaminaValue()
    {
        if(pass) // heavy attack �n staminasi kadar artacak
        {
            passType.increaseStamina = attackType.consumeMaxStamina;

            GetComponent<TextMeshProUGUI>().text = "+" + attackType.consumeMaxStamina.ToString();
            return;
        }

        GetComponent<TextMeshProUGUI>().text = "-" + attackType.consumeMaxStamina.ToString();

    }
}
