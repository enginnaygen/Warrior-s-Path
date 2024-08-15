using UnityEngine;
using UnityEngine.UI;

//combat kartlarinin kendinden sonraki karti algilamasi icin yapilan islemler var
public class CardButtonController : MonoBehaviour //beynimi yakti buralar kendim yazdim ama anlamakta ben zorlandim yaaa
{
    [SerializeField] EnemyData dataAboutWinLose;
    [SerializeField] Button afterButton; // 1)teker teker atama yapmaya gerek kalmadi yuppii
    [SerializeField] bool lastCardHuman,lastCardAnimal;
    [SerializeField] GameObject enemyPanelHuman, enemyPanelAnimal, enemyPanelRobot;
    //int indis;

    [SerializeField] int closeEnemyCardAfterHowManyWin = 5;

    // scene baslarken ilk kartin intractable ý true hep true geliyor 1 ile 5 arasinda ise de true 5'tten buyukse false, yani 0 oldugunda her hangi bir komut yok, o yuzdden ilk scene geldiginde etkilenmiyor ve true olarak basliyor, sonunda anladim
    void Start()
    {
        GiveAfterButtonReference(); // 2) sunu kesfedebildigim icinn
                                    //Debug.Log(transform.GetSiblingIndex());



        //if (dataAboutWinLose.howManyWin != 0 ) bu yanlýs oldu oyun her kapanip acildiginda kartlar kapaniyor
        if (PlayerPrefs.HasKey("wins" + dataAboutWinLose.name)) // GetInt(..) !=0 idi
        {
            dataAboutWinLose.howManyWin = PlayerPrefs.GetInt("wins" + dataAboutWinLose.name);
        }
        else
        {
            dataAboutWinLose.howManyWin = 0;
        }

        if (dataAboutWinLose.howManyWin < closeEnemyCardAfterHowManyWin && dataAboutWinLose.howManyWin >=1) //howmanywin 1-2 ise true kendinden sonraki de true
        {
            //dataAboutWinLose.howManyWin = PlayerPrefs.GetInt("wins" + dataAboutWinLose.name);
            GetComponent<Button>().interactable = true;
            if(afterButton != null)
            {
                afterButton.interactable = true;
            }

            /*if (afterButton.GetComponent<ButtoonController>().dataAboutWinLose.howManyWin >= 3)
            {
                afterButton.interactable = false;

            }*/

        }

        if (dataAboutWinLose.howManyWin >= closeEnemyCardAfterHowManyWin) // 5 ise kendi false
        {
            //Debug.Log("Kapandý");
            GetComponent<Button>().interactable = false;

            if (afterButton.GetComponent<CardButtonController>().dataAboutWinLose.howManyWin < closeEnemyCardAfterHowManyWin)
            {
                afterButton.interactable = true;

            }


            //PlayerPrefs.SetInt("wins", 0);
        }

        if(lastCardHuman && dataAboutWinLose.howManyWin >=1)
        {
            enemyPanelAnimal.SetActive(true);
            enemyPanelHuman.SetActive(false);
        }

        if (lastCardAnimal && dataAboutWinLose.howManyWin >= 1)
        {
            enemyPanelRobot.SetActive(true);
            enemyPanelAnimal.SetActive(false);
        }
    }


    public void GiveAfterButtonReference()
    {
        int childIndex = transform.GetSiblingIndex() + 1; //siblingi degil kendi indexini veriyor neden anlamadim?? ondan +1 dedim

        if (childIndex > GetComponentInParent<GridLayoutGroup>().transform.childCount - 1) // cunku index icin -1 yaptýk
            return;
           afterButton = GetComponentInParent<GridLayoutGroup>().transform.GetChild(childIndex).GetComponent<Button>();
        

    }

    public int ReturnIndis()
    {

        int childIndex = transform.GetSiblingIndex() + 1;
        return childIndex;

    }

}
