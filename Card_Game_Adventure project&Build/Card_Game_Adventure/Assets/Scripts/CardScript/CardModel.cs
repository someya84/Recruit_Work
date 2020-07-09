using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カーズデータとその処理
public class CardModel
{
    public string name;
    public int atk;
    public int cost;
    public Sprite icon;
    public bool canAttack;
    public bool usedCard;

    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID);
        name = cardEntity.name;
        atk = cardEntity.atk;
        cost = cardEntity.cost;
        icon = cardEntity.icon;
        usedCard = true;
    }

    /// <summary>
    /// モンスターのダメージ計算
    /// </summary>
    /// <param name="dmg">ダメージ数</param>
    /// <param name="card">CardController</param>
    /// <param name="enemy">EnemyController</param>
    public void Damage(int dmg, CardController card, EnemyController enemy)
    {
        if (card.cardMovement.canDrag)
        {
            enemy.enemyModel.hp -= dmg;

            if (enemy.enemyModel.hp <= 0)
            {
                enemy.enemyModel.hp = 0;
                enemy.enemyModel.isAlive = false;
            }
        }

    }

    /// <summary>
    /// Damage関数の呼び出し
    /// </summary>
    /// <param name="card">CardController</param>
    /// <param name="enemy">EnemyController</param>
    public void Attack(CardController card, EnemyController enemy)
    {
        card.cardModel.Damage(atk ,card ,enemy);
    }
}
