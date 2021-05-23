using System.Collections.Generic;

namespace AvtokampiWebAPI.Models.CampAggregate
{
    public partial class Drzave
    {
        public Drzave()
        {
            Regije = new HashSet<Regije>();
        }

        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Regije> Regije { get; set; }
    }
}