using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] AttackSO[] AttackType; //attack tipleriini player sakliyor suan, buradaki sira ile scenedeki sira onemli
    //[SerializeField] AttackType AttackTypee;
    //[SerializeField] Button puch, kick, head;
    //[SerializeField] int takeHitPossibility;
    //[SerializeField] Animation playerHitAnimation;

    //[SerializeField] Attack playerAttack;
    [SerializeField] GameObject buttonPanel;

    PlayerAttack playerAttack;
    [SerializeField] DataContainer playerData;
    //Stamina myStamina;
    //Health myHealth;
    Sprite playerSprite;

    private void Awake()
    {
        //myHealth = GetComponent<Health>();
        //myStamina = GetComponent<Stamina>();
        playerAttack = GetComponent<PlayerAttack>();

    }
    void Start()
    {
        
        GetComponent<SpriteRenderer>().sprite  = playerData.playerImage;
        //Debug.Log(AttackType.Length);
        for (int i = 0; i < AttackType.Length ; i++)
        {
            if(AttackType[i].open == true)
            {
                Transform button = buttonPanel.transform.GetChild(i);
                button.GetComponent<Button>().interactable = true;

                //Debug.Log(buttonPanel.transform.GetChild(i));

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CallAttack(int indis)
    {
        playerAttack.AttackMethod(AttackType[indis]);
    }
  

    /*public void Attack(AttackSO attackType)
    {
        Health enemyHealth = FindObjectOfType<Enemy>().GetComponent<Health>();

        //playerAttack.AttackMethod(enemyHealth);
        int possibilty = Random.Range(0, 100);
        Debug.Log(possibilty);
        if (attackType.hitPosibility > possibilty)
        {
            Health enemyHealth = FindObjectOfType<Enemy>().GetComponent<Health>();
            enemyHealth.DecreaseHealth(attackType.minHitAmount, attackType.maxHitAmount);
            playerHitAnimation.Play();

        }

        //burasi enemyinin playera vurmasi
        int possibility2 = Random.Range(0, 100);
        if(takeHitPossibility > possibility2)
        {
            StartCoroutine(EnemyAttack());
        }
        else
        {
            StartCoroutine(Wait());

        }

    }

    IEnumerator EnemyAttack()
    {
        DisableButtons();
        yield return new WaitForSeconds(2f);
        Enemy enemy = FindObjectOfType<Enemy>().GetComponent<Enemy>();
        //enemy.Attack(10); // argüman olmasýna gerek yok ama olsun belki ilerde fikir açar böyle kalsýn
        yield return new WaitForSeconds(0.5f);
        EnableButtons();


    }
    IEnumerator Wait()
    {
        DisableButtons();
        yield return new WaitForSeconds(1f);
        EnableButtons();
        
    }

    public void EnableButtons()
    {
        puch.interactable = true;
        kick.interactable = true;
        head.interactable = true;

    }

    public void DisableButtons()
    {
        puch.interactable = false;
        kick.interactable = false;
        head.interactable = false;
    }*/

    public void Deneme() //bu sekilde 4 indisini bire vericez ve yükseltmeleri yapmýþ olacagiz, bunu kontrol eden bir manager olur
    {
        AttackType[0] = AttackType[3];
    }

}
