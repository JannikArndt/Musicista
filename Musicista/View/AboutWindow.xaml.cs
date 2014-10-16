using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Navigation;
using System.Xml;

namespace Musicista.View
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow
    {
        public AboutWindow()
        {
            InitializeComponent();
            VersionTextBlock.Text = "Version " + GetPublishedVersion();
        }

        /// <summary>
        /// Load the manifest end extract the version number
        /// </summary>
        /// <returns></returns>
        public static Version GetPublishedVersion()
        {
            var xmlDoc = new XmlDocument();
            var asmCurrent = Assembly.GetExecutingAssembly();
            var executePath = new Uri(asmCurrent.GetName().CodeBase).LocalPath;

            xmlDoc.Load(executePath + ".manifest");
            var retval = string.Empty;
            if (xmlDoc.HasChildNodes)
            {
                retval = xmlDoc.ChildNodes[1].ChildNodes[0].Attributes.GetNamedItem("version").Value;
            }
            return new Version(retval);
        }

        /// <summary>
        /// Open the browser with the given link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
