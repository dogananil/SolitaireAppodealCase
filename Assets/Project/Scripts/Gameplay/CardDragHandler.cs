// Scripts/Gameplay/CardDragHandler.cs
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Card))]
[RequireComponent(typeof(CanvasGroup))]
public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector3 startPosition;
    private Transform originalParent;
    private Card card;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        card = GetComponent<Card>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.position;
        originalParent = transform.parent;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(transform.root); // ensure it's above other UI
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        CardStack targetStack = GetCardStackUnderMouse();
        if (targetStack != null && targetStack != card.CurrentStack)
        {
            card.MoveTo(targetStack);
        }
        else
        {
            rectTransform.position = startPosition;
            transform.SetParent(originalParent);
        }
    }

    private CardStack GetCardStackUnderMouse()
    {
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        }, results);

        foreach (var result in results)
        {
            if (result.gameObject.TryGetComponent(out CardStack stack))
                return stack;
        }

        return null;
    }
}
