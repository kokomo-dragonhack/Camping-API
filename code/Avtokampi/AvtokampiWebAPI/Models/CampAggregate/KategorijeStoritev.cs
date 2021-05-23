using System.Collections.Generic;

namespace AvtokampiWebAPI.Models.CampAggregate
{
    public partial class KategorijeStoritev
    {
        public KategorijeStoritev()
        {
            Storitve = new HashSet<Storitve>();
        }

        public int KategorijaStoritveId { get; set; }
        public string Naziv { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Storitve> Storitve { get; set; }
    }
}