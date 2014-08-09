using Collection;
using Mixpanel.NET.Events;
using Model;
using Musicista.Collection;
using Musicista.Sidebar;
using Musicista.UI;
using Musicista.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;
using Path = System.Windows.Shapes.Path;

namespace Musicista
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static List<UIPage> PageList;
        public static Piece CurrentPiece;
        public static ApplicationSettings ApplicationSettings = new ApplicationSettings();
        public static CollectionBase CollectionBase = new CollectionBase();

        public static ScrollViewer UICanvasScrollViewer;
        public static ContentControl UISidebar;
        public static ContentControl UICollection;
        public static Path UIButtonPathInformation;
        public static Path UIButtonPathView;
        public static Path UIButtonPathAlgorithms;
        public static Path UIButtonPathCollection;

        public static MixpanelTracker Tracker { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            if (Properties.Settings.Default.SendCrashReport)
                Dispatcher.UnhandledException += Application_ThreadException;

            // Make ui-elements accessible by static methods
            UICanvasScrollViewer = CanvasScrollViewer;
            UISidebar = Sidebar;
            UICollection = CollectionContentControl;
            UIButtonPathInformation = ButtonPathInformation;
            UIButtonPathView = ButtonPathView;
            UIButtonPathAlgorithms = ButtonPathAlgorithms;
            UIButtonPathCollection = ButtonPathCollection;

            PreviewMouseWheel += Zoom;
            SetUpKeyCommands();

            LoadAppilcationSettings();
            LoadCollectionBase();

            SidebarInformation = new SidebarInformation();
            SidebarView = new SidebarView();
            SidebarAlgorithms = new SidebarAlgorithms();
            Sidebar.Content = SidebarInformation;
            ButtonPathInformation.Fill = Brushes.DodgerBlue;
            ButtonPathSelect.Fill = Brushes.DodgerBlue;

            CollectionWindow = new CollectionWindow();

            if (Application.Current.Properties["LoadFileOnStartup"] != null
                && (File.Exists(Application.Current.Properties["LoadFileOnStartup"].ToString())))
                OpenFile(Application.Current.Properties["LoadFileOnStartup"].ToString());
            else // Show start screen
            {
                var startScreen = new StartScreen();
                ShowMostRecentlyUsed(startScreen.RecentFilesStack);
                CanvasScrollViewer.Content = startScreen;
            }
            SidebarInformation.ShowPiece();

            if (String.IsNullOrEmpty(Properties.Settings.Default.Username))
                Properties.Settings.Default.Username = Environment.UserName;

            Tracker = new MixpanelTracker("4b33ac9fe9a2f777e40b9b0a213669fe");
            Tracker.Track("Start Program", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username } });
        }

        static void Application_ThreadException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Tracker.Track("Crash", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username } });

            var fromAddress = new MailAddress("musicista.app@gmail.com", "Jannik Arndt");
            var toAddress = new MailAddress("musicista.app@gmail.com", "Jannik Arndt");
            const string fromPassword = "Qzb-DwR-532-QAU";
            const string subject = "Exception Report Musicista";
            var exception = e.Exception;
            var body = "Message: " + exception.Message + "\n\nType: " + exception.GetType() + "\n\nData: " + exception.Data + "\n\nStack Trace: "
                       + exception.StackTrace + "\n\nSource: " + exception.Source + "\n\nComputer: " + Environment.OSVersion.VersionString + "\n\nUser Name: " +
                       Properties.Settings.Default.Username + " (" + Environment.UserName + ")";
            if (CurrentPiece != null)
                body += "\n\nCurrent Piece: " + CurrentPiece.Meta.Title + "\n\nURL: " + CurrentPiece.Meta.Weblink;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                //You can also use SendAsync method instead of Send so your application begin invoking instead of waiting for send mail to complete. SendAsync(MailMessage, Object) :- Sends the specified e-mail message to an SMTP server for delivery. This method does not block the calling thread and allows the caller to pass an object to the method that is invoked when the operation completes. 
                smtp.Send(message);
            }
        }

        private static void LoadAppilcationSettings()
        {
            if (File.Exists(ApplicationSettings.FileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(ApplicationSettings));
                ApplicationSettings = (ApplicationSettings)xmlSerializer.Deserialize(XDocument.Load(ApplicationSettings.FileName).CreateReader());
            }
            else
                ApplicationSettings.Save();
        }

        private static void LoadCollectionBase()
        {
            var xmlSerializer = new XmlSerializer(typeof(CollectionBase));
            CollectionBase = (CollectionBase)xmlSerializer.Deserialize(XDocument.Load("http://www.musicistaapp.de/download/Collection.xml").CreateReader());
        }

        private static void ShowMostRecentlyUsed(Panel stack)
        {
            foreach (var documentReference in ApplicationSettings.MostRecentlyUsed.Take(4))
            {
                const int totalLength = 80;
                var titleLength = documentReference.Name.Length;
                var pathLength = documentReference.Filepath.Length;
                var filepath = documentReference.Filepath;
                if (totalLength < (titleLength + pathLength))
                {
                    var endCharacters = Math.Max(0, totalLength - titleLength - 19);
                    filepath = documentReference.Filepath.Substring(0, 16) + "..." +
                               documentReference.Filepath.Substring((pathLength - endCharacters), endCharacters);
                }

                var mruTextBlock = new TextBlock
                {
                    FontSize = 12,
                    TextAlignment = TextAlignment.Left,
                    Margin = new Thickness(0, 8, 0, 0)
                };
                if (string.IsNullOrEmpty(documentReference.Name))
                    mruTextBlock.Inlines.Add(new Run(filepath));
                else
                {
                    mruTextBlock.Inlines.Add(new Run(documentReference.Name));
                    mruTextBlock.Inlines.Add(new Run(" (" + filepath + ")") { Foreground = Brushes.DarkGray });
                }
                mruTextBlock.MouseDown += (sender, args) => OpenFile(documentReference.Filepath);
                mruTextBlock.Cursor = Cursors.Hand;

                stack.Children.Add(mruTextBlock);
            }
        }

        public void Zoom(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Alt))
            {
                var currentMousePosition = Mouse.GetPosition(CanvasScrollViewer);
                var scaleTransform = CanvasScrollViewer.LayoutTransform as ScaleTransform;
                if (scaleTransform != null)
                {
                    scaleTransform.CenterX = currentMousePosition.X;
                    scaleTransform.CenterY = currentMousePosition.Y;
                    scaleTransform.ScaleX *= 1 + (e.Delta / 1000.0);
                    scaleTransform.ScaleY *= 1 + (e.Delta / 1000.0);

                    e.Handled = true;

                    CanvasScrollViewer.HorizontalScrollBarVisibility = scaleTransform.ScaleX > 1.05 ? ScrollBarVisibility.Visible : ScrollBarVisibility.Hidden;
                }
            }
        }

        public void SetUpKeyCommands()
        {
            // new
            var newCommandBinding = new CommandBinding(ApplicationCommands.New, New, (sender, e) => { e.CanExecute = true; });
            CommandBindings.Add(newCommandBinding);

            // open
            var openCommandBinding = new CommandBinding(ApplicationCommands.Open, Open, (sender, e) => { e.CanExecute = true; });
            CommandBindings.Add(openCommandBinding);

            // save
            var saveCommandBinding = new CommandBinding(ApplicationCommands.Save, Save, (sender, e) => { e.CanExecute = CurrentPiece != null; });
            CommandBindings.Add(saveCommandBinding);

            // save as
            var saveAsCommandBinding = new CommandBinding(ApplicationCommands.SaveAs, SaveAs, (sender, e) => { e.CanExecute = CurrentPiece != null; });
            CommandBindings.Add(saveAsCommandBinding);

            var saveAsKeyGesture = new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift);
            var saveAsInputBinding = new InputBinding(ApplicationCommands.SaveAs, saveAsKeyGesture);
            InputBindings.Add(saveAsInputBinding);

            // print
            var printCommandBinding = new CommandBinding(ApplicationCommands.Print, Print, (sender, e) => { e.CanExecute = CurrentPiece != null; });
            CommandBindings.Add(printCommandBinding);

            // close
            var closeCommandBinding = new CommandBinding(ApplicationCommands.Close, Close, (sender, e) => { e.CanExecute = CurrentPiece != null; });
            CommandBindings.Add(closeCommandBinding);

            var closeKeyGesture = new KeyGesture(Key.W, ModifierKeys.Control);
            var closeInputBinding = new InputBinding(ApplicationCommands.Close, closeKeyGesture);
            InputBindings.Add(closeInputBinding);

            // quit
            var quitCommandBinding = new CommandBinding(MediaCommands.BoostBass, (s, e) => Application.Current.Shutdown(),
                (sender, e) => { e.CanExecute = true; });
            CommandBindings.Add(quitCommandBinding);

            var quitKeyGesture = new KeyGesture(Key.Q, ModifierKeys.Control);
            var quitInputBinding = new InputBinding(MediaCommands.BoostBass, quitKeyGesture);
            InputBindings.Add(quitInputBinding);

            // esc
            var escCommandBinding = new CommandBinding(MediaCommands.DecreaseBass, (s, e) =>
            {
                UICollection.Content = null;
                UIButtonPathCollection.Fill = Brushes.Black;
            },
                (sender, e) => { e.CanExecute = true; });
            CommandBindings.Add(escCommandBinding);

            var escKeyGesture = new KeyGesture(Key.Escape);
            var escInputBinding = new InputBinding(MediaCommands.DecreaseBass, escKeyGesture);
            InputBindings.Add(escInputBinding);
        }

        private void New(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentPiece = new Piece(initialize: true);
            DrawPiece(CurrentPiece);
            _fileName = "";

            Tracker.Track("New Document", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username } });
        }

        private void Close(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentPiece = null;
            PageList = null;
            Sidebar.Content = new SidebarInformation();
            var startScreen = new StartScreen();
            ShowMostRecentlyUsed(startScreen.RecentFilesStack);
            CanvasScrollViewer.Content = startScreen;
            _fileName = "";

            Tracker.Track("Close Document", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username } });
        }

        private void Print(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new PrintDialog();

                if (dialog.ShowDialog() != true)
                    return;
                var stackPanel = CanvasScrollViewer.Content as StackPanel;
                if (stackPanel == null)
                    return;
                var visual = stackPanel.Children[0] as Canvas;
                if (visual != null)
                    dialog.PrintVisual(visual, "Drawing");

                Tracker.Track("Print", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username } });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while printing", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void DrawPiece(Piece piece)
        {
            CurrentPiece = piece;
            PageList = UIHelper.DrawPiece(CurrentPiece);

            var pages = new StackPanel();
            foreach (var page in PageList)
                pages.Children.Add(page);
            pages.Children.Add(new Canvas { Height = 200 });
            UICanvasScrollViewer.Content = pages;

            Tracker.Track("Draw Piece", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username }, { "Piece", piece.Meta.Title } });
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Tracker.Track("Close Program", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username } });
        }
    }
}