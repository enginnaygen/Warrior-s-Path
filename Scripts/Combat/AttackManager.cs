using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour //kullanmadigim bir script (deneme yapildi)
{
    //[SerializeField] Attacks AttackTypePlayer, AttackTypeEnemy;
    [SerializeField] GameObject buttonPanel;
    //[SerializeField] int takeHitPossibility;
    //[SerializeField] bool enemy;
    Attack playerAttack, enemyAttack;
    Health playerHealth, enemyHealth;


    private void Awake()
    {
        playerAttack = FindObjectOfType<Player>().GetComponent<Attack>();
        playerHealth = FindObjectOfType<Player>().GetComponent<Health>();

        enemyAttack = FindObjectOfType<Enemy>().GetComponent<Attack>();
        enemyHealth = FindObjectOfType<Enemy>().GetComponent<Health>();

    }
    
    public void AttackControl()
    {
        StartCoroutine(AttackController());
    }

    public IEnumerator AttackController() // bu islem Wait scriptinde yapiliyor
    {
        buttonPanel.SetActive(false);

        //playerAttack.AttackMethod(enemyHealth); //AttackType[].minHitAmount, AttackType[].maxHitAmount

        yield return new WaitForSeconds(1f);

        //enemyAttack.AttackMethod(playerHealth); //AttackType[].minHitAmount, AttackType[].maxHitAmount

        buttonPanel.SetActive(true);


        /*int possibility = Random.Range(0, 100);
        if (takeHitPossibility > possibility)
        {
            if (!enemy)
            {
                buttonPanel.SetActive(false);
                //hitAnimation.Play();
                //oppenentHealth.DecreaseHealth(minHitAmount, maxHitAmount);
            }
            else if (enemy)
            {
                buttonPanel.SetActive(false);
                yield return new WaitForSeconds(2f);
                //hitAnimation.Play();
                //oppenentHealth.DecreaseHealth(minHitAmount, maxHitAmount);
                buttonPanel.SetActive(true);
            }
        }
        yield return new WaitForSeconds(2f);
        buttonPanel.SetActive(true);



    }*/

    }
}
