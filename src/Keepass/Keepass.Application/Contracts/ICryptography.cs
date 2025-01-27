namespace Keepass.Application.Contracts
{
    public interface ICryptography
    {
        void SetKey(string key);
        string Encrypt(string plainText);
        string Decrypt(string cypher);
    }
}
