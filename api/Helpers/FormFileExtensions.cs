using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace api.DAL.helpers
{
    public static class FormFileExtensions
    {
         public static async Task<byte[]> GetBytes(this IFormFile formfile){
           using (var memoryStream = new MemoryStream()){

               await formfile.CopyToAsync(memoryStream);
               return memoryStream.ToArray();
           }

        }

        
    }
}