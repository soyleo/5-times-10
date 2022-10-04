using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]

public class BaseEnemy : ScriptableObject {
    
    public new string name;
    public int Enemy_Life;
    public string EnemyType;
    public int Enemy_Element;
    
    [Header ("Attacks Melee?")]
    public bool Attack_Melee;
    public int Enemy_Melee_ASpeed;
    public int EnemyDamage_Melee;
    [Header ("Attacks Ranged?")]
    public bool Attack_Ranged;
    public int Enemy_Ranged_ASpeed;
    public int EnemyDamage_Ranged;

}
