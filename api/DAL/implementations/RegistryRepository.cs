using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DAL;
using api.DAL.code;
using api.DAL.data;
using api.DAL.dtos;
using api.DAL.helpers;
using AutoMapper;
using Cardiohelp.data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api
{
    public class RegistryRepository : IRegistryRepository
    {

         private dataContext _context;
         private SpecialMaps _spm;
        public RegistryRepository(dataContext context, SpecialMaps spm)
        {
            _context = context;
            _spm = spm;
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

        public async Task<PagedList<patientData>> getListOfRegistries(UserParams p)
        {
            var regs = _context.Registries.OrderByDescending(u => u.Id).AsQueryable();
           // messages = messages.Where(m => m.center_id == p.center_id);
            return await PagedList<patientData>.CreateAsync(regs, p.PageNumber, p.PageSize);
          
        }
        public async Task<RegistryForReturnDto> getRegistry(int id)
        {
            var result = await _context.Registries.FirstOrDefaultAsync(x => x.Id == id);
            var help = await _spm.mapToRegistryForDto(result);
            return help;
        }

        public async Task<patientData> getFullPatientData(int id)
        {
            return await _context.Registries.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}