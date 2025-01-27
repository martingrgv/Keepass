namespace Keepass.Application.Contracts
{
    public interface ICryptography
    {
        string Encrypt(string plainText);
        string Decrypt(string cypher);
    }
}
