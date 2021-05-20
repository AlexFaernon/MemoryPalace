using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    public GameObject Board;
    public GameObject Room;
    private bool isOnLowerLayer;
    private bool isHoverOnBoard;
    private bool isOnBoard;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Update()
    {
        //TODO пофиксить пропаданаие с доски
        if (isHoverOnBoard && !isOnBoard)
        {
            transform.SetParent(Board.transform);
            transform.SetSiblingIndex(1);
            isOnBoard = true;
            return;
        }
        
        if (isHoverOnBoard) return;
        isOnBoard = false;
        transform.SetParent(Room.transform);
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

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("on");
        if (other.gameObject.CompareTag("board"))
        {
            isHoverOnBoard = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("off");
        if (other.gameObject.CompareTag("board"))
        {
            isHoverOnBoard = false;
        }
    }
}
