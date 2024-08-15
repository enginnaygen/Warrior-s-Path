using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour //Combat kartlarinin ve gelistirme panelinin acilip kapanmasi ve Combat Scenene gitme
{
    [SerializeField] GameObject enemiesPanel, improvementsPanel, healthImp, staminaImp, weaponImp, otherImp;
    //[SerializeField] DataAboutWinLose enemyData;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void OpenCloseEnemiesPanel()
    {
        if(enemiesPanel.activeInHierarchy)
        {
            enemiesPanel.SetActive(false);
        }
        else if(!enemiesPanel.activeInHierarchy)
        {
            enemiesPanel.SetActive(true);

        }
        if(improvementsPanel.activeInHierarchy)
        {
            improvementsPanel.SetActive(false);
        }
    }

    public void OpenCloseImpromentsPanel()
    {
        if (improvementsPanel.activeInHierarchy)
        {
            improvementsPanel.SetActive(false);
        }
        else if (!improvementsPanel.activeInHierarchy)
        {
            improvementsPanel.SetActive(true);

        }
        if (enemiesPanel.activeInHierarchy)
        {
            enemiesPanel.SetActive(false);
        }
    }

   
    public void GoToCombat(int indis) //int indis yaziyordu ve teker teker buttondan veriyordum
    {
        Time.timeScale = 1; // olmasina gerek yok gibi startta yaptim zaten ama dursun simdilik
        MySceneManager.instance.GoToCombatWithThisEnemy(indis);
    }

    public void BackToEntrance()
    {
        SceneManager.LoadSceneAsync("Entrance");
    }


    int GiveAfterButtonReference() // dursun simdilik belki fikir verir
    {
        int childIndex = transform.GetSiblingIndex(); //siblingi degil kendi indexini veriyor neden anlamadim
        return childIndex;

    }


}
