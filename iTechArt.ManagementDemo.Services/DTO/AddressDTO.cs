namespace iTechArt.ManagementDemo.Services.DTO
{
    public class AddressDTO
    {
        public string Country { get; set; }

        // Area or County
        public string Area { get; set; }

        // City or town
        public string City { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
    }
}
