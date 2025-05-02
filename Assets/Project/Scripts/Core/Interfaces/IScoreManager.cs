public interface IScoreManager
{
    int CurrentScore { get; }
    void AddScore(int value);
    void SubtractScore(int value);
    event System.Action<int> OnScoreChanged;
}
