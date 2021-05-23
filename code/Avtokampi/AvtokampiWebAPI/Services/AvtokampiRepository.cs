using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Models.CampAggregate;
using AvtokampiWebAPI.Models.Shared;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services
{
    public class AvtokampiRepository : IAvtokampiRepository
    {
        private readonly avtokampiContext _db;

        public AvtokampiRepository(avtokampiContext db)
        {
            _db = db;
        }

        public async Task<PagedList<Avtokampi>> GetPage(AvtokampiParameters avtokampiParameters)
        {
            return await PagedList<Avtokampi>.ToPagedList(_db.Avtokampi.OrderBy(on => on.Naziv),
                avtokampiParameters.PageNumber,
                avtokampiParameters.PageSize);
        }

        public async Task<List<Avtokampi>> GetAll()
        {
            return await _db.Avtokampi.ToListAsync();
        }

        public async Task<Avtokampi> GetAvtokampByID(int kamp_id)
        {
            return await _db.Avtokampi.FindAsync(kamp_id);
        }

        public async Task<bool> CreateAvtokamp(Avtokampi avtokamp)
        {
            avtokamp.CreatedAt = avtokamp.UpdatedAt = DateTime.Now;
            await _db.Avtokampi.AddAsync(avtokamp);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Avtokampi> UpdateAvtokamp(Avtokampi avtokamp, int avtokamp_id)
        {
            avtokamp.UpdatedAt = DateTime.Now;
            _db.Entry(avtokamp).State = EntityState.Modified;
            _db.Entry(avtokamp).Property(x => x.CreatedAt).IsModified = false;
            await _db.SaveChangesAsync();
            return await _db.Avtokampi.FindAsync(avtokamp_id);
        }

        public async Task<bool> RemoveAvtokamp(int avtokamp_id)
        {
            _db.Avtokampi.Remove(await _db.Avtokampi.FindAsync(avtokamp_id));
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Slike> GetSlikaAvtokampa(int kamp_id)
        {
            return await _db.Slike.Where(o => o.Avtokamp == kamp_id).FirstOrDefaultAsync();
        }

        public async Task<List<Slike>> GetSlikeAvtokampa(int kamp_id)
        {
            return await _db.Slike.Where(o => o.Avtokamp == kamp_id).ToListAsync();
        }

        public async Task<bool> CreateSlikaAvtokampa(Slike slika, int kamp_id)
        {
            slika.CreatedAt = slika.Updated = DateTime.Now;
            await _db.Slike.AddAsync(slika);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateSlikeAvtokampa(List<Slike> slike, int kamp_id)
        {
            await _db.Slike.AddRangeAsync(slike);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Slike> UpdateSlikaAvtokampa(Slike slika, int slika_id)
        {
            slika.Updated = DateTime.Now;
            _db.Entry(slika).State = EntityState.Modified;
            _db.Entry(slika).Property(x => x.CreatedAt).IsModified = false;
            await _db.SaveChangesAsync();
            return await _db.Slike.FindAsync(slika_id);
        }

        public async Task<List<Slike>> UpdateSlikeAvtokampa(List<Slike> slike, List<int> slika_id)
        {
            slike.ForEach(o =>
            {
                o.Updated = DateTime.Now;
                _db.Entry(o).State = EntityState.Modified;
                _db.Entry(o).Property(x => x.CreatedAt).IsModified = false;
                _db.SaveChangesAsync();
            });
            await _db.SaveChangesAsync();
            return slike;
        }

        public async Task<bool> RemoveSlikaAvtokampa(int slika_id)
        {
            _db.Slike.Remove(await _db.Slike.FindAsync(slika_id));
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Ceniki>> GetCenikiAvtokampa(int kamp_id)
        {
            return await _db.Ceniki.Where(o => o.Avtokamp == kamp_id).ToListAsync();
        }

        public async Task<Ceniki> GetCenikAvtokampa(int cenik_id)
        {
            return await _db.Ceniki.FindAsync(cenik_id);
        }

        public async Task<bool> CreateCenikAvtokampa(Ceniki cenik, int kamp_id)
        {
            cenik.CreatedAt = cenik.UpdatedAt = DateTime.Now;
            await _db.Ceniki.AddAsync(cenik);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Ceniki> UpdateCenik(Ceniki cenik, int cenik_id)
        {
            cenik.UpdatedAt = DateTime.Now;
            _db.Entry(cenik).State = EntityState.Modified;
            _db.Entry(cenik).Property(x => x.CreatedAt).IsModified = false;
            await _db.SaveChangesAsync();
            return await _db.Ceniki.FindAsync(cenik_id);
        }

        public async Task<bool> RemoveCenikAvtokampa(int cenik_id)
        {
            _db.Ceniki.Remove(await _db.Ceniki.FindAsync(cenik_id));
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Regije>> GetRegije()
        {
            return await _db.Regije.ToListAsync();
        }

        public async Task<List<Drzave>> GetDrzave()
        {
            return await _db.Drzave.ToListAsync();
        }
    }
}