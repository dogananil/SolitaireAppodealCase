using Cysharp.Threading.Tasks;

public interface IUIManager
{
    UniTask Show(IUIData data);
}
