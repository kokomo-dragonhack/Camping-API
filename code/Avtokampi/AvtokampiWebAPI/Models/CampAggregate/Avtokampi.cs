using AvtokampiWebAPI.Models.ReservationAggregate;
using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models.CampAggregate
{
    public partial class Avtokampi
    {
        public Avtokampi()
        {
            Ceniki = new HashSet<Ceniki>();
            KampirnaMesta = new HashSet<KampirnaMesta>();
            Mnenja = new HashSet<Mnenja>();
            Rezervacije = new HashSet<Rezervacije>();
            Slike = new HashSet<Slike>();
            SoritveCenikov = new HashSet<SoritveCenikov>();
        }

        public int AvtokampId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Naslov { get; set; }
        public string Telefon { get; set; }
        public string NazivLokacije { get; set; }
        public string KoordinataX { get; set; }
        public string KoordinataY { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Regija { get; set; }

        public virtual Regije RegijaNavigation { get; set; }
        public virtual ICollection<Ceniki> Ceniki { get; set; }
        public virtual ICollection<KampirnaMesta> KampirnaMesta { get; set; }
        public virtual ICollection<Mnenja> Mnenja { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
        public virtual ICollection<Slike> Slike { get; set; }
        public virtual ICollection<SoritveCenikov> SoritveCenikov { get; set; }
    }
}