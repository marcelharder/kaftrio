using System.ComponentModel.DataAnnotations;

namespace api.DAL.data
{
    public class hospital
    {
        public int Id { get; set; }
        public int center_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string pobox { get; set; }
        public string tel { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string country { get; set; }
    }
}