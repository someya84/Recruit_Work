using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{
    [SerializeField] Text monsterHpText; //プレイヤーのHPText
    [SerializeField] Text canAttackCountText;

    public int monsterHp; //プレイヤーのHPの数値
    public int atk;
    public int canAttackCount;
    public int defaultcanAttackCount;

    private Animator monsterAnimator;
    private AudioSource monsterAudioSource;
    public AudioClip monsterAudioClip;
    public bool checkAudioMonster; //オーディオの切り替え真偽値
    [SerializeField] List<GameObject> monsterObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckAudio()
    {
        monsterAudioSource.PlayOneShot(monsterAudioClip);
    }

    /// <summary>
    /// playerのダメージに関する処理
    /// </summary>
    /// <param name="dmg">ダメージ量</param>
    /// <param name="attackCount">モンスターの攻撃してくるターン</param>
    /// <param name="defaultAttackCount">attackCountのデフォルト値</param>
    /// <param name="enemy">EnemyController</param>
    public void Damage(int dmg, int attackCount, int defaultAttackCount, EnemyController enemy)
    {
        if (attackCount == 0)
        {
            CheckAudio();
            canAttackCount = defaultcanAttackCount;
        }
        if (attackCount == 1)
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
