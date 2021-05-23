namespace AvtokampiWebAPI.Models.CampAggregate
{
    public partial class StoritveKampirnihMest
    {
        public int StoritveKampirnihMestId { get; set; }
        public int KampirnoMesto { get; set; }
        public int Storitev { get; set; }
        public bool? Isactive { get; set; }

        public virtual KampirnaMesta KampirnoMestoNavigation { get; set; }
        public virtual Storitve StoritevNavigation { get; set; }
    }
}