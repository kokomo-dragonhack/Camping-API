using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AvtokampiWebAPI.Models.AuthAggregate
{
    public class RegisterDto
    {
        [Required] [JsonProperty("ime")] public string Ime { get; set; }

        [Required] [JsonProperty("priimek")] public string Priimek { get; set; }

        [JsonProperty("telefon")] public string Telefon { get; set; }

        [Required] [JsonProperty("email")] public string Email { get; set; }

        [Required] [JsonProperty("geslo")] public string Geslo { get; set; }

        [JsonProperty("pravice")] public int Pravice { get; set; }
    }
}