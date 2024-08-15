using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowStamina : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerStamina, enemyStamina;
    [SerializeField] Slider playerStaminaSlider, enemyStaminaSlider;
    [SerializeField] DataContainer playerData;

    private void Start()
    {
        StartCoroutine(Wait());
        
    }
    public void ShowStaminas()
    {
        playerStaminaSlider.value = FindObjectOfType<Player>().GetComponent<Stamina>().GetStaminaAmount();
        enemyStaminaSlider.value = FindObjectOfType<Enemy>().GetComponent<Stamina>().GetStaminaAmount();
        playerStamina.text = "Stamina: " + FindObjectOfType<Player>().GetComponent<Stamina>().GetStaminaAmount().ToString();
        enemyStamina.text = "Stamina: " + FindObjectOfType<Enemy>().GetComponent<Stamina>().GetStaminaAmount().ToString();

        if (!playerStamina.gameObject.activeInHierarchy && !enemyStamina.gameObject.activeInHierarchy)
        {
            playerStamina.gameObject.SetActive(true);
            enemyStamina.gameObject.SetActive(true);
        }
    }

        private void Update()
        {
            //ShowStaminas();
        }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);

        playerStaminaSlider.maxValue = playerData.stamina;
        enemyStaminaSlider.maxValue = FindObjectOfType<Enemy>().GetComponent<Stamina>().GetStaminaAmount();

        ShowStaminas();
    }
} 

