using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Attack : MonoBehaviour
{
    //[SerializeField] Attacks[] AttackType;
    [SerializeField]protected int canHitPossibility;
    [SerializeField]protected Animator animator, oppenentAnimator, playerAvoidImageAnimator, enemyAvoidImageAnimator, enemyStaminaAnimator, playerStaminaAnimtor;
    [SerializeField]protected int minHitAmount, maxHitAmount;
    protected Health oppenentHealth, myHealth;
    protected Stamina myStamina;
    [SerializeField] bool enemy;
    //protected PanelControllerCombat panelControllerCombat;

    protected TextMeshProUGUI cannotHitText; //avoid kelimesi aklima gelmeisti o yuzden cannot hit kaldi
    [SerializeField] protected AudioClip hitSFX, avoidSFX;


    private void Awake()
    {
        //panelControllerCombat = FindObjectOfType<PanelControllerCombat>().GetComponent<PanelControllerCombat>();
    }
    public virtual void AttackMethod()  //bura kullanilmiyor bu sekilde
    {
        int possibility = Random.Range(0, 100);
        if (canHitPossibility > possibility)
        {
            //hitAnimation.Play();
            animator.SetTrigger("Hit");
            oppenentHealth.DecreaseHealth(minHitAmount, maxHitAmount);
        }
    }

    protected IEnumerator CannotHit() //burasi duzenlenmeli gibi, karmakarisik oldu
    {
        //cannotHitText.text = "AVOID";
        //runAnimation.Play();
        if(enemy)
        {
            enemyAvoidImageAnimator = FindObjectOfType<PlayerNotGetDamage>().GetComponentInChildren<Animator>(); // buralar karisti ama naladim gibi
            Animator oppenentAnimator;
            oppenentAnimator = FindObjectOfType<Player>().GetComponent<Animator>();
            animator.SetBool("Hit", true);
            yield return new WaitForSeconds(0.15f);
            oppenentAnimator.SetBool("RunFromHit",true);
            enemyAvoidImageAnimator.SetBool("Run", true);
            yield return new WaitForSeconds(0.5f);
            oppenentAnimator.SetBool("RunFromHit", false);
            animator.SetBool("Hit", false);
            enemyAvoidImageAnimator.SetBool("Run", false);

        }
        else if(!enemy)
        {
            playerAvoidImageAnimator = FindObjectOfType<EnemyNotGetDamage>().GetComponentInChildren<Animator>();//buralar karisti ama anladim gibi
            Animator oppenentAnimator;
            oppenentAnimator = FindObjectOfType<Enemy>().GetComponent<Animator>();
            animator.SetBool("Hit", true);
            yield return new WaitForSeconds(0.15f);
            playerAvoidImageAnimator.SetBool("Run", true);
            oppenentAnimator.SetBool("RunFromHit", true);
            yield return new WaitForSeconds(0.5f);
            oppenentAnimator.SetBool("RunFromHit", false);
            animator.SetBool("Hit", false);
            playerAvoidImageAnimator.SetBool("Run", false);


        }
        yield return new WaitForSeconds(0.3f);

        //cannotHitText.text = "";


    }

    protected virtual IEnumerator StaminaTextPlayer()  // bir tane yazilip arguman verilerek de yapýlabilir gibi player ve enemy için ayri ayri yazilmasina gerek yok gibi
    {
        playerStaminaAnimtor = FindObjectOfType<PlayerNotEnoughStamina>().GetComponentInChildren<Animator>();
        yield return new WaitForSeconds(0.4f);
        playerStaminaAnimtor.SetBool("Stamina", true);
        myStamina.infoStaminaPlayer.text = "Not Enough Stamina";
        yield return new WaitForSeconds(1f);
        myStamina.infoStaminaPlayer.text = "";
        playerStaminaAnimtor.SetBool("Stamina", false);


    }
    protected IEnumerator StaminaImageEnemy()  // bir tane yazilip arguman verilerek de yapýlabilir gibi 
    {
        Image image = FindObjectOfType<EnemyNotEnoughStamina>().GetComponentInChildren<Image>();
        enemyStaminaAnimator = FindObjectOfType<EnemyNotEnoughStamina>().GetComponentInChildren<Animator>();
        yield return new WaitForSeconds(1f);
        image.color = Color.yellow; //green de olabilir
        enemyStaminaAnimator.SetBool("Stamina", true);
        //myStamina.infoStaminaEnemy.text = "Not Enough Stamina";
        yield return new WaitForSeconds(1.5f);
        //myStamina.infoStaminaEnemy.text = "";
        enemyStaminaAnimator.SetBool("Stamina", false);

    }
}
