using AvtokampiWebAPI.Models.CampAggregate;
using AvtokampiWebAPI.Models.UserAggregate;
using System;

namespace AvtokampiWebAPI.Models.ReservationAggregate
{
    public partial class Rezervacije
    {
        public int RezervacijaId { get; set; }
        public DateTime? TrajanjeOd { get; set; }
        public DateTime? TrajanjeDo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Uporabnik { get; set; }
        public int Avtokamp { get; set; }
        public int KampirnoMesto { get; set; }
        public int VrstaKampiranja { get; set; }
        public int StatusRezervacije { get; set; }
        public bool? Isactive { get; set; }

        public virtual Avtokampi AvtokampNavigation { get; set; }
        public virtual KampirnaMesta KampirnoMestoNavigation { get; set; }
        public virtual StatusRezervacije StatusRezervacijeNavigation { get; set; }
        public virtual Uporabniki UporabnikNavigation { get; set; }
        public virtual VrstaKampiranja VrstaKampiranjaNavigation { get; set; }
    }
}