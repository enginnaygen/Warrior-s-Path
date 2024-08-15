using TMPro;
using UnityEngine;

public class UpdateValues : MonoBehaviour //main menude verilerin guncellenmesi
{
    [SerializeField] DataContainer dataContainer;
    [SerializeField] AttackSO lightAttack, mediumAttack, heavyAttack;
    [SerializeField] TextMeshProUGUI moneyText, XPText, healthText, staminaText, lightAttackText, mediumAttackText, heavyAttackText, avoidText, healthPotion;
    // Start is called before the first frame update
    void Start()
    {
        /*if (PlayerPrefs.GetInt("money") != 0)
        {
            dataContainer.Money = PlayerPrefs.GetInt("money");
        }*/
        
        if (PlayerPrefs.HasKey("XP"))
        {
            dataContainer.XP = PlayerPrefs.GetInt("XP");
        }
        else
        {
            dataContainer.XP = 0;
        }

        
        UpdateValue();
    }

  

    public void UpdateValue() //burasi yetenek alimlarinda kullanilacakk
    {
        moneyText.text = "Money: " + dataContainer.money.ToString();
        XPText.text = "XP: " + dataContainer.XP.ToString();
        healthText.text = "Health: " + dataContainer.health.ToString();
        staminaText.text = "Stamina: " + dataContainer.stamina.ToString();
        avoidText.text = "Avoid: " + dataContainer.avoid + "/" + 50 + "%";

        lightAttackText.text = lightAttack.minHitAmount + "-" + lightAttack.maxHitAmount; /*+ "\n"+ lightAttack.consumeMinStamina +"-"+ lightAttack.consumeMaxStamina;*/
        mediumAttackText.text = mediumAttack.minHitAmount + "-" + mediumAttack.maxHitAmount;
        heavyAttackText.text = heavyAttack.minHitAmount + "-" + heavyAttack.maxHitAmount;

        healthPotion.text = "x" + dataContainer.healthPotion;

    }
}
