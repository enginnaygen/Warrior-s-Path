using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPanel : MonoBehaviour
{

    [SerializeField] GameObject humanPanel, animalPanel, robotPanel;


    public void OpenCloseHumanPanel()
    {
     
        if (!humanPanel.activeInHierarchy)
        {
            humanPanel.SetActive(true);

        }
        if (animalPanel.activeInHierarchy || robotPanel.activeInHierarchy)
        {
            animalPanel.SetActive(false);
            robotPanel.SetActive(false);

        }
    }

    public void OpenCloseAnimalPanel()
    {

        if (!animalPanel.activeInHierarchy)
        {
            animalPanel.SetActive(true);

        }
        if (humanPanel.activeInHierarchy || robotPanel.activeInHierarchy)
        {
            humanPanel.SetActive(false);
            robotPanel.SetActive(false);

        }
    }

    public void OpenCloseRobotPanel()
    {

        if (!robotPanel.activeInHierarchy)
        {
            robotPanel.SetActive(true);

        }
        if (animalPanel.activeInHierarchy || humanPanel.activeInHierarchy)
        {
            animalPanel.SetActive(false);
            humanPanel.SetActive(false);

        }
    }
}
