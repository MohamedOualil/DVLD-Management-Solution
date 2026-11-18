#nullable enable
using DVLD.Contracts.Persons;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Persons.ManagePeople
{
    public interface IPeopleView
    {
        event EventHandler? LoadRequested;
        event EventHandler<int>? PageRequested;
        event EventHandler? AddPersonRequested;
        event EventHandler<int>? ViewPersonRequested;
        event EventHandler<int>? EditPersonRequested;

        void DisplayPeople(IEnumerable<GetAllPersonResponse> people);
        void DisplayPagination(int pageNumber, int totalPages, int totalCount);
        void SetLoading(bool isLoading);
        void DisplayMessage(string message);
    }
}
