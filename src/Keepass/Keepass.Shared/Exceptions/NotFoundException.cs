namespace Keepass.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string element) :  base($"{element} not found!")
        {
        }
    }
}
