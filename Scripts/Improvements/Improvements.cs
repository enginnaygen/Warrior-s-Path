using System.Collections;
using TMPro;
using UnityEngine;


//en uzun script, gelistirmeler var ve cook uzun oldu en karisik script olabilir, startinda bir suru veri kontrolu yapiyor
//bir bozukluk oldugunda en bas agritacak yer gibi duruyor
public class Improvements : MonoBehaviour //her gelistirmeye ayri metod yazacaksam isim yas, improvementlari ayri scriptlere ayiracagim
{
    [SerializeField] AttackSO lightAttack, mediumAttack, heavyAttack, pass, criticalAttack;
    [SerializeField] DataContainer playerData;

    [SerializeField] int improvementXPValue;
    [SerializeField] int improvementMoneyValue;

    [SerializeField] int healtImprove, staminaImporve;

    [SerializeField] TextMeshProUGUI errorText;

    [SerializeField] UpdateValues updateValues;

    [SerializeField] AudioClip error, coin;

    
    void Start()
    {

        CallKeys();
        
    }

    public void ImproveLightAttackHitAmount(int improveFactor) // bu sekilde olmazsa punch kick, head icin teker teker metod yazacagim
    {
        if (playerData.XP >= improvementXPValue * improveFactor && playerData.money >= improvementMoneyValue + improveFactor && lightAttack.maxHitAmount + improveFactor / 5 < mediumAttack.maxHitAmount) //&& lightAttack.maxHitAmount + improveFactor / 5 < heavyAttack.minHitAmount ) // bu sekilde heavy attack ile medium atagi light attack gecemeyecek
        {
            lightAttack.minHitAmount +=  improveFactor/5; 
            lightAttack.maxHitAmount +=  improveFactor/5; 
            playerData.money -= improvementMoneyValue + improveFactor;
            PurchasedSFX();

            if (lightAttack.maxHitAmount > 8) 
            {
                lightAttack.consumeMaxStamina += 1;
                lightAttack.consumeMinStamina += 1;

                PlayerPrefs.SetInt("minConsumeAmount" + lightAttack, lightAttack.consumeMinStamina);
                PlayerPrefs.SetInt("maxConsumeAmount" + lightAttack, lightAttack.consumeMaxStamina);

            }
        }
        else
        {
            ErrorSFX();
        }

        
        /*else if(lightAttack.maxHitAmount >= mediumAttack.minHitAmount && lightAttack.maxHitAmount >= heavyAttack.minHitAmount)
        {
            StartCoroutine(CallErrorText());
        }*/

            PlayerPrefs.SetInt("minHitAmount" + lightAttack, lightAttack.minHitAmount);
            PlayerPrefs.SetInt("maxHitAmount" + lightAttack, lightAttack.maxHitAmount);

            PlayerPrefs.SetInt("money", playerData.money);
            PlayerPrefs.SetInt("XP", playerData.XP);

            updateValues.UpdateValue();
    }
    
