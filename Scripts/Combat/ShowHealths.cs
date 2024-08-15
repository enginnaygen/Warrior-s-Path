using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowHealths : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI playerHealth, enemyHealth, healthPotion;
    [SerializeField] Slider playerHealthSlider, enemyHealthSlider;
    [SerializeField] DataContainer dataContainer;
    private void Start()
    {
        StartCoroutine(Wait());
    }
    public void ShowHealth()
    {

        playerHealthSlider.value = FindObjectOfType<Player>().GetComponent<Health>().GetHealth();
        enemyHealthSlider.value = FindObjectOfType<Enemy>().GetComponent<Health>().GetHealth();
        playerHealth.text = "Health: " + FindObjectOfType<Player>().GetComponent<Health>().GetHealth().ToString();
        enemyHealth.text = "Health: " + FindObjectOfType<Enemy>().GetComponent<Health>().GetHealth().ToString();

        if(!playerHealth.gameObject.activeInHierarchy && !enemyHealth.gameObject.activeInHierarchy)
        {
            playerHealth.gameObject.SetActive(true);
            enemyHealth.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        //ShowHealth();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);

        playerHealthSlider.maxValue = dataContainer.health;
        enemyHealthSlider.maxValue = FindObjectOfType<Enemy>().GetComponent<Health>().GetHealth();

        ShowHealth();
    }
}
