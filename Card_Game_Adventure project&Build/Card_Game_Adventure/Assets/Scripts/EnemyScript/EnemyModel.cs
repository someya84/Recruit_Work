using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//モンスターデータとその処理
public class EnemyModel
{
    public int hp;
    public int atk;
    public int canAttackCount;
    public Sprite icon;
    public int defaultcanAttackCount;

    public bool isAlive;

    public bool checkDamageSE;

    public EnemyModel(int monsterID)
    {
        EnemyEntity enemyEntity = Resources.Load<EnemyEntity>("MonsterEntityList/Monster" + monsterID);
        hp = enemyEntity.hp;
        atk = enemyEntity.atk;
        canAttackCount = enemyEntity.canAttackCount;
        icon = enemyEntity.monster_Image;
        defaultcanAttackCount = enemyEntity.defaultCanAttackCount;
        isAlive = true;
    }

    /// <summary>
    /// playerのダメージに関する処理
    /// </summary>
    /// <param name="dmg">ダメージ量</param>
    /// <param name="attackCount">モンスターの攻撃してくるターン</param>
    /// <param name="defaultAttackCount">attackCountのデフォルト値</param>
    /// <param name="enemy">EnemyController</param>
    //public void Damage(int dmg, int attackCount, int defaultAttackCount, EnemyController enemy)
    //{
    //    if (attackCount == 0)
    //    {
    //        enemy.CheckAudio();
    //        canAttackCount = defaultcanAttackCount;
    //    }
    //    if (attackCount == 1)
    //    {
    //        PlayerController.instance.playerHp -= dmg;
    //    }

    //    if (PlayerController.instance.playerHp <= 0)
    //    {
    //        GameManager.instance.checklose = true;
    //        PlayerController.instance.playerHp = 0;
    //        PlayerController.instance.ShowPlayerHp();
    //    }
    //}

    public void Damage(int dmg, EnemyController enemy)
    {
        if (canAttackCount == 0)
        {
            enemy.CheckAudio();
            canAttackCount = defaultcanAttackCount;
        }
        if (canAttackCount == 1)
        {
            PlayerController.instance.playerHp -= dmg;
        }

        if (PlayerController.instance.playerHp <= 0)
        {
            GameManager.instance.checklose = true;
            PlayerController.instance.playerHp = 0;
            PlayerController.instance.ShowPlayerHp();
        }
    }

    /// <summary>
    /// モンスターの攻撃処理
    /// </summary>
    /// <param name="enemy">EnemyController</param>
    public void Attack(EnemyController enemy)
    {
        enemy.enemyModel.canAttackCount -= 1;
        enemy.enemyModel.Damage(atk,enemy);
    }
}
