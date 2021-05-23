using AvtokampiWebAPI.Models.CampAggregate;
using AvtokampiWebAPI.Models.UserAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services.Users
{
    public interface IUporabnikiService
    {
        Task<Uporabniki> GetUporabnikByID(int id);

        Task<Uporabniki> GetUporabnikByUsername(string username);

        Task<Uporabniki> UpdateUporabnik(Uporabniki uporabnik, int uporabnik_id);

        Task<bool> RemoveUporabnik(int uporabnik_id);

        Task<List<Mnenja>> GetMnenjeByUporabnik(int uporabnik_id);

        Task<List<Mnenja>> GetMnenjeByAvtokamp(int kamp_id);

        Task<Mnenja> GetMnenje(int mnenje_id);

        Task<bool> CreateMnenje(Mnenja mnenje, int kamp_id);

        Task<Mnenja> UpdateMnenje(Mnenja mnenje, int mnenje_id);

        Task<bool> RemoveMnenje(int mnenje_id);

        Task<bool> UporabnikExists(string username = null, int? up_id = null);
    }
}