namespace Keepass.Wpf.Common
{
    public class FormAbstractFactory<T> : IFormAbstractFactory<T>
    {
        private readonly Func<T> _factory;

        public FormAbstractFactory(Func<T> factory)
        {
            _factory = factory;
        }

        public T Create()
        {
            return _factory();
        }
    }
}
