using TMPro;
using UnityEngine;

public class EndPanelTextArrangenment : MonoBehaviour //winPanelde ve lostPanelde oyun sonu cikacak verilerin gosterilmesi
{
    EnemyData dataAboutWinLose;
    EndPanelButton endPanelButton;

    [SerializeField] GameObject lostPanel, winPanel;


    [SerializeField] TextMeshProUGUI winPanelMoney, winPanelXP, lostPanelMoney, lostPanelXP;


    private void Start()
    {
        int hitCount = FindObjectOfType<PlayerAttack>().CallHitCount();

        GetData();

        if (winPanel.activeInHierarchy)
        {
            if (dataAboutWinLose.howManyWin < 1) // bu sekilde kontrol yapabiliyoruz cunku butona tikladiktan sonra howmanywin artýyor
            {
                winPanelMoney.text = "+" + (endPanelButton.firstWinMoney+hitCount) + " Money";
                winPanelXP.text = "+" + endPanelButton.firstWinXP + " XP";
            }
            else
            {
                winPanelMoney.text = "+" + (endPanelButton.winMoney+hitCount) + " Money";
                winPanelXP.text = "+" + endPanelButton.winXP + " XP";
            }

        }

        if (lostPanel.activeInHierarchy)
        {
            if (dataAboutWinLose.howManyWin < 1)
            {
                lostPanelMoney.text = "+" + (endPanelButton.lostMoney+hitCount) + " Money";
                lostPanelXP.text = "+" + endPanelButton.lostXP + " XP";
            }
            else
            {
                lostPanelMoney.text = "+" + (endPanelButton.winAfterLostMoney+hitCount) + " Money";
                lostPanelXP.text = "No XP";
            }
        }


    }

    void GetData() // bekleyerek aliyorum cunku bir saniye gec olusuyor dusma sahnede
    {
        endPanelButton = FindObjectOfType<EndPanelButton>();
        dataAboutWinLose = FindObjectOfType<Enemy>().ReturnEnemyData();

    }
}
