using Model.Meta.People;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Musicista.View
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class EditPerson
    {
        public static Person Person { get; set; }
        public EditPerson(Person person)
        {
            InitializeComponent();
            Person = person;

            // Display info about the person

            PersonTypeComboBox.ItemsSource = new string[] { "Composer", "Lyricist", "Arranger", "Producer", "Interpreter", "Person" };
            PersonTypeComboBox.Text = person.GetType().Name;

            var grid = new GridTable(100);
            grid.AddRowWithTextField("First Name", Person, "FirstName");
            grid.AddRowWithTextField("Middle Name", Person, "MiddleName");
            grid.AddRowWithTextField("Last Name", Person, "LastName");
            grid.AddRowWithTextField("Role", Person, "Role");
            grid.AddRowWithTextField("Misc", Person, "Misc");
            grid.AddRowWithTextField("Born", Person, "BornString");
            grid.AddRowWithTextField("Died", Person, "DiedString");
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.CurrentPiece.Meta.People.Persons.Remove(Person);
            switch (PersonTypeComboBox.SelectedItem.ToString())
            {
                case "Composer":
                    Person = new Composer(Person);
                    break;
                case "Lyricist":
                    Person = new Lyricist(Person);
                    break;
                case "Arranger":
                    Person = new Arranger(Person);
                    break;
                case "Producer":
                    Person = new Producer(Person);
                    break;
                case "Interpreter":
                    Person = new Interpreter(Person);
                    break;
                case "Person":
                    Person = new Person(Person);
                    break;
            }
            MainWindow.CurrentPiece.Meta.People.Persons.Add(Person);
        }
    }
}
