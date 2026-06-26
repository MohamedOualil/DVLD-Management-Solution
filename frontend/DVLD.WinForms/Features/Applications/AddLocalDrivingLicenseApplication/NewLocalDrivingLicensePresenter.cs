using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Persons.SelectPerson;
using DVLD.WinForms.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication
{
    public class NewLocalDrivingLicensePresenter : BasePresenter<INewLocalDrivingLicenseView>
    {
        private IServiceScope? _currentPageScope;
        private readonly IServiceProvider _serviceProvider;

        private int _selectedPersonId;

        private Action? _cleanupOldEvents;
        public NewLocalDrivingLicensePresenter(
            IServiceProvider serviceProvider,
            INewLocalDrivingLicenseView view, 
            AppSession session, 
            INavigationService navigationService) : base(view, session, navigationService)
        {
            _serviceProvider = serviceProvider;


        }


        public void FirstStep()
        {
            DisplayTo<SelectPersonPresenter, ISelectPersonView>(presenter =>
            {
                presenter.PersonSelected += Presenter_PersonSelected;
                presenter.NoPersonSelected += Presenter_NoPersonSelected;

                _cleanupOldEvents = () =>  
                {
                    presenter.PersonSelected -= Presenter_PersonSelected;
                    presenter.NoPersonSelected -= Presenter_NoPersonSelected;
                };
            });


        }

        private void Presenter_NoPersonSelected()
        {
            _selectedPersonId = 0;
            View.IsEnableNextStepButton = false;
        }

        private void SecondStep()
        {
            
        }

        private void Presenter_PersonSelected(int obj)
        {
            View.MessageLabel = false;
            _selectedPersonId = obj;
            View.IsEnableNextStepButton = true;

            if (_selectedPersonId <= 0)
            {
                View.DisplayMessage("Select The Person ");
                return;
            }
        }

        public override void Dispose()
        {
            _cleanupOldEvents?.Invoke();
            _cleanupOldEvents = null;

            _currentPageScope?.Dispose();
        }
        private void DisplayTo<TPresenter, TView>(Action<TPresenter> setup = null) where TPresenter
            : BasePresenter<TView> where TView : class
        {

            _cleanupOldEvents?.Invoke();
            _cleanupOldEvents = null; 

            _currentPageScope?.Dispose();
            _currentPageScope = _serviceProvider.CreateScope();

            var presenter = _currentPageScope.ServiceProvider.GetRequiredService<TPresenter>();

            setup?.Invoke(presenter);

            View.ShowChildView(presenter.ViewInstance);
        }

    }
}
