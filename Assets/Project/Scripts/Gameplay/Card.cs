using UnityEngine;

public class Card : MonoBehaviour
{
    public CardStack CurrentStack { get; set; }

    public void MoveTo(CardStack targetStack)
    {
        if (targetStack == CurrentStack) return;

        var move = new Move(this, CurrentStack, targetStack);
        ServiceLocator.Get<IUndoManager>().RecordMove(move);

        CurrentStack?.RemoveCard(this);
        targetStack.AddCard(this);
        CurrentStack = targetStack;

        // Award score
        ServiceLocator.Get<IScoreManager>().AddScore(1);
    }
}
