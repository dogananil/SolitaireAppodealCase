public class GameplayViewData : IUIData
{
    public int Score { get; }

    public GameplayViewData(int score)
    {
        Score = score;
    }

    public string ViewKey => "GameplayView"; // Addressable key
}
