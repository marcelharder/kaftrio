using System.Collections.Generic;
using System.Threading.Tasks;
using api.DAL.data;
using api.DAL.dtos;
using api.DAL.helpers;

namespace Cardiohelp.data.Interfaces
{
    public interface IRegistryRepository
    {
        Task<RegistryForReturnDto> getRegistry(int id);

        Task<patientData> getFullPatientData(int id);

        Task<PagedList<patientData>> getListOfRegistries(UserParams p);

        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveAll();


    }
}