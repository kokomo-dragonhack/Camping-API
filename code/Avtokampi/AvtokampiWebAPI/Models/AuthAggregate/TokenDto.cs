using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AvtokampiWebAPI.Models.AuthAggregate
{
    public class TokenDto
    {
        [Required] [JsonProperty("username")] public string Username { get; set; }

        [Required] [JsonProperty("password")] public string Password { get; set; }
    }
}