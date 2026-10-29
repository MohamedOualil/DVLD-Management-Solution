using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Features.Persons.Detail;
using DVLD.WinForms.Features.Test.TestTrackingRoadmap;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications.Detail
{
    public interface IApplicationDetailView
    {
        event EventHandler CanacleApplicationRequest;
        event EventHandler SaveEditApplicationRequest;

        event EventHandler ShowLicenses;
        event EventHandler BackToApplications;
        void LoadPersonInfo(PersonDto personDto);
        void LoadTestRoadmap(TestResultsRoadmapDto testResultsRoadmapDto);

        void DisplayMessage(string message);
        void SetBusy(bool busy);

        void ControlMode(StatusMode mode);
        int ApplicationLicenseClass { set; get; }
        string ApplicationId { set; get; }
        string StatusDate { set; }
        string CreateBy { set; }
        string ApplicationType { set; }
        string LocalApplicationId { set; get; }
        string Fees { set; }
        ApplicationStatusEnum ApplicationStatus { set;  }

       

    }
}
