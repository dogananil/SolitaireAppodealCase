using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

public class GameInitializer : IGameInitializer
{
    private readonly Transform _canvasTransform;
    private readonly List<CardStack> _stacks = new();

    public GameInitializer(Transform canvasTransform)
    {
        _canvasTransform = canvasTransform;
    }

    public async UniTask InitializeAsync()
    {
        CreateCardStacks();
        await SpawnInitialCards();
    }

    private void CreateCardStacks()
    {
        float spacing = 250f;
        Vector2 basePosition = new Vector2(-spacing, 0);

        for (int i = 0; i < 3; i++)
        {
            GameObject stackGO = new GameObject($"CardStack_{i}");
            RectTransform rt = stackGO.AddComponent<RectTransform>();
            rt.SetParent(_canvasTransform, false);
            rt.sizeDelta = new Vector2(100, 140);
            rt.anchoredPosition = basePosition + new Vector2(spacing * i, 0);

            var img = stackGO.AddComponent<UnityEngine.UI.Image>();
            img.color = new Color(1f, 1f, 1f, 0.1f);

            var stack = stackGO.AddComponent<CardStack>();
            _stacks.Add(stack);
        }
    }

    private async UniTask SpawnInitialCards()
    {
        foreach (var stack in _stacks)
        {
            GameObject cardGO = await Addressables.InstantiateAsync("Card", stack.transform);
            var card = cardGO.GetComponent<Card>();
            card.CurrentStack = stack;
            stack.AddCard(card);
        }
    }
}
