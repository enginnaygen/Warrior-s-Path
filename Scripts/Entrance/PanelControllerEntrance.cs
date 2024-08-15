using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControllerEntrance : MonoBehaviour
{
    [SerializeField] GameObject creditPanel, characterPanel;
    public void GoToMainMenu()
    {
        MySceneManager.instance.BackToMainMenu();
        //Time.timeScale = 1;
    }

    public void OpenCharacterPanel()
    {
        if (characterPanel.activeInHierarchy)
        {
            characterPanel.SetActive(false);
        }
        else if (!characterPanel.activeInHierarchy)
        {
            characterPanel.SetActive(true);

        }
        if (creditPanel.activeInHierarchy)
        {
            creditPanel.SetActive(false);
        }
    }

        public void OpenCreditPanel()
        {
            if (creditPanel.activeInHierarchy)
            {
            creditPanel.SetActive(false);
            }
            else if (!creditPanel.activeInHierarchy)
            {
            creditPanel.SetActive(true);

            }
            if (characterPanel.activeInHierarchy)
            {
                characterPanel.SetActive(false);
            }
        }

    public void ExitGame()
    {
        Application.Quit();
    }

}
