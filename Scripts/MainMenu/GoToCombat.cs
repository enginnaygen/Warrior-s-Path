using UnityEngine;

public class GoToCombat : MonoBehaviour //burasi artik kullanilmiyor panelControllerdaki GoToCombat methodu bu isi goruyor
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] int enemyIndis;

 
    public void GoToCombatWithThisEnemy(int indis)
    {
        //SceneManager.LoadSceneAsync("Combat");
        //StartCoroutine(CreateEnemy(indis));
    }

    /*IEnumerator CreateEnemy(int indis)
    {
        yield return SceneManager.LoadSceneAsync("Combat", LoadSceneMode.Additive);
        yield return new WaitForSeconds(2f);
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        yield return new WaitForSeconds(2f);
        Instantiate(enemies[indis]);

    }*/
}
