using System;

namespace AvtokampiWebAPI.Models.CampAggregate
{
    public partial class Slike
    {
        public int SlikaId { get; set; }
        public byte[] Slika { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? Updated { get; set; }
        public int Avtokamp { get; set; }
        public bool? Isactive { get; set; }

        public virtual Avtokampi AvtokampNavigation { get; set; }
    }
}