using DVLD.Contracts.Persons;

namespace DVLD.WinForms.Shared.Helpers;

public static class PersonDisplayExtensions
{
    public static string GetFullName(this PersonResponse person)
    {
        var parts = new[] { person.FirstName, person.SecondName, person.ThirdName, person.LastName };
        return string.Join(" ", parts.Where(part => !string.IsNullOrWhiteSpace(part)));
    }

    public static string GetFullAddress(this PersonResponse person) =>
        $"{person.Street}, {person.City}, {person.State} {person.ZipCode}, {person.CountryName}";
}
