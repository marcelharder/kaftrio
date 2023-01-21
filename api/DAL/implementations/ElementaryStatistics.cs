using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DAL;
using api.DAL.data;
using Cardiohelp.data.Interfaces;

namespace Cardiohelp.data.Implementations
{
    public class ElementaryStatistics : IElementaryStatistics
    {
        private dataContext _context;
        public ElementaryStatistics(dataContext context)
        {
            _context = context;
        }

         public async Task<ClassVlad> getAgeDistributionPerHospital()
        {
            var help = new List<string>();
            var helpDouble = new List<double>();
            var result = new ClassVlad();

            var list_of_ages = new List<int>();
  

            var obs = _context.Registries.ToList();

            foreach (patientData cp in obs)
            {
                list_of_ages.Add(cp.Age);
            }

            await Task.Run(() =>
            {

                result.caption = "Age distribution in hospital";
                help.Add("0-18");
                help.Add("18-30"); help.Add("31-40"); help.Add("41-50"); help.Add("51-60");
                help.Add("61-70"); help.Add("71-80"); help.Add("81-90");
                result.dataXas = help.ToArray();
                helpDouble.Add(getAge(0, list_of_ages));
                helpDouble.Add(getAge(1, list_of_ages));
                helpDouble.Add(getAge(2, list_of_ages));
                helpDouble.Add(getAge(3, list_of_ages));
                helpDouble.Add(getAge(4, list_of_ages));
                helpDouble.Add(getAge(5, list_of_ages));
                helpDouble.Add(getAge(6, list_of_ages));
                helpDouble.Add(getAge(7, list_of_ages));
                result.dataYas = helpDouble.ToArray();

            });
            return result;
        }
        private double getAge(int no, List<int> list_of_ages)
        {
            var help = 0.0;
            switch (no)
            {
                case 0: foreach (int a in list_of_ages) { if (0 < a && a < 17) { help++; } }; break;
                case 1: foreach (int a in list_of_ages) { if (18 < a && a < 30) { help++; } }; break;
                case 2: foreach (int a in list_of_ages) { if (31 < a && a < 40) { help++; } }; break;
                case 3: foreach (int a in list_of_ages) { if (41 < a && a < 50) { help++; } }; break;
                case 4: foreach (int a in list_of_ages) { if (51 < a && a < 60) { help++; } }; break;
                case 5: foreach (int a in list_of_ages) { if (61 < a && a < 70) { help++; } }; break;
                case 6: foreach (int a in list_of_ages) { if (71 < a && a < 80) { help++; } }; break;
                case 7: foreach (int a in list_of_ages) { if (81 < a && a < 90) { help++; } }; break;

            }
            return help;
        }
    }
}
            