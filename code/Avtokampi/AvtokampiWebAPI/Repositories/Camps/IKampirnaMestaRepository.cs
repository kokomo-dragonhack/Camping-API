using System.Collections.Generic;
using System.Threading.Tasks;
using AvtokampiWebAPI.Models.CampAggregate;

namespace AvtokampiWebAPI.Repositories.Camps
{
    public interface IKampirnaMestaRepository
    {
        Task<List<KampirnaMesta>> GetKampirnoMestoByAvtokamp(int avtokamp_id);

        Task<KampirnaMesta> GetKampirnoMestoByID(int kamp_mesto_id);

        Task<bool> CreateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id);

        Task<KampirnaMesta> UpdateKampirnoMesto(KampirnaMesta kamp_mesto, int kamp_id, int kamp_mesto_id);

        Task<bool> RemoveKampMesto(int kamp_id, int kamp_mesto_id);

        Task<List<Kategorije>> GetKategorijeKampirnihMest();
    }
}