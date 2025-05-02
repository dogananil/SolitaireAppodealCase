public class ScoreManager : IScoreManager
{
    private int _score;
    public int CurrentScore => _score;

    public event System.Action<int> OnScoreChanged;

    public void AddScore(int value)
    {
        _score += value;
        OnScoreChanged?.Invoke(_score);
    }

    public void SubtractScore(int value)
    {
        _score -= value;
        OnScoreChanged?.Invoke(_score);
    }
}
