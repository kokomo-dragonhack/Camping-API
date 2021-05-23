using AvtokampiWebAPI.Models.CampAggregate;
using AvtokampiWebAPI.Models.ReservationAggregate;
using AvtokampiWebAPI.Repositories.Reservations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services.Reservations
{
    public class RezervacijeService : IRezervacijeService
    {
        private readonly IRezervacijeRepository _rezervacijeRepository;

        public RezervacijeService(IRezervacijeRepository rezervacijeRepository)
        {
            _rezervacijeRepository = rezervacijeRepository;
        }

        public async Task<List<Rezervacije>> GetRezervacijeByUporabnik(int uporabnik_id)
        {
            return await _rezervacijeRepository.GetRezervacijeByUporabnik(uporabnik_id);
        }

        public async Task<Rezervacije> GetRezervacijaByID(int rez_id)
        {
            return await _rezervacijeRepository.GetRezervacijaByID(rez_id);
        }

        public async Task<bool> CreateRezervacija(Rezervacije rez)
        {
            return await _rezervacijeRepository.CreateRezervacija(rez);
        }

        public async Task<Rezervacije> UpdateRezervacija(Rezervacije rez, int rez_id)
        {
            return await _rezervacijeRepository.UpdateRezervacija(rez, rez_id);
        }

        public async Task<bool> RemoveRezervacija(int rez_id)
        {
            return await _rezervacijeRepository.RemoveRezervacija(rez_id);
        }

        public async Task<List<VrstaKampiranja>> GetVrstaKmapiranja()
        {
            return await _rezervacijeRepository.GetVrstaKmapiranja();
        }

        public async Task<List<StatusRezervacije>> GetStatusRezervacije()
        {
            return await _rezervacijeRepository.GetStatusRezervacije();
        }
    }
}