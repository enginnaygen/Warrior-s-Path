
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChoose : MonoBehaviour
{

    [SerializeField] Sprite[] characterCards;
    [SerializeField] DataContainer playerData;

    private void Start()
    {
        if(PlayerPrefs.HasKey("character"))
        {
            playerData.playerImage = characterCards[PlayerPrefs.GetInt("character")];
        }
        else
        {
            playerData.playerImage = characterCards[0];

        }
    }
    public void ChooseCharacter(int indis)
    {
        playerData.playerImage = characterCards[indis];

        PlayerPrefs.SetInt("character", indis);
    }
}