    public void ImproveMediumAttackHitAmount(int improveFactor) 
    {
        if (playerData.XP >= improvementXPValue * improveFactor && playerData.money >= improvementMoneyValue + improveFactor && mediumAttack.maxHitAmount + improveFactor / 5 < heavyAttack.maxHitAmount)
        {
            mediumAttack.minHitAmount +=  improveFactor/5; 
            mediumAttack.maxHitAmount +=  improveFactor/5; 
            playerData.money -= improvementMoneyValue + improveFactor;
            PurchasedSFX();

            if (mediumAttack.maxHitAmount > 10)
            {
                mediumAttack.consumeMaxStamina += 1;
                mediumAttack.consumeMinStamina += 1;

                PlayerPrefs.SetInt("minConsumeAmount" + mediumAttack, mediumAttack.consumeMinStamina);
                PlayerPrefs.SetInt("maxConsumeAmount" + mediumAttack, mediumAttack.consumeMaxStamina);

            }
        }
        else
        {
            ErrorSFX();
        }

        

        PlayerPrefs.SetInt("minHitAmount" + mediumAttack, mediumAttack.minHitAmount);
            PlayerPrefs.SetInt("maxHitAmount" + mediumAttack, mediumAttack.maxHitAmount);

            PlayerPrefs.SetInt("money", playerData.money);
            PlayerPrefs.SetInt("XP", playerData.XP);

            updateValues.UpdateValue();
    }
    public void ImproveHeavyAttackHitAmount(int improveFactor) 
    {
        if (playerData.XP >= improvementXPValue * improveFactor && playerData.money >= improvementMoneyValue + improveFactor) 
        {
            heavyAttack.minHitAmount += improveFactor / 5;
            heavyAttack.maxHitAmount += improveFactor / 5;
            playerData.money -= improvementMoneyValue + improveFactor;

            criticalAttack.maxHitAmount += improveFactor / 5; //heavy arttýkca critical da artýyor
            criticalAttack.minHitAmount += improveFactor / 5;

            PurchasedSFX();

            if(heavyAttack.maxHitAmount > 12) //criticalin stamina artisini da buraya eklemeliyim
            {
                heavyAttack.consumeMaxStamina += 1;
                heavyAttack.consumeMinStamina += 1;

                PlayerPrefs.SetInt("minConsumeAmount" + heavyAttack, heavyAttack.consumeMinStamina);
                PlayerPrefs.SetInt("maxConsumeAmount" + heavyAttack, heavyAttack.consumeMaxStamina);

                criticalAttack.consumeMinStamina += 1;
                criticalAttack.consumeMaxStamina += 1;

                PlayerPrefs.SetInt("minConsumeAmount" + criticalAttack, criticalAttack.consumeMinStamina);
                PlayerPrefs.SetInt("maxConsumeAmount" + criticalAttack, criticalAttack.consumeMaxStamina);
            }
        }
        else
        {
            ErrorSFX();
        }

        PlayerPrefs.SetInt("minHitAmount" + heavyAttack, heavyAttack.minHitAmount);
        PlayerPrefs.SetInt("maxHitAmount" + heavyAttack, heavyAttack.maxHitAmount);

        PlayerPrefs.SetInt("money", playerData.money);
        PlayerPrefs.SetInt("XP", playerData.XP);

        

        PlayerPrefs.SetInt("minHitAmount" + criticalAttack, criticalAttack.minHitAmount); //burasýda heavyAttack.minMax idi yanlýs yazdiydim yuksek ihtimalle
        PlayerPrefs.SetInt("maxHitAmount" + criticalAttack, criticalAttack.maxHitAmount);

        updateValues.UpdateValue();
    }


    public void ImproveStamina(int improveFactor)
    {
        if (playerData.XP >= improvementXPValue * improveFactor && playerData.money >= improvementMoneyValue + improveFactor)
        {
            playerData.stamina += (staminaImporve + improveFactor); //10,20,30;  //5
            playerData.money -= (improvementMoneyValue + improveFactor); //5,10,15    //5 

            PlayerPrefs.SetInt("Stamina", playerData.stamina);
            PlayerPrefs.SetInt("money", playerData.money);
            PlayerPrefs.SetInt("XP", playerData.XP);

            updateValues.UpdateValue();
            PurchasedSFX();
        }
        else
        {
            ErrorSFX();
        }
    }
    public void ImproveHealth(int improveFactor) //
    {                           //5                                                                 //10
        if (playerData.XP >= improvementXPValue * improveFactor  && playerData.money >= improvementMoneyValue + improveFactor)
        {
            playerData.health += (healtImprove + improveFactor) ; //10,20,30;  //5
            playerData.money -= (improvementMoneyValue + improveFactor); //5,10,15    //5 

            PlayerPrefs.SetInt("Health", playerData.health);
            PlayerPrefs.SetInt("money", playerData.money);
            PlayerPrefs.SetInt("XP", playerData.XP);

            updateValues.UpdateValue();
            PurchasedSFX();
        }
        else
        {
            ErrorSFX();
        }
    }

    public void UnlockPass()
    {
        if(!pass.open && playerData.XP >= improvementXPValue && playerData.money >= improvementMoneyValue)
        {
            pass.open = true;
            playerData.money -= improvementMoneyValue;

            PlayerPrefs.SetInt("money", playerData.money);
            PlayerPrefs.SetInt("XP", playerData.XP);


            PlayerPrefs.SetInt("openPass", 1);
            updateValues.UpdateValue();
            PurchasedSFX();
        }
        else
        {
            ErrorSFX();
        }
    }

    public void UnlockCriticalHit()
    {
        if (!criticalAttack.open && playerData.XP >= improvementXPValue && playerData.money >= improvementMoneyValue)
        {
            criticalAttack.open = true;
            playerData.money -= improvementMoneyValue;

            PlayerPrefs.SetInt("money", playerData.money);
            PlayerPrefs.SetInt("XP", playerData.XP);
           
            PlayerPrefs.SetInt("openCritical", 1);
            updateValues.UpdateValue();
            PurchasedSFX();


        }
        else
        {
            ErrorSFX();
        }
    }

