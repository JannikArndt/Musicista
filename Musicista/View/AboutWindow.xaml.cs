using System;
using System.Reflection;
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
    }
}
