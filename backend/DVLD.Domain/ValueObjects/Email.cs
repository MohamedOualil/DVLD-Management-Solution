namespace DVLD.Domain.ValueObjects
{
    public sealed record Email
    {
        public string? Value { get; init; }

        private Email() { }

        public Email(string? value)
        {
            Value = string.IsNullOrWhiteSpace(value)
                ? null
                : value.Trim().ToLowerInvariant();
        }
    }
}
