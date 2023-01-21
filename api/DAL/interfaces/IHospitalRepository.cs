using System.Collections.Generic;
using System.Threading.Tasks;
using api.DAL.data;
using api.DAL.helpers;

namespace Cardiohelp.data.Interfaces
{
    public interface IHospitalRepository
    {
        Task<PagedList<hospital>> getHospitals(HospitalParams hos);
        Task<PagedList<hospital>> getHospitalsCountry(HospitalParams hos);
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<hospital> getHospitalDetails(int id);
        
    }

}