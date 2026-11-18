#nullable enable
using DVLD.Contracts.InternationalLicenses;
using DVLD.Contracts.Licenses;
using DVLD.Contracts.Persons;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Licenses.LicenseHistory
{
    public interface ILicenseHistoryView
    {
        event EventHandler<int>? ViewLocalLicenseRequested;
        event EventHandler<int>? ViewInternationalLicenseRequested;
        event EventHandler<int>? LocalPageRequested;
        event EventHandler<int>? InternationalPageRequested;
        event EventHandler? CloseRequested;

        void DisplayPerson(PersonResponse person);
        void DisplayLocalLicenses(IEnumerable<GetLocalDrivingLicenseHistoryResponse> licenses);
        void DisplayInternationalLicenses(IEnumerable<GetInternationalDrivingLicenseHistoryResponse> licenses);
        void DisplayLocalPagination(int pageNumber, int totalPages, int totalCount);
        void DisplayInternationalPagination(int pageNumber, int totalPages, int totalCount);
        void DisplayMessage(string message);
    }
}
