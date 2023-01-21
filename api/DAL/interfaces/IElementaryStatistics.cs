using System.Threading.Tasks;
using api.DAL.data;

namespace Cardiohelp.data.Interfaces
{
    public interface IElementaryStatistics
    {
         Task<ClassVlad> getAgeDistributionPerHospital();
    }
}