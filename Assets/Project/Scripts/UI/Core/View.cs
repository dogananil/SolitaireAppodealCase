using UnityEngine;

public abstract class View : MonoBehaviour
{
    /// <summary>
    /// Called before the view appears.
    /// </summary>
    public virtual void OnOpen() { }

    /// <summary>
    /// Called to close and destroy the view.
    /// </summary>
    public virtual void OnClose()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Receives view data, sets it up, and triggers OnOpen.
    /// </summary>
    public abstract void Show(IUIData data);
}
