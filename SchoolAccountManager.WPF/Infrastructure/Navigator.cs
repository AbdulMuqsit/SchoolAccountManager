using System.Reflection;

namespace SchoolAccountManager.WPF.Infrastructure
{
    public static class Navigator
    {
        public static void SwitchView(ViewModelBase child, ViewModelBase parent = null)
        {
            if (parent == null) parent = ViewModelBase.ViewModelLocator.MainViewModel;
            PropertyInfo propertyInfo = parent.GetType().GetProperty("CurrentChildViewModel");
            if (propertyInfo != null) propertyInfo.SetValue(parent, child, null);
        }
    }
}