using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    // -------------------------------------
    //見た目に関する操作(cardView)
    //データに関する操作(cardModel)
    //移動に関する操作(cardMovement)
    // ---------------------------------------
    public CardView cardView;
    public CardModel cardModel;
    public CardMovement cardMovement;
    public bool checkEnemyFiled;

    private void Awake()
    {
        cardView = GetComponent<CardView>();
        cardMovement = GetComponent<CardMovement>();
        checkEnemyFiled = false;
    }

    public void Update()
    {
        //使えるカードの周りにオーラを表示する処理
        if (cardModel.cost > PlayerController.instance.manaCost)
        {
            cardView.SetActiveSelectablePanel(false);
        }

    }

    /// <summary>
    /// カード個別判定処理
    /// </summary>
    /// <param name="cardID">カードの個別判定をするための数値</param>
    public void Init(int cardID)
    {
        cardModel = new CardModel(cardID);

        cardView.Show(cardModel);
    }

    /// <summary>
    /// カードを使用した後消す処理
    /// </summary>
    public void CheckUsedCard()
    {
        Debug.Log(cardMovement);
        if (cardModel.usedCard && cardMovement.canDrag)
        {
            PlayerController.instance.PlayerAnimation();
            PlayerController.instance.checkAudioPlayer = true;
            Destroy(this.gameObject);
        }
    }
}
