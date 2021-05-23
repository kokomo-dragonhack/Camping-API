using AvtokampiWebAPI.Models.CampAggregate;
using AvtokampiWebAPI.Models.ReservationAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services.Reservations
{
    public interface IRezervacijeService
    {
        Task<List<Rezervacije>> GetRezervacijeByUporabnik(int uporabnik_id);

        Task<Rezervacije> GetRezervacijaByID(int rez_id);

        Task<bool> CreateRezervacija(Rezervacije rez);

        Task<Rezervacije> UpdateRezervacija(Rezervacije rez, int rez_id);

        Task<bool> RemoveRezervacija(int rez_id);

        Task<List<VrstaKampiranja>> GetVrstaKmapiranja();

        Task<List<StatusRezervacije>> GetStatusRezervacije();
    }
}