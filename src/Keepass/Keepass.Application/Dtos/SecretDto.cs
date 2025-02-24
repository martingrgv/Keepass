namespace Keepass.Application.Dtos
{
    public record SecretDto(string Username, string Password, string? Url, string? Note);
}
