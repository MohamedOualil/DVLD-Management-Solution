namespace DVLD.Domain.ValueObjects
{
    public sealed record FullName
    {
        public string FirstName { get; init; } = string.Empty;
        public string? SecondName { get; init; }
        public string? ThirdName { get; init; }
        public string LastName { get; init; } = string.Empty;

        private FullName() { }

        public FullName(string firstName, string? secondName, string? thirdName, string lastName)
        {
            FirstName = firstName?.Trim() ?? string.Empty;
            SecondName = string.IsNullOrWhiteSpace(secondName) ? null : secondName.Trim();
            ThirdName = string.IsNullOrWhiteSpace(thirdName) ? null : thirdName.Trim();
            LastName = lastName?.Trim() ?? string.Empty;
        }

        public string GetFullName()
        {
            return string.Join(" ", new[] { FirstName, SecondName, ThirdName, LastName }
                .Where(part => !string.IsNullOrWhiteSpace(part)));
        }
    }
}
