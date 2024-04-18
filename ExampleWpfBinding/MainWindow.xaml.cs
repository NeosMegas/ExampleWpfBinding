using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExampleWpfBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<ExampleItem> ExampleListOfItems { get; set; } = new List<ExampleItem>()
        {
            new ExampleItem() { Text = "Вася" },
            new ExampleItem() { Text = "Петя" }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExampleListOfItems.Add(new ExampleItem() { Text = txtAdd.Text });
            CollectionViewSource.GetDefaultView(lv.ItemsSource).Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ExampleItem? itemToRemove = cb.SelectedItem as ExampleItem;
            if (itemToRemove != null) {
                ExampleListOfItems.Remove(itemToRemove);
                CollectionViewSource.GetDefaultView(lv.ItemsSource).Refresh();
                cb.SelectedItem = ExampleListOfItems.FirstOrDefault();
            }
        }
    }

    public class ExampleItem
    {
        public string Text { get; set; } = string.Empty;
    }
}