using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitCombat : MonoBehaviour
{
    public void QuitFight()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