    public void ImproveAvoid(int improveFactor) //dusunecegim sikinti var, guzel olmadi ama is gorur herhalde
    {
        if(improveFactor ==1)
        {
            if (playerData.XP >= 1 * improveFactor && playerData.money >= 2 * improveFactor && playerData.avoid < 25 * improveFactor)
            {

                playerData.avoid += 1;

                playerData.XP -= 1 * improveFactor;
                playerData.money -= 2 * improveFactor;

                PlayerPrefs.SetInt("money", playerData.money);
                PlayerPrefs.SetInt("XP", playerData.XP);

                PlayerPrefs.SetInt("avoid", playerData.avoid);
                updateValues.UpdateValue();
                PurchasedSFX();

            }
            else
            {
                ErrorSFX();
            }
        }
        else if(improveFactor ==2)
        {
            if (playerData.XP >= 1 * improveFactor && playerData.money >= 2 * improveFactor && playerData.avoid >= 25 && playerData.avoid < 25 * improveFactor)
            {

                playerData.avoid += 1;

                playerData.XP -= 1 * improveFactor;
                playerData.money -= 2 * improveFactor;

                PlayerPrefs.SetInt("money", playerData.money);
                PlayerPrefs.SetInt("XP", playerData.XP);

                PlayerPrefs.SetInt("avoid", playerData.avoid);
                updateValues.UpdateValue();
                PurchasedSFX();

            }
            else
            {
                ErrorSFX();
            }
        }
        
    }

    public void IncreaseHealthPotion()
    {
        if(playerData.money >= improvementMoneyValue && playerData.healthPotion<15) // buna bir sinir getirmek gerekir
        {
            playerData.healthPotion += 1;

            playerData.money -= improvementMoneyValue;
            PlayerPrefs.SetInt("money", playerData.money);
            PlayerPrefs.SetInt("XP", playerData.XP);

            PlayerPrefs.SetInt("healthPotion", playerData.healthPotion);
            updateValues.UpdateValue();
            PurchasedSFX();

        }
        else
        {
            ErrorSFX();
        }
    }


    IEnumerator CallErrorText() //ilerde kullanilir belki dursun simdilik
    {
        errorText.text = "light Attack diger attacklardan daha büyük olamaz";
        yield return new WaitForSeconds(1.5f);
        errorText.text = "";
    }

    public void PurchasedSFX()
    {
        AudioSource.PlayClipAtPoint(coin, new Vector2(0,0),10);
    }

    public void ErrorSFX()
    {
        AudioSource.PlayClipAtPoint(error, new Vector2(0, 0),10);

    }

