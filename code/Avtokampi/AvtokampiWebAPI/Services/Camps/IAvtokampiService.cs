using AvtokampiWebAPI.Models.CampAggregate;
using AvtokampiWebAPI.Models.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services.Camps
{
    public interface IAvtokampiService
    {
        Task<PagedList<Avtokampi>> GetPage(AvtokampiParameters avtokampiParameters);

        Task<List<Avtokampi>> GetAll();

        Task<Avtokampi> GetAvtokampByID(int kamp_id);

        Task<bool> CreateAvtokamp(Avtokampi avtokamp);

        Task<Avtokampi> UpdateAvtokamp(Avtokampi avtokamp, int avtokamp_id);

        Task<bool> RemoveAvtokamp(int avtokamp_id);

        Task<Slike> GetSlikaAvtokampa(int kamp_id);

        Task<List<Slike>> GetSlikeAvtokampa(int kamp_id);

        Task<bool> CreateSlikaAvtokampa(Slike slika, int kamp_id);

        Task<bool> CreateSlikeAvtokampa(List<Slike> slike, int kamp_id);

        Task<Slike> UpdateSlikaAvtokampa(Slike slika, int slika_id);

        Task<List<Slike>> UpdateSlikeAvtokampa(List<Slike> slike, List<int> slika_id);

        Task<bool> RemoveSlikaAvtokampa(int slika_id);

        Task<List<Ceniki>> GetCenikiAvtokampa(int kamp_id);

        Task<Ceniki> GetCenikAvtokampa(int cenik_id);

        Task<bool> CreateCenikAvtokampa(Ceniki cenik, int kamp_id);

        Task<Ceniki> UpdateCenik(Ceniki cenik, int cenik_id);

        Task<bool> RemoveCenikAvtokampa(int cenik_id);

        Task<List<Regije>> GetRegije();

        Task<List<Drzave>> GetDrzave();


        Task<List<KampirnaMesta>> GetKampirnoMestoByAvtokamp(int avtokamp_id);

        Task<KampirnaMesta> GetKampirnoMestoByID(int kamp_mesto_id);

        Task<bool> CreateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id);

        Task<KampirnaMesta> UpdateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id, int kamp_mesto_id);

        Task<bool> RemoveKampMesto(int kamp_id, int kamp_mesto_id);

        Task<List<Kategorije>> GetKategorijeKampirnihMest();

        Task<List<Storitve>> GetStoritve();

        Task<List<Storitve>> GetStoritveByKampirnoMesto(int kampirno_mesto_id);

        Task<List<Storitve>> GetStortiveByAvtokamp(int avtokamp_id);

        Task<Storitve> GetStoritevByID(int storitev_id);

        Task<bool> CreateStoritev(Storitve storitev, int kamp_id);

        Task<Storitve> UpdateStoritev(Storitve storitev, int storitev_id);

        Task<bool> RemoveStoritev(int storitev_id);

        Task<bool> CreateStoritevKapirnegaMesta(StoritveKampirnihMest storitev, int kamp_mesto_id);

        Task<List<KategorijeStoritev>> GetKategorijeStoritev();
    }
}