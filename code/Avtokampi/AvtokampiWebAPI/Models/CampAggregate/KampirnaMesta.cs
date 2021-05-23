using AvtokampiWebAPI.Models.ReservationAggregate;
using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models.CampAggregate
{
    public partial class KampirnaMesta
    {
        public KampirnaMesta()
        {
            Rezervacije = new HashSet<Rezervacije>();
            StoritveKampirnihMest = new HashSet<StoritveKampirnihMest>();
        }

        public int KampirnoMestoId { get; set; }
        public string Naziv { get; set; }
        public string Velikost { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Avtokamp { get; set; }
        public int Kategorija { get; set; }

        public virtual Avtokampi AvtokampNavigation { get; set; }
        public virtual Kategorije KategorijaNavigation { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
        public virtual ICollection<StoritveKampirnihMest> StoritveKampirnihMest { get; set; }
    }
}