
namespace DVLD.Domain.ValueObjects
{
    public record class Phone
    {
        public string PhoneNumber { get; init; }

        private Phone()
        {
            
        }

        public Phone(string phonenumber)
        {

            PhoneNumber = phonenumber.Trim().ToLowerInvariant();
        }

        public override string ToString()
        {
            return PhoneNumber;
        }
    }
}
