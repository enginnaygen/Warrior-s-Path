using UnityEngine;

public class RestartGame : MonoBehaviour
{

    [SerializeField] AttackSO lightAttack, mediumAttack, heavyAttack, pass, criticalAttack;
    [SerializeField] DataContainer playerData;
    [SerializeField] EnemyData[] enemyDatas;

   
    public void ArrangeCardsAgain()  //ilk kart acik geliyor aslinda gelmemeli neden oyle oluyoor ???? anladim cevabi CardButtonController'da
    {
        for (int i = 0; i < enemyDatas.Length - 1 ; i++) 
        {
            enemyDatas[i].howManyWin = 0;

            PlayerPrefs.SetInt("wins" + enemyDatas[i].name, 0);
            //obje.GetComponent<Button>().interactable = false;
        }


        //for (int i = 0; i < animalPanel.childCount; i++)
        //{
        //    GameObject obje = animalPanel.GetChild(i).gameObject;
        //    obje.GetComponent<Button>().interactable = false;
        //}

        //for (int i = 0; i < robotPanel.childCount; i++)
        //{
        //    GameObject obje = robotPanel.GetChild(i).gameObject;
        //    obje.GetComponent<Button>().interactable = false;
        //}


    }
    public void RestartValues()
    {
        if (PlayerPrefs.HasKey("Stamina"))
        {
            PlayerPrefs.SetInt("Stamina", 10);
        }
       

        if (PlayerPrefs.HasKey("Health"))
        {
            PlayerPrefs.SetInt("Health", 10);
        }
      
        if (PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetInt("money", 50);
        }

        if (PlayerPrefs.HasKey("XP"))
        {
            PlayerPrefs.SetInt("XP", 0);
        }
       



        if (PlayerPrefs.HasKey("openPass") && PlayerPrefs.GetInt("openPass") == 1)
        {
            PlayerPrefs.SetInt("openPass", 0);
        }


        if (PlayerPrefs.HasKey("openCritical") && PlayerPrefs.GetInt("openCritical") == 1)
        {
            PlayerPrefs.SetInt("openCritical", 0);
        }

        if (PlayerPrefs.HasKey("minHitAmount" + lightAttack) && PlayerPrefs.HasKey("maxHitAmount" + lightAttack))
        {
            PlayerPrefs.SetInt("minHitAmount" + lightAttack, 1);
            PlayerPrefs.SetInt("maxHitAmount" + lightAttack, 3);
        }
       
        if (PlayerPrefs.HasKey("minConsumeAmount" + lightAttack) && PlayerPrefs.HasKey("maxConsumeAmount" + lightAttack))
        {
            PlayerPrefs.SetInt("minConsumeAmount" + lightAttack, 2);
            PlayerPrefs.SetInt("maxConsumeAmount" + lightAttack, 2);
        }
       
        if (PlayerPrefs.HasKey("minHitAmount" + mediumAttack) && PlayerPrefs.HasKey("maxHitAmount" + mediumAttack))
        {
            PlayerPrefs.SetInt("minHitAmount" + mediumAttack, 3);
            PlayerPrefs.SetInt("maxHitAmount" + mediumAttack, 5);
        }
      
        if (PlayerPrefs.HasKey("minConsumeAmount" + mediumAttack) && PlayerPrefs.HasKey("maxConsumeAmount" + mediumAttack))
        {
            PlayerPrefs.SetInt("minConsumeAmount" + mediumAttack, 3);
            PlayerPrefs.SetInt("maxConsumeAmount" + mediumAttack, 3);
        }
        
        if (PlayerPrefs.HasKey("minHitAmount" + heavyAttack) && PlayerPrefs.HasKey("maxHitAmount" + heavyAttack))
        {
            PlayerPrefs.SetInt("minHitAmount" + heavyAttack, 5);
            PlayerPrefs.SetInt("maxHitAmount" + heavyAttack, 7);


        }
      

        if (PlayerPrefs.HasKey("minConsumeAmount" + heavyAttack) && PlayerPrefs.HasKey("maxConsumeAmount" + heavyAttack))
        {
            PlayerPrefs.SetInt("minConsumeAmount" + heavyAttack, 5);
            PlayerPrefs.SetInt("maxConsumeAmount" + heavyAttack, 5);
        }
       

        if (PlayerPrefs.HasKey("minHitAmount" + criticalAttack) && PlayerPrefs.HasKey("maxHitAmount" + criticalAttack))
        {
            PlayerPrefs.SetInt("minHitAmount" + criticalAttack, 15);
            PlayerPrefs.SetInt("maxHitAmount" + criticalAttack, 20);
        }
      

        if (PlayerPrefs.HasKey("minConsumeAmount" + criticalAttack) && PlayerPrefs.HasKey("maxConsumeAmount" + criticalAttack))
        {
            PlayerPrefs.SetInt("minConsumeAmount" + criticalAttack, 13);
            PlayerPrefs.SetInt("maxConsumeAmount" + criticalAttack, 13);
        }
      

        if (PlayerPrefs.HasKey("avoid"))
        {
            PlayerPrefs.SetInt("avoid", 0);

        }
       

        if (PlayerPrefs.HasKey("healthPotion"))
        {
            PlayerPrefs.SetInt("healthPotion", 0);
        }     
    }

    public void DecreasePossibilityHits()
    {
        if(lightAttack.hitPosibility >= 70)
        {
            lightAttack.hitPosibility -= 5;
           
            PlayerPrefs.SetInt("hitPossibility" + lightAttack.name, lightAttack.hitPosibility);

        }
       
        if(mediumAttack.hitPosibility >=60)
        {
            mediumAttack.hitPosibility -= 5;

            PlayerPrefs.SetInt("hitPossibility" + mediumAttack.name, mediumAttack.hitPosibility);

        }
       
        if(heavyAttack.hitPosibility >=50)
        {
            heavyAttack.hitPosibility -= 5;

            PlayerPrefs.SetInt("hitPossibility" + heavyAttack.name, heavyAttack.hitPosibility);

        }
      
    }
}
