using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button undoButton;

    private void Start()
    {
        undoButton.onClick.AddListener(OnUndoClicked);
    }

    private async void OnUndoClicked()
    {
        await UniTask.SwitchToMainThread(); // Prep for async/await
        Bootstrap.UndoManager.UndoLastMove();
    }
}
