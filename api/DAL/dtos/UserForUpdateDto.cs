using System;

namespace api.DAL.dtos
{
    public class UserForUpdateDto
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string user_role { get; set; }
        public DateTime paid_till { get; set; }
        public string active { get; set; }
        public string contributor_id { get; set; }
        public string center_id { get; set; }
       

    }
}