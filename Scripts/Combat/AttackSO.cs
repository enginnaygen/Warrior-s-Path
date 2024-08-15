using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public enum AttackType { Punch, Kick, Head, Pass } // bu tipler hic kullanilmadi silinse de olur
[CreateAssetMenu(menuName = "AttackSO/Default Attack")]
public class AttackSO : ScriptableObject
{
    public int minHitAmount, maxHitAmount;
    public int hitPosibility;
    public int consumeMinStamina, consumeMaxStamina;
    public int increaseStamina;
    public string attackAnimation;
    public bool open;



}
