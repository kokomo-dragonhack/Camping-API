using System.Collections.Generic;
using System.Threading.Tasks;
using AvtokampiWebAPI.Models.CampAggregate;

namespace AvtokampiWebAPI.Repositories.Camps
{
    public interface IStoritveKampaRepository
    {
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