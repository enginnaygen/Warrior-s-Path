using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PanelControllerCombat : MonoBehaviour // attacklarda Method cagirilarak olup olmedigi anlasiliyor
{
    [SerializeField] GameObject lostPanel, winPanel, restartGamePanel;
    [SerializeField] AudioClip winSFX, loseSFX;
    [SerializeField] AudioSource backgroundCombatSound;
    [SerializeField] GameObject attackButtons, healthPotion;
    [SerializeField] WaitAttackButtons wait;
    [SerializeField] EnemyData robotLastCard;
    

    


    public void PanelController(Health playerHealth, Health enemyHealth)
    {

        StartCoroutine(WaitRestartPanel(enemyHealth));

        if (enemyHealth.GetHealth() <= 0 && enemyHealth != null)
        {
            StopCoroutine(wait.WaitController()); //bu sekilde buttonlar kaybolup gidiyomus gibi olmayacak

            StartCoroutine(WaitWinPanel());
            StartCoroutine(WaitAnimation());
            //Time.timeScale = 0;
        }

        else if (playerHealth.GetHealth() <= 0 && playerHealth != null)
        {
            StopCoroutine(wait.WaitController());//bu sekilde buttonlar kaybolup gidiyomus gibi olmayacak

            StartCoroutine(WaitLostPanel());
            StartCoroutine(WaitAnimation()); //bekleterek yapmazsasm vurmadan can azaliyor ve oyun duruyor direkt vurmadan bitmis gibi oluyor
           //Time.timeScale = 0;
        }

        
        
        
    }

  

    IEnumerator WaitWinPanel()
    {
        yield return new WaitForSeconds(0.4f);
        winPanel.SetActive(true);
        backgroundCombatSound.volume = 0;
        AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position, 10f);
    }

    IEnumerator WaitLostPanel()
    {
        yield return new WaitForSeconds(0.2f);
        lostPanel.SetActive(true);
        backgroundCombatSound.volume = 0;
        AudioSource.PlayClipAtPoint(loseSFX, Camera.main.transform.position, 0.5f);
    }
    IEnumerator WaitAnimation()
    {
        //StopAllCoroutines();
        yield return new WaitForSeconds(0.5f);
        attackButtons.SetActive(false);//sonra cunku oyunun icinde kendi kendine acilip kapaniyor buton paneli ona yakalanmasin diye
        healthPotion.SetActive(false);
        Time.timeScale = 0;
    }

  
    void RestartPanel(Health enemyHealth)
    {       
        if (enemyHealth.GetHealth() <= 0 && robotLastCard == enemyHealth.GetComponent<Enemy>().enemyData)
        {
            restartGamePanel.SetActive(true);

            return;
        }


    }

    IEnumerator WaitRestartPanel(Health enemyHealth)
    {
        yield return new WaitForSeconds(0.5f);
        RestartPanel(enemyHealth);

    }
    public void GoToMainMenu()
    {
        MySceneManager.instance.BackToMainMenu();
        //Time.timeScale = 1;
    }
}
