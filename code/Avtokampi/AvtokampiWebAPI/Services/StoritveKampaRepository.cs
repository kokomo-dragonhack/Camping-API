using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Models.CampAggregate;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services
{
    public class StoritveKampaRepository : IStoritveKampaRepository
    {
        private readonly avtokampiContext _db;

        public StoritveKampaRepository(avtokampiContext db)
        {
            _db = db;
        }

        public async Task<List<Storitve>> GetStoritve()
        {
            return await _db.Storitve.ToListAsync();
        }

        public async Task<List<Storitve>> GetStortiveByAvtokamp(int avtokamp_id)
        {
            var storitve_kampa = await _db.SoritveCenikov.Where(o => o.AvtokampiAvtokampId == avtokamp_id)
                .Select(o => o.StoritveStoritevId)
                .ToListAsync();
            List<Storitve> storitve = new List<Storitve>();

            storitve_kampa.ForEach(o =>
            {
                var storitev = _db.Storitve.Find(o);
                storitve.Add(storitev);
            });
            return storitve;
        }

        public async Task<List<Storitve>> GetStoritveByKampirnoMesto(int kampirno_mesto_id)
        {
            var storitve_kamp_mesta = await _db.StoritveKampirnihMest.Where(o => o.KampirnoMesto == kampirno_mesto_id)
                .Select(o => o.Storitev)
                .ToListAsync();
            List<Storitve> storitve = new List<Storitve>();

            storitve_kamp_mesta.ForEach(o =>
            {
                var storitev = _db.Storitve.Find(o);
                storitve.Add(storitev);
            });
            return storitve;
        }

        public async Task<Storitve> GetStoritevByID(int storitev_id)
        {
            return await _db.Storitve.FindAsync(storitev_id);
        }

        public async Task<bool> CreateStoritev(Storitve storitev, int kamp_id)
        {
            await _db.Storitve.AddAsync(storitev);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Storitve> UpdateStoritev(Storitve storitev, int storitev_id)
        {
            _db.Entry(storitev).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return await _db.Storitve.FindAsync(storitev_id);
        }

        public async Task<bool> RemoveStoritev(int storitev_id)
        {
            _db.Storitve.Remove(await _db.Storitve.FindAsync(storitev_id));
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateStoritevKapirnegaMesta(StoritveKampirnihMest storitev, int kamp_mesto_id)
        {
            await _db.StoritveKampirnihMest.AddAsync(storitev);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<KategorijeStoritev>> GetKategorijeStoritev()
        {
            return await _db.KategorijeStoritev.ToListAsync();
        }
    }
}