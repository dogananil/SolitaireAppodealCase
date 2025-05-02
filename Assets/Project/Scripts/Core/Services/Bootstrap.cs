using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public static IUndoManager UndoManager { get; private set; }

    private void Awake()
    {
        UndoManager = new UndoManager();
    }
}
