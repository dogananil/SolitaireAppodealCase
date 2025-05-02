using Cysharp.Threading.Tasks;

public interface IGameInitializer
{
    UniTask InitializeAsync();
}
