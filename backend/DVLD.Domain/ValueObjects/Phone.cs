namespace DVLD.Domain.ValueObjects
{
    public sealed record Phone
    {
        public string PhoneNumber { get; init; } = string.Empty;

        private Phone() { }

        public Phone(string phonenumber)
        {
            PhoneNumber = phonenumber?.Trim() ?? string.Empty;
        }

        public override string ToString()
        {
            return PhoneNumber;
        }
    }
}
