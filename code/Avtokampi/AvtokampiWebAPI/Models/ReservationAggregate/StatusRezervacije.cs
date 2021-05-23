using System.Collections.Generic;

namespace AvtokampiWebAPI.Models.ReservationAggregate
{
    public partial class StatusRezervacije
    {
        public StatusRezervacije()
        {
            Rezervacije = new HashSet<Rezervacije>();
        }

        public int StatusRezervacijeId { get; set; }
        public string Naziv { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}