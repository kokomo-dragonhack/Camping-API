using AvtokampiWebAPI.Models.CampAggregate;
using AvtokampiWebAPI.Models.Shared;
using AvtokampiWebAPI.Repositories.Camps;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services.Camps
{
    public class AvtokampiService : IAvtokampiService
    {
        private readonly IAvtokampiRepository _avtokampiRepository;
        private readonly IKampirnaMestaRepository _kampirnaMestaRepository;
        private readonly IStoritveKampaRepository _storitveKampaRepository;

        public AvtokampiService(
            IAvtokampiRepository avtokampiRepository,
            IKampirnaMestaRepository kampirnaMestaRepository,
            IStoritveKampaRepository storitveKampaRepository)
        {
            _avtokampiRepository = avtokampiRepository;
            _kampirnaMestaRepository = kampirnaMestaRepository;
            _storitveKampaRepository = storitveKampaRepository;
        }

        public async Task<PagedList<Avtokampi>> GetPage(AvtokampiParameters avtokampiParameters)
        {
            return await _avtokampiRepository.GetPage(avtokampiParameters);
        }

        public async Task<List<Avtokampi>> GetAll()
        {
            return await _avtokampiRepository.GetAll();
        }

        public async Task<Avtokampi> GetAvtokampByID(int kamp_id)
        {
            return await _avtokampiRepository.GetAvtokampByID(kamp_id);
        }

        public async Task<bool> CreateAvtokamp(Avtokampi avtokamp)
        {
            return await _avtokampiRepository.CreateAvtokamp(avtokamp);
        }

        public async Task<Avtokampi> UpdateAvtokamp(Avtokampi avtokamp, int avtokamp_id)
        {
            return await _avtokampiRepository.UpdateAvtokamp(avtokamp, avtokamp_id);
        }

        public async Task<bool> RemoveAvtokamp(int avtokamp_id)
        {
            return await _avtokampiRepository.RemoveAvtokamp(avtokamp_id);
        }

        public async Task<Slike> GetSlikaAvtokampa(int kamp_id)
        {
            return await _avtokampiRepository.GetSlikaAvtokampa(kamp_id);
        }

        public async Task<List<Slike>> GetSlikeAvtokampa(int kamp_id)
        {
            return await _avtokampiRepository.GetSlikeAvtokampa(kamp_id);
        }

        public async Task<bool> CreateSlikaAvtokampa(Slike slika, int kamp_id)
        {
            return await _avtokampiRepository.CreateSlikaAvtokampa(slika, kamp_id);
        }

        public async Task<bool> CreateSlikeAvtokampa(List<Slike> slike, int kamp_id)
        {
            return await _avtokampiRepository.CreateSlikeAvtokampa(slike, kamp_id);
        }

        public async Task<Slike> UpdateSlikaAvtokampa(Slike slika, int slika_id)
        {
            return await _avtokampiRepository.UpdateSlikaAvtokampa(slika, slika_id);
        }

        public async Task<List<Slike>> UpdateSlikeAvtokampa(List<Slike> slike, List<int> slika_id)
        {
            return await _avtokampiRepository.UpdateSlikeAvtokampa(slike, slika_id);
        }

        public async Task<bool> RemoveSlikaAvtokampa(int slika_id)
        {
            return await _avtokampiRepository.RemoveSlikaAvtokampa(slika_id);
        }

        public async Task<List<Ceniki>> GetCenikiAvtokampa(int kamp_id)
        {
            return await _avtokampiRepository.GetCenikiAvtokampa(kamp_id);
        }

        public async Task<Ceniki> GetCenikAvtokampa(int cenik_id)
        {
            return await _avtokampiRepository.GetCenikAvtokampa(cenik_id);
        }

        public async Task<bool> CreateCenikAvtokampa(Ceniki cenik, int kamp_id)
        {
            return await _avtokampiRepository.CreateCenikAvtokampa(cenik, kamp_id);
        }

        public async Task<Ceniki> UpdateCenik(Ceniki cenik, int cenik_id)
        {
            return await _avtokampiRepository.UpdateCenik(cenik, cenik_id);
        }

        public async Task<bool> RemoveCenikAvtokampa(int cenik_id)
        {
            return await _avtokampiRepository.RemoveCenikAvtokampa(cenik_id);
        }

        public async Task<List<Regije>> GetRegije()
        {
            return await _avtokampiRepository.GetRegije();
        }

        public async Task<List<Drzave>> GetDrzave()
        {
            return await _avtokampiRepository.GetDrzave();
        }

        public async Task<List<KampirnaMesta>> GetKampirnoMestoByAvtokamp(int avtokamp_id)
        {
            return await _kampirnaMestaRepository.GetKampirnoMestoByAvtokamp(avtokamp_id);
        }

        public async Task<KampirnaMesta> GetKampirnoMestoByID(int kamp_mesto_id)
        {
            return await _kampirnaMestaRepository.GetKampirnoMestoByID(kamp_mesto_id);
        }

        public async Task<bool> CreateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id)
        {
            return await _kampirnaMestaRepository.CreateKampirnoMesto(kamp_mesto, kamp_id);
        }

        public async Task<KampirnaMesta> UpdateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id, int kamp_mesto_id)
        {
            return await _kampirnaMestaRepository.UpdateKampirnoMesto(kamp_mesto, kamp_id, kamp_mesto_id);
        }

        public async Task<bool> RemoveKampMesto(int kamp_id, int kamp_mesto_id)
        {
            return await _kampirnaMestaRepository.RemoveKampMesto(kamp_id, kamp_mesto_id);
        }

        public async Task<List<Kategorije>> GetKategorijeKampirnihMest()
        {
            return await _kampirnaMestaRepository.GetKategorijeKampirnihMest();
        }

        public async Task<List<Storitve>> GetStoritve()
        {
            return await _storitveKampaRepository.GetStoritve();
        }

        public async Task<List<Storitve>> GetStoritveByKampirnoMesto(int kampirno_mesto_id)
        {
            return await _storitveKampaRepository.GetStoritveByKampirnoMesto(kampirno_mesto_id);
        }

        public async Task<List<Storitve>> GetStortiveByAvtokamp(int avtokamp_id)
        {
            return await _storitveKampaRepository.GetStortiveByAvtokamp(avtokamp_id);
        }

        public async Task<Storitve> GetStoritevByID(int storitev_id)
        {
            return await _storitveKampaRepository.GetStoritevByID(storitev_id);
        }

        public async Task<bool> CreateStoritev(Storitve storitev, int kamp_id)
        {
            return await _storitveKampaRepository.CreateStoritev(storitev, kamp_id);
        }

        public async Task<Storitve> UpdateStoritev(Storitve storitev, int storitev_id)
        {
            return await _storitveKampaRepository.UpdateStoritev(storitev, storitev_id);
        }

        public async Task<bool> RemoveStoritev(int storitev_id)
        {
            return await _storitveKampaRepository.RemoveStoritev(storitev_id);
        }

        public async Task<bool> CreateStoritevKapirnegaMesta(StoritveKampirnihMest storitev, int kamp_mesto_id)
        {
            return await _storitveKampaRepository.CreateStoritevKapirnegaMesta(storitev, kamp_mesto_id);
        }

        public async Task<List<KategorijeStoritev>> GetKategorijeStoritev()
        {
            return await _storitveKampaRepository.GetKategorijeStoritev();
        }
    }
}