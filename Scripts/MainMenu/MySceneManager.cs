using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Sceneler arasi yok olmuyor ve combatta olusacak dusmanin yaratildigi yer, ileride Player da yaratilarak olusturulursa
//Bu islem de belki buradan yapilacak
public class MySceneManager : MonoBehaviour
{
    public static MySceneManager instance;

    [SerializeField] GameObject[] enemies;
    //[SerializeField] int enemyIndis;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

   

    public void GoToCombatWithThisEnemy(int indis)
    {
        //SceneManager.LoadSceneAsync("Combat");
        StartCoroutine(CreateEnemy(indis));
    }

    IEnumerator CreateEnemy(int indis) //bu indis hangi dusmanin secilecegi
    {
        yield return SceneManager.LoadSceneAsync("Combat"); //LoadSceneMode.Additive
        //yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        yield return new WaitForSeconds(0.01f);
        Instantiate(enemies[indis]);

    }

    public void BackToMainMenu()
    {
        //DontDestroyOnLoad(instance.gameObject);
        StartCoroutine(WaitAndTurnBackToMainMenu());
    }

    IEnumerator WaitAndTurnBackToMainMenu()
    {
        yield return SceneManager.LoadSceneAsync("MainMenu");

    }



}
