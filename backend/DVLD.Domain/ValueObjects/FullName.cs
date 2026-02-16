

namespace DVLD.Domain.ValueObjects
{
    public sealed record FullName 
    {
        public string FirstName { get; init; }
        public string? SecondName { get; init; }
        public string? ThirdName { get; init; }
        public string LastName { get; init; }

        public FullName(string firstName,string secondName,string thirdName,string lastName)
        {
            FirstName = firstName.Trim();
            SecondName = secondName?.Trim();
            ThirdName = thirdName?.Trim();
            LastName = lastName.Trim();

        }

        public string GetFullName()
        {
            return $"{FirstName} {SecondName} {ThirdName} {LastName}";
        }
    }
}
