using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text atkText;
    [SerializeField] Text costText;
    [SerializeField] Image iconImage;
    [SerializeField] GameObject selectablePanel;

    /// <summary>
    /// カード情報の表示
    /// </summary>
    /// <param name="cardModel">CardModel</param>
    public void Show(CardModel cardModel)
    {
        nameText.text = cardModel.name;
        atkText.text = "ATK+" + cardModel.atk.ToString();
        costText.text = cardModel.cost.ToString();
        iconImage.sprite = cardModel.icon;
    }

    /// <summary>
    /// オーラの表示・非表示
    /// </summary>
    /// <param name="flag">オーラの表示・非表示</param>
    public void SetActiveSelectablePanel(bool flag)
    {
        selectablePanel.SetActive(flag);
    }
}
