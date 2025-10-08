using Microsoft.Win32;
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
            if(EULACheckbox.IsChecked == false)
            {
                MessageBox.Show("Akceptacja regulaminu jest wymagana", "Błąd walidacji", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Pobieramy dane i zapisujemy do zmiennej

            string firstName = firstNameTextbox.Text;
            string lastName = lastNameTextbox.Text;
            string birthDate = birthDatepicker.SelectedDate.Value.ToString("dd-MM-yyyy");
            string fieldOfStudy = (fieldOfStudies.SelectedItem as ComboBoxItem).Content.ToString();
            bool newsletter = NewsletterCheckbox.IsChecked == true;

            //Tworzenie sformatowanego ciągu znaków z danymi studenta
            string studentInfo = $"Imię: {firstName}, Nazwisko: {lastName}, Data urodzenia: {birthDate}, Kierunek: {fieldOfStudy}, Newsletter: {(newsletter ? "Tak" : "Nie")}\n";

            //Dodajemy dane do zmiennej studentsData
            studentsData.Append(studentInfo);
            MessageBox.Show("Student został dodany do listy do zapisu", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            //Wyczyścić formularz
            clearForm();
        }

        private void clearForm()
        {
            firstNameTextbox.Clear();
            lastNameTextbox.Clear();
            birthDatepicker.SelectedDate = null;
            fieldOfStudies.SelectedItem = null;
            EULACheckbox.IsChecked = false;
            NewsletterCheckbox.IsChecked = false;
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearForm();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(studentsData.Length == 0)
            {
                MessageBox.Show("Brak danych do zapisania", "Informacja", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //Otwieramy okno dialogow do zpisu plików
            SaveFileDialog saveFileDialog = new SaveFileDialog();
        }
    }
}