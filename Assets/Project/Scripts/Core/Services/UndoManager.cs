using System.Collections.Generic;

public class UndoManager : IUndoManager
{
    private readonly Stack<IMove> _moveStack = new();

    public void RecordMove(IMove move)
    {
        _moveStack.Push(move);
    }

    public void UndoLastMove()
    {
        if (_moveStack.Count > 0)
        {
            var move = _moveStack.Pop();
            move.Undo();

            // Subtract score
            ServiceLocator.Get<IScoreManager>().SubtractScore(1);
        }
    }

}
