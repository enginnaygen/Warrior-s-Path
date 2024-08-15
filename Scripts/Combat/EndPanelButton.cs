using System.Collections;
using UnityEngine;

public class EndPanelButton : MonoBehaviour // winPanelde ve lostPanelde ana menuye donerken kullanilan methodlar burada
{
    [SerializeField] DataContainer playerDataContainer;
    EnemyData dataAboutWinLose;

    [Header("Money Settings")]
    [SerializeField] internal int winMoney, lostMoney, winAfterLostMoney, firstWinMoney;
    [Header("XP Settings")]
    [SerializeField] internal int winXP, lostXP, firstWinXP;

    //[SerializeField] TextMeshProUGUI winPanelMoney, winPanelXP, lostPanelMoney, lostPanelXP;

    private void Start()
    {
        StartCoroutine(GetData());
    }
    public void IncreaseWinValue()
    {
        dataAboutWinLose.howManyWin++;
        PlayerPrefs.SetInt("wins" + dataAboutWinLose.name, dataAboutWinLose.howManyWin); //ismiyle kaydetsek ismiyle cagirsak olur mu??
    }

    public void IncreseXPValue()
    {
        if(dataAboutWinLose.howManyWin<1)
        {
            playerDataContainer.XP += firstWinXP;
            //winPanelXP.text = "+" + firstWinXP + " XP";
        }
        else
        {
            playerDataContainer.XP += winXP;
            //winPanelXP.text = "+" + winXP + " XP";

        }
        PlayerPrefs.SetInt("XP", playerDataContainer.XP);

    }

    public void IncreaseMoneyValue()
    {
        int hitCount = FindObjectOfType<PlayerAttack>().CallHitCount();

        if (dataAboutWinLose.howManyWin < 1)
        {

            playerDataContainer.money += firstWinMoney + hitCount;
            //winPanelMoney.text = "+" + firstWinMoney + " Money";

        }
        else
        {
            playerDataContainer.money += winMoney + hitCount ;
            //winPanelMoney.text = "+" + winMoney + " Money";


        }
        PlayerPrefs.SetInt("money", playerDataContainer.money);
    }

    public void LostIncreaseMoney()
    {
        int hitCount = FindObjectOfType<PlayerAttack>().CallHitCount();

        if (dataAboutWinLose.howManyWin < 1)
        {
            playerDataContainer.money += lostMoney + hitCount;
            //lostPanelMoney.text = "+" + lostMoney + " Money";

        }
        else
        {
            playerDataContainer.money += winAfterLostMoney + hitCount;
            //lostPanelMoney.text = "+" + winAfterLostMoney + " Money";


        }
        PlayerPrefs.SetInt("money", playerDataContainer.money);
    }

    public void LostIncreaseXP()
    {
        if (dataAboutWinLose.howManyWin < 1)
        {
            playerDataContainer.XP += lostXP;
            //lostPanelMoney.text = "+" + lostXP + " XP";

        }

        PlayerPrefs.SetInt("XP", playerDataContainer.XP);
    }

    IEnumerator GetData() // bekleyerek aliyorum cunku bir saniye gec olusuyor dusma sahnede
    {
        yield return new WaitForSeconds(0.5f); // bu deger buyuk olursa dusmanin datasini almadan dusman olursa nullexception oluyor
        dataAboutWinLose = FindObjectOfType<Enemy>().ReturnEnemyData();

    }
}
