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

namespace FormularzStudenta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StringBuilder studentsData = new StringBuilder();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // Walidacja
            if (string.IsNullOrEmpty(firstNameTextbox.Text) ||
    string.IsNullOrEmpty(lastNameTextbox.Text) ||
    birthDatepicker.SelectedDate == null ||
   fieldOfStudies.SelectedItem == null) 
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola", "Błąd walidacji", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Akceptacja EULA
            //Pobieramy dane i zapisujemy do zmiennej
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}