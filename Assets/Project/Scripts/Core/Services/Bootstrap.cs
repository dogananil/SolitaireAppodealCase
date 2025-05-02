using UnityEngine;
using Cysharp.Threading.Tasks;

public class Bootstrap : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private Canvas gameCanvas;

    private async void Awake()
    {
        RegisterServices();
        await InitializeGameAsync();
    }

    private void RegisterServices()
    {
        var undoManager = new UndoManager();
        ServiceLocator.Register<IUndoManager>(undoManager);

        GameObject uiManagerGO = new GameObject("UIManager");
        var uiManager = uiManagerGO.AddComponent<UIManager>();
        uiManager.Init(gameCanvas);
        ServiceLocator.Register<IUIManager>(uiManager);

        var gameInitializer = new GameInitializer(gameCanvas.transform);
        ServiceLocator.Register<IGameInitializer>(gameInitializer);

        var scoreManager = new ScoreManager();
        ServiceLocator.Register<IScoreManager>(scoreManager);

    }

    private async UniTask InitializeGameAsync()
    {
        await ServiceLocator.Get<IGameInitializer>().InitializeAsync();

        var gameplayData = new GameplayViewData(score: 0);
        await ServiceLocator.Get<IUIManager>().Show(gameplayData);
    }
}
