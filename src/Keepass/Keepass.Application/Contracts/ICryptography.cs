namespace Keepass.Application.Contracts
{
    public interface ICryptography
    {
        byte[] Key { get; }
        void SetKey(string key);
        string Encrypt(string plainText);
        string Decrypt(string cypher);
    }
}
