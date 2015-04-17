using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace SchoolAccountManager.WPF
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ig-NG");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("ig-NG");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ig-NG");
            base.OnStartup(e);
        }
    }
}