using UnityEngine;

public class Card : MonoBehaviour
{
    public CardStack CurrentStack { get; set; }

    public void MoveTo(CardStack targetStack)
    {
        if (targetStack == CurrentStack) return;

        IMove move = new Move(this, CurrentStack, targetStack);
        Bootstrap.UndoManager.RecordMove(move);

        CurrentStack?.RemoveCard(this);
        targetStack.AddCard(this);
        CurrentStack = targetStack;
    }
}
