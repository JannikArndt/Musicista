

using System;
using System.Windows;

namespace Musicista
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Check if this was launched by double-clicking a doc. If so, use that as the
            // startup file name.
            if (AppDomain.CurrentDomain.SetupInformation.ActivationArguments != null &&
                AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData != null
            && AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData.Length > 0)
            {
                try
                {
                    // It comes in as a URI; this helps to convert it to a path.
                    var uri = new Uri(AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData[0]);
                    Properties["LoadFileOnStartup"] = uri.LocalPath;
                }
                catch
                {
                    MessageBox.Show("Could not load file", "Error");
                }
            }

            base.OnStartup(e);
        }
    }
}
