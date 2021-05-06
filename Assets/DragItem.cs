using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    public GameObject UI;
    public GameObject Room;
    public List<GameObject> list;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            var index = transform.GetSiblingIndex();
            if (index == 1)
                transform.SetSiblingIndex(2);
            else
                transform.SetSiblingIndex(1);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        list = eventData.hovered;
        foreach (var gameObject in eventData.hovered)
        {
            if (gameObject.CompareTag("board"))
            {
                transform.SetParent(UI.transform);
                return;
            }
        }
        transform.SetParent(Room.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            rectTransform.anchoredPosition += eventData.delta;
        }
    }
}
