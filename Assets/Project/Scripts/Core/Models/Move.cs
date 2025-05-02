public class Move : IMove
{
    private readonly Card _card;
    private readonly CardStack _from;
    private readonly CardStack _to;

    public Move(Card card, CardStack from, CardStack to)
    {
        _card = card;
        _from = from;
        _to = to;
    }

    public void Undo()
    {
        _to.RemoveCard(_card);
        _from.AddCard(_card);
        _card.CurrentStack = _from;
    }
}
