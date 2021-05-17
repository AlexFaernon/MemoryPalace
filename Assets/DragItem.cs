using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    public GameObject UI;
    public GameObject Room;
    private bool isOnLowerLayer = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            var siblingsCount = transform.parent.childCount;
            if (isOnLowerLayer)
                transform.SetSiblingIndex(siblingsCount - 1);
            else
                transform.SetSiblingIndex(1);
            isOnLowerLayer = !isOnLowerLayer;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //TODO пофиксить пропаданаие с доски
        foreach (var gameObject in eventData.hovered)
        {
            if (gameObject.CompareTag("board"))
            {
                transform.SetParent(UI.transform);
                transform.SetSiblingIndex(1);
                return;
            }
        }
        transform.SetParent(Room.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
}
