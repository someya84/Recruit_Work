using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackToPlayer : MonoBehaviour
{
    public EnemyController enemy;

    AudioSource audioSource;

    List<AudioClip> audioClips = new List<AudioClip>();

    public AudioClip audioClip;

    public void Awake()
    {
        enemy = GetComponent<EnemyController>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (GameManager.instance.canEnemyAttackCount)
        {
            Debug.Log(enemy.enemyModel.canAttackCount);
            GameManager.instance.BattleToPlayer(enemy);
            enemy.enemyView.Refresh(enemy.enemyModel);
            GameManager.instance.canEnemyAttackCount = !GameManager.instance.canEnemyAttackCount;
        }
    }
}
