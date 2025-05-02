public interface IUndoManager
{
    void RecordMove(IMove move);
    void UndoLastMove();
}
