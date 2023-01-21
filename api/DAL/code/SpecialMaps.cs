using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using api.DAL.data;
using api.DAL.dtos;
using api.DAL.helpers;
using AutoMapper;
using Cardiohelp.data.Interfaces;
using Microsoft.AspNetCore.Http;

namespace api.DAL.code
{
    public class SpecialMaps
    {
        
        private IHospitalRepository _hos;
        private IHttpContextAccessor _http;
        private IMapper _map;
        private Dropdownlists _drops;
        public SpecialMaps(
        IHttpContextAccessor http, 
        IHospitalRepository hos, 
        IMapper map, 
        Dropdownlists drops)
        {
            _http = http;
            _map = map;
            _drops = drops;
            _hos = hos;
        }
        public  User mapToUserAsync(UserForUpdateDto help, User h)
        {
            h.active = help.active;
           // h.center_id = await this.saveHospitalNameAsNumber(help.center_id);
            h.contributor_id = help.contributor_id;
            h.Id = help.Id;
            h.paid_till = help.paid_till;
            h.user_role = help.user_role;
            h.username = help.username;
            return h;
        }
        public async Task<UserForReturnDto> mapToUserForReturnAsync(User help)
        {
            var h = new UserForReturnDto();
            h.active = help.active;
            h.center_id = await this.getNameOfHospitalAsync(help.center_id);
            h.contributor_id = help.contributor_id;
            h.Id = help.Id;
            h.paid_till = help.paid_till;
            h.user_role = help.user_role;
            h.username = help.username;
            return h;
        } 
        // public UserForReturnDto mapToUserForReturn(User help){ return _map.Map<User, UserForReturnDto>(help);}
        public hospital mapToHospitalAsync(hospitalForUpdateDTO td, hospital hospital_before){
          return _map.Map<hospitalForUpdateDTO, hospital>(td,hospital_before);
        }

        public async Task<RegistryForReturnDto> mapToRegistryForDto(patientData pd){
            RegistryForReturnDto help = new RegistryForReturnDto();
            await Task.Run(()=>{
                help = _map.Map<RegistryForReturnDto>(pd);
                
            });
           return help;
           
        }
       public patientData mapToPatientData(RegistryForUpdateDTO rfu, patientData old)
        {
            return _map.Map<RegistryForUpdateDTO, patientData>(rfu, old);
        }
        public int getCurrentUserId()
        {
            var userId = _http.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Convert.ToInt32(userId);
        }
        private string getIndication(int indication)
        {
            var help = "";
            var ret = new List<Class_Item>();
            ret = _drops.getReasonForUse();
            help = ret.Find(x => x.value == indication).description;
            return help;
        }
        private async Task<string> getNameOfHospitalAsync(string center_id){
            
             if(String.IsNullOrEmpty(center_id)){return "Choose";}
             else{
             var help = Convert.ToInt32(center_id);
             var selectedHospital = await _hos.getHospitalDetails(help);
             return selectedHospital.name;}
        }
    }

}