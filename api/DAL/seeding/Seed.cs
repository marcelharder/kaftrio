using System.Collections.Generic;
using System.Threading.Tasks;
using api.DAL.data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace api.DAL.seeding
{
public class Seed
    {
        public static async Task SeedUsers(dataContext context)
        {
            if(await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("DAL/seeding/seedUsers.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA1())
            {
                user.username = user.username.ToLower();
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("password"));
            }
                context.Users.Add(user);
            }
            await context.SaveChangesAsync();

        }
       
        public static async Task  SeedHospitals(dataContext context)
        {
            if(await context.Hospitals.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("DAL/seeding/seedHospitals.json");
            var emp = JsonConvert.DeserializeObject<List<hospital>>(userData);
            foreach (var item in emp)
            {
               context.Hospitals.Add(item);
            }
            await context.SaveChangesAsync();
            
        }
       
        public static async Task  SeedRegistries(dataContext context)
        {
            if(await context.Registries.AnyAsync()) return;

            var regData = await System.IO.File.ReadAllTextAsync("DAL/seeding/seedRegistries.json");
            var emp = JsonConvert.DeserializeObject<List<patientData>>(regData);
            foreach (var item in emp)
            {
               context.Registries.Add(item);
            }
            await context.SaveChangesAsync();
            
        }
       
       
       
        
    }
}