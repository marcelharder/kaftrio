using System;
using System.IO;
using System.Threading.Tasks;
using Cardiohelp.data.Implementations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace api.DAL.helpers
{
    public static class Extensions
    {
       
        public static void AddApplicationError(this HttpResponse response, string message)
        {

            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today) age--;
            return age;
        }
       
       /*  public static string getGenderDescription(this string x)
        {
            var help = "Choose";
            if (x == "1") { help = "Male"; } else { if (x == "2") { help = "Female"; } }
            return help;
        }*/
          public static string getHospitalName(this string x)
        {
            var help = "0";
            switch(x){
               case "38": help = "UCRiverside"; break;
               case "5":  help = "OLVG"; break;
               case "6":  help = "Amphia"; break;
               default:   help = "n/a"; break;


            }
            return help;
        } 

    }
}