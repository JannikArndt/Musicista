using System;
using System.Collections.Generic;
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


            ComposersListView.ItemsSource = new List<CollectionComposer>
            {
                new CollectionComposer{Name = "Bach", Born = 1685, Died = 1750, Image = "images/Bach.jpg", Categories = new List<CollectionCategory>
                {
                    new CollectionCategory{CategoryName = "Fugen", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Fuge Nr. 1"}
                    }},
                    new CollectionCategory{CategoryName = "Concertos", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Brandenburgische Konzerte"}
                    }}
                }},
                new CollectionComposer{Name = "Beethoven", Born = 1770, Died = 1827, Image = "images/Beethoven.jpg", Categories = new List<CollectionCategory>
                {
                    new CollectionCategory{CategoryName = "Sinfonien", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Sinfonie Nr. 1"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 2"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 3"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 4"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 5"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 6"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 7"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 8"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 9"}

                    }},
                    new CollectionCategory{CategoryName = "Sonaten", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Sonate Nr. 1"},
                        new CategoryWork {WorkName = "Sonate Nr. 2"},
                        new CategoryWork {WorkName = "Sonate Nr. 17"},
                        new CategoryWork {WorkName = "Sonate Nr. 18"},
                        new CategoryWork {WorkName = "Sonate Nr. 24"},
                    }}
                }},
                new CollectionComposer{Name = "Mozart", Born = 1756, Died = 1791, Image = "images/Mozart.jpg", Categories = new List<CollectionCategory>
                {
                    new CollectionCategory{CategoryName = "Sinfonien", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Sinfonie Nr. 39"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 40"},
                        new CategoryWork {WorkName = "Sinfonie Nr. 41"}

                    }},
                    new CollectionCategory{CategoryName = "Opern", Works = new List<CategoryWork>
                    {
                        new CategoryWork {WorkName = "Figaro"},
                        new CategoryWork {WorkName = "Zauberflöte"},
                        new CategoryWork {WorkName = "Don Giovanni"}
                    }}
                }}
            };
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


    public class CollectionComposer
    {
        public string Name { get; set; }
        public int Born { get; set; }
        public int Died { get; set; }
        public string Image { get; set; }

        public int CountWorks { get { return Categories.Sum(collectionCategory => collectionCategory.Works.Count); } }
        public string Dates { get { return "(" + Born + "-" + Died + ")"; } }

        public List<CollectionCategory> Categories { get; set; }
    }

    public class CollectionCategory
    {
        public string CategoryName { get; set; }
        public List<CategoryWork> Works { get; set; }
    }

    public class CategoryWork
    {
        public string WorkName { get; set; }
    }
}
