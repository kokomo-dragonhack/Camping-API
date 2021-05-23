using AvtokampiWebAPI.Models.UserAggregate;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models.AuthAggregate
{
    public partial class Pravice
    {
        public Pravice()
        {
            Uporabniki = new HashSet<Uporabniki>();
        }

        public int PravicaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Uporabniki> Uporabniki { get; set; }
    }
}