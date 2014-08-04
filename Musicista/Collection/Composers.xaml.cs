using Collection;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Musicista.Collection
{
    /// <summary>
    /// Interaction logic for Composers.xaml
    /// </summary>
    public partial class Composers
    {
        public Composers()
        {
            InitializeComponent();
            ComposersListView.ItemsSource = MainWindow.CollectionBase.Composers;
        }

        private void ComposerMouseOver(object sender, MouseEventArgs mouseEventArgs)
        {
            var composer = sender as FrameworkElement;
            if (composer == null) return;
            var item = composer.DataContext as CollectionComposer;
            if (item == null) return;
            CategoryListView.ItemsSource = item.Categories;
            ComposerPanel.DataContext = item;
            WorksListView.ItemsSource = item.Categories.SelectMany(cat => cat.Works);

            var view = (CollectionView)CollectionViewSource.GetDefaultView(WorksListView.ItemsSource);
            view.Filter = UserFilter;
        }

        private void CategoryMouseOver(object sender, MouseEventArgs mouseEventArgs)
        {
            var category = sender as FrameworkElement;
            if (category == null) return;
            var item = category.DataContext as CollectionCategory;
            if (item == null) return;
            WorksListView.ItemsSource = item.Works;

            var view = (CollectionView)CollectionViewSource.GetDefaultView(WorksListView.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(WorkFilterBox.Text))
                return true;
            var categoryWork = item as CategoryWork;
            return categoryWork != null && (categoryWork.WorkName.IndexOf(WorkFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void WorkFilterBox_OnTextChanged(object sender, RoutedEventArgs routedEventArgs)
        {
            if (WorksListView.ItemsSource != null)
                CollectionViewSource.GetDefaultView(WorksListView.ItemsSource).Refresh();
        }
    }
}
