using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSelect : MonoBehaviour
{
    [SerializeField] Image[] actives;

    private void Start()
    {
        if(PlayerPrefs.HasKey("choosenImage"))
        {
            actives[PlayerPrefs.GetInt("choosenImage")].gameObject.SetActive(true);
        }
        else
        {
            actives[0].gameObject.SetActive(false);
        }

    }
    public void ActiveChoosen(int indis)
    {
        for (int i = 0; i < actives.Length; i++)
        {
            actives[i].gameObject.SetActive(false);
        }

        actives[indis].gameObject.SetActive(true);

        PlayerPrefs.SetInt("choosenImage", indis);
    }
}
