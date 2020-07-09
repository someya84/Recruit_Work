using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Check_Target_Cursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image target_Cursor;

    CardController card;

    public void OnPointerEnter(PointerEventData eventData)
    {
        target_Cursor.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        target_Cursor.gameObject.SetActive(false);
    }
}
