using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace DVLD.WinForms.Shared
{
    public abstract class BasePresenter<TView> : IDisposable where TView : class
    {
        protected readonly TView View;

        public TView ViewInstance => View;

        protected readonly AppSession _session ;
        protected readonly INavigationService _navigationService ;

        protected BasePresenter(
            TView view,
            AppSession session, 
            INavigationService navigationService)
        {
            View = view;
            _session = session;
            _navigationService = navigationService;
            
        }
        public abstract void Dispose();
    }
}
