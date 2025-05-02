public interface IUIView<in T> where T : IUIData
{
    void Setup(T data);
}
