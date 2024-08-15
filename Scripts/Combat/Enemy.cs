using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour //nerdeyse hic kullanilmadi ama FindObjectType kullanarak erisilmesi kolaylastiriyor
{
    //[SerializeField] int minEnemyHit, maxEnemyHit;
    //[SerializeField] Animation enemyHitAnimation;
    //[SerializeField] Attack enemyAttack;
    // Start is called before the first frame update
    Health myHealth;
    public EnemyData enemyData;


    private void Awake()
    {
        myHealth = GetComponent<Health>();

    }

    public EnemyData ReturnEnemyData()
    {
        return enemyData;
    }
    void Start()
    {
        /*FindObjectOfType<ShowHealths>().ShowHealth();
        FindObjectOfType<ShowStamina>().ShowStaminas();*/

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /*public void Attack(int attackAmount)
    {
        Health playerHealth = FindObjectOfType<Player>().GetComponent<Health>();

        enemyHitAnimation.Play();
        //enemyAttack.AttackMethod(playerHealth);
        //playerHealth.DecreaseHealth(minEnemyHit,maxEnemyHit);


    }*/
}
