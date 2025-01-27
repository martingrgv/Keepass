namespace Keepass.Wpf.Contracts
{
    public interface IFormAbstractFactory<T>
    {
        T Create();
    }
}
