using Model.Meta.People;
using System.Windows;
using System.Windows.Input;

namespace Musicista.View
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class EditPerson
    {
        public EditPerson(Person person)
        {
            InitializeComponent();

            // Display info about the uiSymbol
            var grid = new GridTable(100);
            grid.AddRowWithTextField("First Name", person, "FirstName");
            grid.AddRowWithTextField("Middle Name", person, "MiddleName");
            grid.AddRowWithTextField("Last Name", person, "LastName");
            grid.AddRowWithTextField("Role", person, "Role");
            grid.AddRowWithTextField("Misc", person, "Misc");
            grid.AddRowWithTextField("Born", person, "BornString");
            grid.AddRowWithTextField("Died", person, "DiedString");
            MainStackPanel.Children.Add(grid);


            PreviewKeyDown += (sender, args) =>
            {
                if (args.Key == Key.Enter || args.Key == Key.Escape)
                {
                    CloseButton.Focus(); // to un-focus text fields and write the values
                    CloseClick(null, null);
                }
            };

        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            MainWindow.SidebarInformation.ShowPiece();
            if (MainWindow.PageList.Count > 0)
                MainWindow.PageList[0].Composer.Text = MainWindow.CurrentPiece.Meta.People.ComposersAsString;
            Close();
        }
    }
}
