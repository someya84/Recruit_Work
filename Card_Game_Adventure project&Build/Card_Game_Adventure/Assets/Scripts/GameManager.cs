using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform playerHandTransform;
    [SerializeField] Transform EnemyFiledTransform;
    [SerializeField] CardController cardPrefab;
    [SerializeField] EnemyController monsterPrefab;

    public bool isPlayerTurn; //playerのターン検知用の真偽値
    public bool canEnemyAttackCount; //モンスターが攻撃できるかの真偽値
    private int enemyCount; //モンスターの数
    static public int waveCount; //wave数
    public bool checklose = false; //負けたか検知する真偽値
    public bool checkWaveCount = false; //wave数が上限越えしたらBGMを消す真偽値

    [SerializeField] Image winImage;
    [SerializeField] Image loseImage;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject returnButton;
    [SerializeField] Text waveCountText;

    [SerializeField]AudioSource audioSource;
    [SerializeField]List<AudioClip> audioClips = new List<AudioClip>();


    /// <summary>
    /// シングルトン化(どこらからでもアクセスできる)
    /// </summary>
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// バトルのスタート処理
    /// (取得、関数呼び出し)
    /// </summary>
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        StartGame();
        SettingHand();
        SetMonster();
        PlayerController.instance.ShowManaCost();
        TurnCalc();
    }

    private void Update()
    {
        //EnemyFiledTransformの子GameObjectの数をカウントする
        enemyCount = EnemyFiledTransform.childCount;

        ////敵がいなくなったら、勝利処理
        if (enemyCount == 0)
        {
            winImage.enabled = true;
            panel.SetActive(true);
            if (waveCount < 3)
            {
                nextButton.SetActive(true);
            }
            else
            {
                returnButton.SetActive(true);
            }

        }
    
        //checkloseがtrueだったら敗北処理
        if (checklose)
        {
            panel.SetActive(true);
            loseImage.enabled = checklose;
            returnButton.SetActive(true);
        }

        //左上のUIのwaveカウント表示
        waveCountText.text = "wave\n" + waveCount.ToString() + "/3";
    }

    /// <summary>
    /// バトルのスタート処理
    /// (UIの表示・非表示　真偽値　数値の計算　制御構文)
    /// </summary>
    void StartGame()
    {
        waveCount++;
        isPlayerTurn = true;
        canEnemyAttackCount = false;
        winImage.enabled = false;
        loseImage.enabled = false;
        panel.SetActive(false);
        nextButton.SetActive(false);
        returnButton.SetActive(false);

        if (waveCount > 3)
        {
            waveCount = 1;
        }
    }

    /// <summary>
    /// 初回の手札配り
    /// </summary>
    void SettingHand()
    {
        //カードを5枚配る
        for (int i = 0; i < 5; i++)
        {
            int id = Random.Range(1, 4);
            
            GiveCardToHand(id, playerHandTransform);
            
        }

    }

    /// <summary>
    /// カード個別生成
    /// </summary>
    /// <param name="cardID">呼び出したいカードの番号(Assets/Resources/CardEntityList/Card〇)</param>
    /// <param name="hand">アタッチしているGameObjectの位置に生成する</param>
    void GiveCardToHand(int cardID, Transform hand)
    {
        CreateCard(cardID, hand);
    }

    /// <summary>
    /// カード自体の生成
    /// </summary>
    /// <param name="cardID">呼び出したいカードの番号(Assets/Resources/CardEntityList/Card〇)</param>
    /// <param name="hand">アタッチしているGameObjectの位置に生成する</param>
    void CreateCard(int cardID, Transform hand)
    {
        CardController card = Instantiate(cardPrefab, hand, false);
        card.Init(cardID);
    }

    /// <summary>
    /// モンスターの生成
    /// </summary>
    /// <param name="monsterID">呼び出したいモンスターの番号(Assets/Resources/MonsterEntityList/Monster〇)</param>
    /// <param name="hand">アタッチしているGameObjectの位置に生成する</param>
    void CreateMonster(int monsterID, Transform hand)
    {
        EnemyController enemy = Instantiate(monsterPrefab, hand, false);
        enemy.Init(monsterID);
    }

    /// <summary>
    /// モンスターの種類をランダムで選び生成
    /// </summary>
    void SetMonster()
    {
        int randomMonsterID = Random.Range(1, 4);
        CreateMonster(randomMonsterID, EnemyFiledTransform);
    }

    /// <summary>
    /// ターン呼び出し
    /// </summary>
    void TurnCalc()
    {
        if (isPlayerTurn)
        {
            PlayerTurn();
        }
        else
        {

            EnemyTurn();
        }
    }

    /// <summary>
    /// ボタンを押して、ターンが変わった時の処理
    /// </summary>
    public void ChangeTurn()
    {
        //ターン終了したときに持っていたカードを消す処理
        foreach (Transform card in playerHandTransform)
        {
            Destroy(card.gameObject);
        }

        //isPlayerTurnがtrueの時、プレイヤーのターン
        //isPlayerTurnがfalseの時、敵のターン
        isPlayerTurn = !isPlayerTurn;
        if (isPlayerTurn)
        {
            //マナコストの回復
            PlayerController.instance.defaultManaCost++;
            PlayerController.instance.manaCost = 
                PlayerController.instance.defaultManaCost;

            //マナコストが20になったら20に固定
            if (PlayerController.instance.manaCost >= 20)
            {
               PlayerController.instance.manaCost = 20;
            }

            //手札を配る(生成)処理
            for (int i = 0; i < 5; i++)
            {
                int id = Random.Range(1, 4);
                GiveCardToHand(id, playerHandTransform);
            }
        }
        else
        {
            //敵が行動できるかどうか調べる
            canEnemyAttackCount = !canEnemyAttackCount;
        }

        PlayerController.instance.ShowPlayerHp();
        TurnCalc();
        PlayerController.instance.ShowManaCost();
    }

    /// <summary>
    /// プレイヤーのターン処理
    /// </summary>
    void PlayerTurn()
    {
        Debug.Log("Playerのターン");
        //turnCall.text = "Playerのターン";
    }

    /// <summary>
    /// 敵のターン処理
    /// </summary>
    void EnemyTurn()
    {
        Debug.Log("Enemyのターン");
        //turnCall.text = "Enemyのターン";
        ChangeTurn();
    }

    /// <summary>
    /// 自分の攻撃処理
    /// </summary>
    /// <param name="card">CardControllerを呼び出す</param>
    /// <param name="enemy">EnemyControllerを呼び出す</param>
    public void BattleToEnemy(CardController card, EnemyController enemy)
    {
        Debug.Log("Battle");
        Debug.Log("Enemy HP:" + enemy.enemyModel.hp);

        card.cardModel.Attack(card, enemy);

        Debug.Log("Enemy HP:" + enemy.enemyModel.hp);

        //checkAnimationPlayer = true;
        //checkAudioPlayer = true;
        enemy.CheckAlive();
        card.CheckUsedCard();
    }

    /// <summary>
    /// 敵のAttack関数呼び出し用
    /// </summary>
    /// <param name="enemy">EnemyControllerを呼び出す</param>
    public void BattleToPlayer(EnemyController enemy)
    {
        enemy.enemyModel.Attack(enemy);
    }
}
