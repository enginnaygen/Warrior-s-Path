using UnityEngine;

public class ImprovementsPanel : MonoBehaviour
{

    [SerializeField] GameObject healthImp, staminaImp, weaponImp, otherImp;

    public void OpenCloseHealtImp()
    {
        /*  if (healthImp.activeInHierarchy)
          {
              healthImp.SetActive(false);
          }*/
        if (!healthImp.activeInHierarchy)
        {
            healthImp.SetActive(true);

        }
        if (weaponImp.activeInHierarchy || staminaImp.activeInHierarchy || otherImp.activeInHierarchy)
        {
            staminaImp.SetActive(false);
            weaponImp.SetActive(false);
            otherImp.SetActive(false);

        }
    }

    public void OpenCloseStaminaImp()
    {
        /*if (staminaImp.activeInHierarchy)
         {
             staminaImp.SetActive(false);
         }*/
        if (!staminaImp.activeInHierarchy)
        {
            staminaImp.SetActive(true);

        }
        if (weaponImp.activeInHierarchy || healthImp.activeInHierarchy || otherImp.activeInHierarchy)
        {
            healthImp.SetActive(false);
            weaponImp.SetActive(false);
            otherImp.SetActive(false);

        }
    }

    public void OpenCloseWeaponImp()
    {
        /*if (weaponImp.activeInHierarchy)
        {
            weaponImp.SetActive(false);
        }*/
        if (!weaponImp.activeInHierarchy)
        {
            weaponImp.SetActive(true);

        }
        if (healthImp.activeInHierarchy || staminaImp.activeInHierarchy || otherImp.activeInHierarchy)
        {
            staminaImp.SetActive(false);
            healthImp.SetActive(false);
            otherImp.SetActive(false);
        }
    }

    public void OpenCloseOtherImp()
    {
        /*if (weaponImp.activeInHierarchy)
        {
            weaponImp.SetActive(false);
        }*/
        if (!otherImp.activeInHierarchy)
        {
            otherImp.SetActive(true);

        }
        if (healthImp.activeInHierarchy || staminaImp.activeInHierarchy || weaponImp.activeInHierarchy)
        {
            staminaImp.SetActive(false);
            healthImp.SetActive(false);
            weaponImp.SetActive(false);
        }
    }
}
