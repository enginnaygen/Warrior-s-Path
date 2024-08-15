using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] Image backgroundImage;
    [SerializeField] Sprite humanBackground, animalBackground, robotBackground;

    Enemy enemy;
    void Start()
    {
        StartCoroutine(ControlBackground());
    }

  
    IEnumerator ControlBackground()
    {
        yield return new WaitForSeconds(0.02f); //bu kadar kisa olmasi sikinti yaratir mi acaba?
        enemy = FindObjectOfType<Enemy>();


        if (enemy.enemyData.human)
        {
            backgroundImage.sprite = humanBackground;
        }

        else if (enemy.enemyData.animal)
        {
            backgroundImage.sprite = animalBackground;

        }
        else if (enemy.enemyData.robot)
        {
            backgroundImage.sprite =  robotBackground;


        }
    }
}
