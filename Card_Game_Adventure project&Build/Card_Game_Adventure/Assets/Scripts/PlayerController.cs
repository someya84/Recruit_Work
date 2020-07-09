using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Text playerHpText; //プレイヤーのHPText
    [SerializeField] Text manaCostText; //マナコストText
    public int playerHp; //プレイヤーのHPの数値
    public int manaCost; //コストの数値
    public int defaultManaCost; //manaCostのデフォルト値
    private Animator playerAnimator;
    private AudioSource playerAudioSource;
    public AudioClip playerAudioClip;
    public bool checkAudioPlayer; //オーディオの切り替え真偽値

    /// <summary>
    /// シングルトン化
    /// </summary>
    public static PlayerController instance;
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
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        StartGame();
        ShowManaCost();
    }

    // Update is called once per frame
    void Update()
    {
        //checkAudioPlayerがtrueだったら攻撃音を再生
        if (checkAudioPlayer)
        {
            playerAudioSource.PlayOneShot(playerAudioClip);
            checkAudioPlayer = !checkAudioPlayer;
        }

        //if (checkAnimationPlayer)
        //{
        //    playerAnimator.SetBool("boolCheckAttack", checkAnimationPlayer);
        //    StartCoroutine("playerAnimationTime");
        //}
    }

    /// <summary>
    /// バトルのスタート処理
    /// (UIの表示・非表示　真偽値　数値の計算　制御構文)
    /// </summary>
    void StartGame()
    {
        playerHp = 20;
        manaCost = 1;
        defaultManaCost = 1;
    }

    /// <summary>
    /// プレイヤーHPの表示処理
    /// </summary>
    public void ShowPlayerHp()
    {
        playerHpText.text = playerHp.ToString();
    }

    /// <summary>
    /// マナコスト数の表示処理
    /// </summary>
    public void ShowManaCost()
    {
        manaCostText.text = manaCost.ToString();
    }

    /// <summary>
    /// マナコストの消費処理
    /// </summary>
    public void ReduceManaCost(int cost, CardController card)
    {
        if (card.cardMovement.canDrag)
        {
            manaCost -= cost;
            PlayerController.instance.ShowManaCost();
        }
    }

    /// <summary>
    /// プレイヤーのアニメーション処理
    /// </summary>
    public void PlayerAnimation()
    {
        playerAnimator.SetBool("boolCheckAttack", true);
        StartCoroutine("playerAnimationTime");
    }

    IEnumerator playerAnimationTime()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("boolCheckAttack", false);
    }
}
