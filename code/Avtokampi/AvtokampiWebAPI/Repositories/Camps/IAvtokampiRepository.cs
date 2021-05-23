using System.Collections.Generic;
using System.Threading.Tasks;
using AvtokampiWebAPI.Models.CampAggregate;
using AvtokampiWebAPI.Models.Shared;

namespace AvtokampiWebAPI.Repositories.Camps
{
    public interface IAvtokampiRepository
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
    }
}