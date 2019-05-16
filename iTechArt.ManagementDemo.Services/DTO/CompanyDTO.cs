using System;

namespace iTechArt.ManagementDemo.Services.DTO
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyCode { get; set; }
        public DateTime? DateFounded { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Comment { get; set; }
    }
}
