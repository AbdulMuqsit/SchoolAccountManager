using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using SchoolAccountManager.EF;
using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Annotations;

namespace SchoolAccountManager.WPF.Infrastructure
{
    public class ViewModelBase : ObjectBase
    {
        protected IRepository Repository { get; private set; }
        private static ViewModelLocator _viewModelLocator;

        public ViewModelBase()
        {
            Repository = new EfRepository();
        }
        public static ViewModelLocator ViewModelLocator
        {
            get
            {
                return _viewModelLocator ??
                       (_viewModelLocator =
                           (ViewModelLocator)Application.Current.Resources["Locator"]);
            }
        }

    }


}