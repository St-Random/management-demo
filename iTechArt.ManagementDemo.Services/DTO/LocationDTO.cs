namespace iTechArt.ManagementDemo.Services.DTO
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual AddressDTO Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Comment { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
