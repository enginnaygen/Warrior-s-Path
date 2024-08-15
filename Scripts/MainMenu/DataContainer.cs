using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "DataContainer/Default Container")]
public class DataContainer : ScriptableObject //oyunun, playerin verilerini sakliyor
{
    public Sprite playerImage;
    public int XP;
    public int money;
    public int health;
    public int stamina;
    public int avoid;
    public int healthPotion;
}