    void CallKeys()
    {
        if (PlayerPrefs.HasKey("Stamina"))
        {
            playerData.stamina = PlayerPrefs.GetInt("Stamina");
        }
        else
        {
            playerData.stamina = 10;
        }

        if (PlayerPrefs.HasKey("Health"))
        {
            playerData.health = PlayerPrefs.GetInt("Health");
        }
        else
        {
            playerData.health = 10;
        }
        if (PlayerPrefs.HasKey("money"))
        {
            playerData.money = PlayerPrefs.GetInt("money");
        }
        else
        {
            playerData.money = 0;
        }

        if (PlayerPrefs.HasKey("openPass") && PlayerPrefs.GetInt("openPass") == 1)
        {
            pass.open = true;
        }
        else
        {
            pass.open = false;
        }

        if (PlayerPrefs.HasKey("openCritical") && PlayerPrefs.GetInt("openCritical") == 1)
        {
            criticalAttack.open = true;
        }
        else
        {
            criticalAttack.open = false;
        }

        if (PlayerPrefs.HasKey("minHitAmount" + lightAttack) && PlayerPrefs.HasKey("maxHitAmount" + lightAttack))
        {
            lightAttack.minHitAmount = PlayerPrefs.GetInt("minHitAmount" + lightAttack);
            lightAttack.maxHitAmount = PlayerPrefs.GetInt("maxHitAmount" + lightAttack);
        }
        else
        {
            lightAttack.minHitAmount = 1;
            lightAttack.maxHitAmount = 3;
        }
        if (PlayerPrefs.HasKey("minConsumeAmount" + lightAttack) && PlayerPrefs.HasKey("maxConsumeAmount" + lightAttack))
        {
            lightAttack.consumeMinStamina = PlayerPrefs.GetInt("minConsumeAmount" + lightAttack);
            lightAttack.consumeMaxStamina = PlayerPrefs.GetInt("maxConsumeAmount" + lightAttack);
        }
        else
        {
            lightAttack.consumeMinStamina = 2;
            lightAttack.consumeMaxStamina = 2;
        }

        if (PlayerPrefs.HasKey("minHitAmount" + mediumAttack) && PlayerPrefs.HasKey("maxHitAmount" + mediumAttack))
        {
            mediumAttack.minHitAmount = PlayerPrefs.GetInt("minHitAmount" + mediumAttack);
            mediumAttack.maxHitAmount = PlayerPrefs.GetInt("maxHitAmount" + mediumAttack);
        }
        else
        {
            mediumAttack.minHitAmount = 3;
            mediumAttack.maxHitAmount = 5;

        }
        if (PlayerPrefs.HasKey("minConsumeAmount" + mediumAttack) && PlayerPrefs.HasKey("maxConsumeAmount" + mediumAttack))
        {
            mediumAttack.consumeMinStamina = PlayerPrefs.GetInt("minConsumeAmount" + mediumAttack);
            mediumAttack.consumeMaxStamina = PlayerPrefs.GetInt("maxConsumeAmount" + mediumAttack);
        }
        else
        {
            mediumAttack.consumeMinStamina = 3;
            mediumAttack.consumeMaxStamina = 3;
        }

        if (PlayerPrefs.HasKey("minHitAmount" + heavyAttack) && PlayerPrefs.HasKey("maxHitAmount" + heavyAttack))
        {
            heavyAttack.minHitAmount = PlayerPrefs.GetInt("minHitAmount" + heavyAttack);
            heavyAttack.maxHitAmount = PlayerPrefs.GetInt("maxHitAmount" + heavyAttack);


        }
        else
        {
            heavyAttack.minHitAmount = 5;
            heavyAttack.maxHitAmount = 7;

        }

        if (PlayerPrefs.HasKey("minConsumeAmount" + heavyAttack) && PlayerPrefs.HasKey("maxConsumeAmount" + heavyAttack))
        {
            heavyAttack.consumeMinStamina = PlayerPrefs.GetInt("minConsumeAmount" + heavyAttack);
            heavyAttack.consumeMaxStamina = PlayerPrefs.GetInt("maxConsumeAmount" + heavyAttack);
        }
        else
        {
            heavyAttack.consumeMinStamina = 5;
            heavyAttack.consumeMaxStamina = 5;
        }

        if (PlayerPrefs.HasKey("minHitAmount" + criticalAttack) && PlayerPrefs.HasKey("maxHitAmount" + criticalAttack))
        {
            criticalAttack.minHitAmount = PlayerPrefs.GetInt("minHitAmount" + criticalAttack);
            criticalAttack.maxHitAmount = PlayerPrefs.GetInt("maxHitAmount" + criticalAttack);
        }
        else
        {
            criticalAttack.minHitAmount = 15;
            criticalAttack.maxHitAmount = 20;

        }

        if (PlayerPrefs.HasKey("minConsumeAmount" + criticalAttack) && PlayerPrefs.HasKey("maxConsumeAmount" + criticalAttack))
        {
            criticalAttack.consumeMinStamina = PlayerPrefs.GetInt("minConsumeAmount" + criticalAttack);
            criticalAttack.consumeMaxStamina = PlayerPrefs.GetInt("maxConsumeAmount" + criticalAttack);
        }
        else
        {
            criticalAttack.consumeMinStamina = 13;
            criticalAttack.consumeMaxStamina = 13;
        }

        if (PlayerPrefs.HasKey("avoid"))
        {
            playerData.avoid = PlayerPrefs.GetInt("avoid");

        }
        else
        {
            playerData.avoid = 0;
        }

        if (PlayerPrefs.HasKey("healthPotion"))
        {
            playerData.healthPotion = PlayerPrefs.GetInt("healthPotion");
        }
        else
        {
            playerData.healthPotion = 0;
        }

        if(PlayerPrefs.HasKey("hitPossibility" + lightAttack.name))
        {
            lightAttack.hitPosibility = PlayerPrefs.GetInt("hitPossibility" + lightAttack.name);

        }
        else
        {
            lightAttack.hitPosibility = 85;
        }

        if (PlayerPrefs.HasKey("hitPossibility" + mediumAttack.name))
        {
            mediumAttack.hitPosibility = PlayerPrefs.GetInt("hitPossibility" + mediumAttack.name);

        }
        else
        {
            mediumAttack.hitPosibility = 75;
        }

        if (PlayerPrefs.HasKey("hitPossibility" + heavyAttack.name))
        {
            heavyAttack.hitPosibility = PlayerPrefs.GetInt("hitPossibility" + heavyAttack.name);

        }
        else
        {
            heavyAttack.hitPosibility = 65;
        }


    }
}
