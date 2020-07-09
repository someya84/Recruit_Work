using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterEntity", menuName = "Create EnemyEntity")]

public class EnemyEntity : ScriptableObject
{
    public int hp;
    public int atk;
    public int canAttackCount;
    public Sprite monster_Image;
    public int defaultCanAttackCount;
}
