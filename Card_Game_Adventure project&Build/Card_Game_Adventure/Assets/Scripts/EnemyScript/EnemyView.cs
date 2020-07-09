using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    [SerializeField] Text hpText;
    [SerializeField] Text canAttackCountText;
    [SerializeField] Image monsterImage;

    /// <summary>
    /// モンスター情報の表示
    /// </summary>
    /// <param name="cardModel">CardModel</param>
    public void Show(EnemyModel enemyModel)
    {
        hpText.text = enemyModel.hp.ToString();
        canAttackCountText.text = enemyModel.canAttackCount.ToString();
        monsterImage.sprite = enemyModel.icon;
    }

    /// <summary>
    /// モンスター情報の表示更新用
    /// </summary>
    /// <param name="enemyModel">EnemyModel</param>
    public void Refresh(EnemyModel enemyModel)
    {
        hpText.text = enemyModel.hp.ToString();
        canAttackCountText.text = enemyModel.canAttackCount.ToString();
    }

}
