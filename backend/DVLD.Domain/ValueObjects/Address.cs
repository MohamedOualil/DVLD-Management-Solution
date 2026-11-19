namespace DVLD.Domain.ValueObjects
{
    public sealed record Address
    {
        public string Street { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public string State { get; init; } = string.Empty;
        public string ZipCode { get; init; } = string.Empty;

        private Address() { }

        public Address(string street, string city, string state, string zipCode)
        {
            Street = street?.Trim() ?? string.Empty;
            City = city?.Trim() ?? string.Empty;
            State = state?.Trim() ?? string.Empty;
            ZipCode = zipCode?.Trim() ?? string.Empty;
        }

        public override string ToString()
        {
            return $"{Street}-{State}-{City}-{ZipCode}";
        }
    }
}
