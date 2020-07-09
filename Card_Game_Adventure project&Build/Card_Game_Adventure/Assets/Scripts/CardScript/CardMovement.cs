using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform defaultParent;
    public bool canDrag;
    public int siblingIndex;

    /// <summary>
    /// ドラッグした瞬間の処理
    /// </summary>
    /// <param name="eventData">ポインタ（マウス/タッチ）イベントに関連するイベントの情報データ</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        CardController card = GetComponent<CardController>();
        if (card.cardModel.cost <= PlayerController.instance.manaCost)
        {
            canDrag = true;
        }
        else
        {
            canDrag = false;
        }

        if (!canDrag)
        {
            return;
        }

        siblingIndex = transform.GetSiblingIndex();
        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    /// <summary>
    /// ドラッグ中のオブジェクトの移動位置
    /// </summary>
    /// <param name="eventData">ポインタ（マウス/タッチ）イベントに関連するイベントの情報データ</param>
    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag)
        {
            return;
        }

        transform.position = eventData.position;
    }

    /// <summary>
    /// ドラッグ終わりの処理
    /// </summary>
    /// <param name="eventData">ポインタ（マウス/タッチ）イベントに関連するイベントの情報データ</param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!canDrag)
        {
            return;
        }
        transform.SetParent(defaultParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetSiblingIndex(siblingIndex);
    }

}
