using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DAL;
using api.DAL.data;
using api.DAL.helpers;
using Cardiohelp.data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cardiohelp.data.Implementations{
    public class HospitalRepository : IHospitalRepository
    {
        private dataContext _context;
        public HospitalRepository(dataContext context)
        {
            _context = context;
        }
        public async Task<hospital> getHospitalDetails(int id)
        {
            var selectedHospital = await _context.Hospitals.FirstOrDefaultAsync(x => x.center_id == id); 
            return selectedHospital;
        }
    
        public async Task<PagedList<hospital>> getHospitalsCountry(HospitalParams p)
        {
            var hospitals = _context.Hospitals.AsQueryable();
            hospitals = hospitals.Where(m => m.country == p.country);
            return await PagedList<hospital>.CreateAsync(hospitals, p.PageNumber, p.PageSize);
        }

        public async Task<PagedList<hospital>> getHospitals(HospitalParams p)
        {
            var hospitals = _context.Hospitals.AsQueryable();
            //hospitals = hospitals.Where(m => m.country == p.country);
            return await PagedList<hospital>.CreateAsync(hospitals, p.PageNumber, p.PageSize);
        }

         public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}