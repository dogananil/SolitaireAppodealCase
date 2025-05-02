using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

public class UIManager : MonoBehaviour, IUIManager
{
    private Canvas uiCanvas;

    public void Init(Canvas canvas)
    {
        uiCanvas = canvas;
    }

    public async UniTask Show(IUIData data)
    {
        GameObject prefab = await Addressables.LoadAssetAsync<GameObject>(data.ViewKey);
        GameObject instance = Instantiate(prefab, uiCanvas.transform);

        if (instance.TryGetComponent(out View view))
        {
            view.Show(data);
        }
        else
        {
            Debug.LogError($"UI prefab does not implement View: {data.ViewKey}");
        }
    }
}
