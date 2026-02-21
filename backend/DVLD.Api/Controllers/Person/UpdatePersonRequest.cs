namespace DVLD.Api.Controllers.Person
{
    public sealed record UpdatePersonRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string NationalNo { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gender { get; set; }

        // Address
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public int AddressCountryId { get; set; }

        // Contact
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? ImagePath { get; set; }
    }
}
