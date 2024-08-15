using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : Attack
{
    //[SerializeField] AttackSO[] attackType;
    //[SerializeField] int increaseStaminaAmount = 20;
    EnemyAttack enemyAttack;
    [SerializeField] Slider playerStaminaSlider;

    [SerializeField] AttackSO pass;

    int hitCount; // rakibe kac defa vurduguma gore para da ona gore artacak endPanelButtonda ayarli
    
 
    private void Awake()
    {
        myHealth = GetComponent<Health>();
        //oppenentHealth = FindObjectOfType<Enemy>().GetComponent<Health>(); 1) çünkü ilk yaratildiginda dusman yok
        myStamina = GetComponent<Stamina>();
        cannotHitText = FindObjectOfType<EnemyNotGetDamage>().GetComponent<TextMeshProUGUI>();
    }
    public void AttackMethod(AttackSO attackType) //AttackSO attackType
    {
        oppenentHealth = FindObjectOfType<Enemy>().GetComponent<Health>(); // 2) oyuzden burada referansý verdim
        enemyAttack = FindObjectOfType<Enemy>().GetComponent<EnemyAttack>();
        enemyAttack.AttackMethod();

        if(myStamina.GetStaminaAmount() < attackType.consumeMaxStamina) //yazicam!!!!!!!!!!!!! //passta buraya girmsi icin yuksek girmem lazim AttackSOsunu 
        {
            StartCoroutine(StaminaImagePlayer(attackType));
            myStamina.IncreaseStamina(attackType.increaseStamina);

            if(playerStaminaSlider.maxValue < myStamina.GetStaminaAmount()) //bence guzel cozum olduu staminayi gecememsi icin
            {
                myStamina.EqualMaxStamina((int)playerStaminaSlider.maxValue);
            }
            FindObjectOfType<ShowStamina>().ShowStaminas();
            return;
        }
        int possibility = Random.Range(0, 100);
        //Debug.Log("sayi" + (attackType.hitPosibility - enemyAttack.avoid));
        //Debug.Log ("posibility"+ possibility);

        if (attackType.hitPosibility - enemyAttack.avoid > possibility) //enemy avoidi de etkili olsun
        {
            hitCount++;
            AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position);
            StartCoroutine(ArrangeAnimation(attackType.attackAnimation));
            //animator.SetBool("Hit", true);
            //hitAnimation.Play();
            oppenentHealth.DecreaseHealth(attackType.minHitAmount,attackType.maxHitAmount);
            myStamina.DecreaseStamina(attackType.consumeMinStamina, attackType.consumeMaxStamina);
        }
        else
        {
            AudioSource.PlayClipAtPoint(avoidSFX, Camera.main.transform.position);
            StartCoroutine(ArrangeAnimation(attackType.attackAnimation));
            myStamina.DecreaseStamina(attackType.consumeMinStamina, attackType.consumeMaxStamina);
            StartCoroutine(CannotHit());
        }

        FindObjectOfType<ShowHealths>().ShowHealth();
        FindObjectOfType<ShowStamina>().ShowStaminas();
        FindObjectOfType<PanelControllerCombat>().PanelController(myHealth, oppenentHealth);
        //panelControllerCombat.PanelController(myHealth,oppenentHealth);

    }

    IEnumerator ArrangeAnimation(string attackAnimation)
    {
        animator.SetBool(attackAnimation, true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool(attackAnimation, false);
    }

    public int CallHitCount()
    {
        return hitCount;
    }

    IEnumerator StaminaImagePlayer(AttackSO attackType)
    {

        playerStaminaAnimtor = FindObjectOfType<PlayerNotEnoughStamina>().GetComponentInChildren<Animator>();

        if (attackType == pass)
        {
            Image image = FindObjectOfType<PlayerNotEnoughStamina>().GetComponentInChildren<Image>();
            image.color = Color.yellow; //green de olabilir
            yield return new WaitForSeconds(0.2f);
            playerStaminaAnimtor.SetBool("Stamina", true);
            yield return new WaitForSeconds(0.8f);
            //myStamina.infoStaminaEnemy.text = "";
            playerStaminaAnimtor.SetBool("Stamina", false);
            image.color = Color.red;

        }
        else
        {
            yield return new WaitForSeconds(0.3f);
            playerStaminaAnimtor.SetBool("Stamina", true);
            //myStamina.infoStaminaPlayer.text = "Not Enough Stamina";
            yield return new WaitForSeconds(0.8f);
            //myStamina.infoStaminaPlayer.text = "";
            playerStaminaAnimtor.SetBool("Stamina", false);
        }

        
    }

}


