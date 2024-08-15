using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyData/Default EnemyData")]

public class EnemyData : ScriptableObject //enemyde tutulan degeri sakliyor
{
    public int howManyWin;
    public bool human, animal, robot;
}
