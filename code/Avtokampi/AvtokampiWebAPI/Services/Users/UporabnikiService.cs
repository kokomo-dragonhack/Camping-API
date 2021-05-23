using AvtokampiWebAPI.Models.CampAggregate;
using AvtokampiWebAPI.Models.UserAggregate;
using AvtokampiWebAPI.Repositories.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services.Users
{
    public class UporabnikiService : IUporabnikiService
    {
        private readonly IUporabnikiRepository _uporabnikiRepository;

        public UporabnikiService(IUporabnikiRepository uporabnikiRepository)
        {
            _uporabnikiRepository = uporabnikiRepository;
        }

        public async Task<Uporabniki> GetUporabnikByID(int id)
        {
            return await _uporabnikiRepository.GetUporabnikByID(id);
        }

        public async Task<Uporabniki> GetUporabnikByUsername(string username)
        {
            return await _uporabnikiRepository.GetUporabnikByUsername(username);
        }

        public async Task<Uporabniki> UpdateUporabnik(Uporabniki uporabnik, int uporabnik_id)
        {
            return await _uporabnikiRepository.UpdateUporabnik(uporabnik, uporabnik_id);
        }

        public async Task<bool> RemoveUporabnik(int uporabnik_id)
        {
            return await _uporabnikiRepository.RemoveUporabnik(uporabnik_id);
        }

        public async Task<List<Mnenja>> GetMnenjeByUporabnik(int uporabnik_id)
        {
            return await _uporabnikiRepository.GetMnenjeByUporabnik(uporabnik_id);
        }

        public async Task<List<Mnenja>> GetMnenjeByAvtokamp(int kamp_id)
        {
            return await _uporabnikiRepository.GetMnenjeByAvtokamp(kamp_id);
        }

        public async Task<Mnenja> GetMnenje(int mnenje_id)
        {
            return await _uporabnikiRepository.GetMnenje(mnenje_id);
        }

        public async Task<bool> CreateMnenje(Mnenja mnenje, int kamp_id)
        {
            return await _uporabnikiRepository.CreateMnenje(mnenje, kamp_id);
        }

        public async Task<Mnenja> UpdateMnenje(Mnenja mnenje, int mnenje_id)
        {
            return await _uporabnikiRepository.UpdateMnenje(mnenje, mnenje_id);
        }

        public async Task<bool> RemoveMnenje(int mnenje_id)
        {
            return await _uporabnikiRepository.RemoveMnenje(mnenje_id);
        }

        public async Task<bool> UporabnikExists(string username = null, int? up_id = null)
        {
            return await _uporabnikiRepository.UporabnikExists(username, up_id);
        }
    }
}