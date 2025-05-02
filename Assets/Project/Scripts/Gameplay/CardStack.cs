using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    private readonly List<Card> _cards = new();

    public void AddCard(Card card)
    {
        _cards.Add(card);
        card.transform.SetParent(transform);
        card.transform.localPosition = Vector3.down * _cards.Count * 0.3f;
    }

    public void RemoveCard(Card card)
    {
        _cards.Remove(card);
    }
}
