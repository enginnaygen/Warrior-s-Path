using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyAttack : Attack
{
    [SerializeField] int consumeMinStaminaValue = 10, consumeMaxStaminaValue =20;
    [SerializeField] int increaseStaminaAmount = 20;
    [SerializeField] DataContainer playerData;
    [SerializeField] AudioClip enemyRestSFX;

    [SerializeField] internal int avoid;

    string[] animationNames = {"Hit", "Hit2", "Hit3", "Hit4"  }; // daha da arttilabilir
    

    private void Awake()
    {  
        myHealth = GetComponent<Health>();
        oppenentHealth = FindObjectOfType<Player>().GetComponent<Health>();
        myStamina = GetComponent<Stamina>();
        cannotHitText = FindObjectOfType<PlayerNotGetDamage>().GetComponent<TextMeshProUGUI>();

    }
    public override void AttackMethod()
    {
        //int randomConsumeStamina = Random.Range(consumeMinStaminaValue, consumeMaxStaminaValue);
        if (myStamina.GetStaminaAmount() < consumeMaxStaminaValue) //gereken maxStaminaya sahip olmasi lazim mantigi var
        {
            StartCoroutine(StaminaImageEnemy());
            StartCoroutine(IncreaseStaminaWait());
            return;
        }
        StartCoroutine(Wait());
    }


    IEnumerator Wait() //playerin hareketini bekliyor
    {
        yield return new WaitForSeconds(1f);
        int possibility = Random.Range(0, 100);
        if (canHitPossibility - playerData.avoid > possibility) //buradaki 100u eksiltiyor ve playerin damage yemesi gelistiriliyor bi nevi
        {
            AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position);
            //hitAnimation.Play();
            int randomAnim = Random.Range(0, animationNames.Length);
            animator.SetBool(animationNames[randomAnim], true);
            oppenentHealth.DecreaseHealth(minHitAmount, maxHitAmount);
            myStamina.DecreaseStamina(consumeMinStaminaValue, consumeMaxStaminaValue);
            yield return new WaitForSeconds(0.5f);
            animator.SetBool(animationNames[randomAnim], false);
        }
        else
        {
            AudioSource.PlayClipAtPoint(avoidSFX, Camera.main.transform.position);
            myStamina.DecreaseStamina(consumeMinStaminaValue, consumeMaxStaminaValue);
            StartCoroutine(CannotHit());
        }
        FindObjectOfType<ShowStamina>().ShowStaminas();
        FindObjectOfType<ShowHealths>().ShowHealth();
        FindObjectOfType<PanelControllerCombat>().PanelController(oppenentHealth, myHealth);

        //panelControllerCombat.PanelController(oppenentHealth,myHealth);


    }
    
    IEnumerator IncreaseStaminaWait() //playeri bekliyor
    {
        yield return new WaitForSeconds(1f);
        AudioSource.PlayClipAtPoint(enemyRestSFX, Camera.main.transform.position,10f); //playerindkini boyle yapmadik buttona bagladik
        myStamina.IncreaseStamina(increaseStaminaAmount);
        FindObjectOfType<ShowStamina>().ShowStaminas();


    }
}
