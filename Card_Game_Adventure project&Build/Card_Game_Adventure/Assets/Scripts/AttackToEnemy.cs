using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackToEnemy : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardController card = eventData.pointerDrag.GetComponent<CardController>();
        EnemyController enemy = GetComponent<EnemyController>();

        PlayerController.instance.ReduceManaCost(card.cardModel.cost, card);
        GameManager.instance.BattleToEnemy(card, enemy);

    }
}
