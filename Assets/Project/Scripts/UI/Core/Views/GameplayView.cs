using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayView : View, IUIView<GameplayViewData>
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button undoButton;

    public void Setup(GameplayViewData data)
    {
        scoreText.text = $"Score: {data.Score}";

        undoButton.onClick.RemoveAllListeners();
        undoButton.onClick.AddListener(() =>
        {
            ServiceLocator.Get<IUndoManager>().UndoLastMove();
        });
    }

    public override void Show(IUIData data)
    {
        if (data is GameplayViewData gameplayData)
        {
            Setup(gameplayData);
            ServiceLocator.Get<IScoreManager>().OnScoreChanged += OnScoreChanged;
            OnOpen();
        }
        else
        {
            Debug.LogError($"[GameplayView] Invalid data type: {data.GetType()}");
        }
    }

    private void OnScoreChanged(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public override void OnClose()
    {
        ServiceLocator.Get<IScoreManager>().OnScoreChanged -= OnScoreChanged;
        base.OnClose();
    }
}
