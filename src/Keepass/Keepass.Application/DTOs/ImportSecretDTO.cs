using Newtonsoft.Json;

namespace Keepass.Application.DTOs
{
    public class ImportSecretDTO
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; } = default!;

        [JsonProperty("Password")]
        public string Password { get; set; } = default!;

        [JsonProperty("URL")]
        public string? URL { get; set; }

        [JsonProperty("Note")]
        public string? Note { get; set; }
    }
}
