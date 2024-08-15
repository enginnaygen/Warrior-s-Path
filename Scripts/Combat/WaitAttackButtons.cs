using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAttackButtons : MonoBehaviour //attack buttonPanelinin belli sure kapatilip acilmasini sagliyor
{
    [SerializeField] GameObject attackButtonPanel;
    [SerializeField] float waitCount = 1.5f;

    public void WaitCall()
    {
        StartCoroutine(WaitController());
    }
    public IEnumerator WaitController()
    {
        attackButtonPanel.SetActive(false);


        yield return new WaitForSeconds(waitCount);


        attackButtonPanel.SetActive(true);



    }
}
