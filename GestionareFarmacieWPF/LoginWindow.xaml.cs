using System.Linq;
using System.Windows;

namespace GestionareFarmacie.WPF
{
    public partial class LoginWindow : Window
    {
        private AdministrareFarmacisti_FisierText adminFarmacisti;

        public LoginWindow()
        {
            InitializeComponent();
            adminFarmacisti = new AdministrareFarmacisti_FisierText();
        }

        private void btnConectare_Click(object sender, RoutedEventArgs e)
        {
            string emailIntrodus = txtEmail.Text.Trim();
            string parolaIntrodusa = txtParola.Password;

            if (string.IsNullOrEmpty(emailIntrodus) || string.IsNullOrEmpty(parolaIntrodusa))
            {
                MessageBox.Show("Vă rugăm să completați ambele câmpuri!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var listaFarmacisti = adminFarmacisti.GetFarmacisti();
            var farmacistGasit = listaFarmacisti.FirstOrDefault(f => f.Email == emailIntrodus && f.Parola == parolaIntrodusa);

            if (farmacistGasit != null)
            {
                // Date corecte -> Trimitem farmacistul găsit către fereastra principală
                MainWindow gestiuneWindow = new MainWindow(farmacistGasit);
                gestiuneWindow.Show();

                // Închidem fereastra de login
                this.Close();
            }
            else
            {
                MessageBox.Show("E-mail sau parolă incorectă!", "Autentificare eșuată", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRecuperareParola_Click(object sender, RoutedEventArgs e)
        {
            string emailIntrodus = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(emailIntrodus))
            {
                MessageBox.Show("Introduceți adresa de e-mail în câmpul de mai sus pentru a vă recupera parola.", "Recuperare parolă", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var listaFarmacisti = adminFarmacisti.GetFarmacisti();
            var farmacistGasit = listaFarmacisti.FirstOrDefault(f => f.Email == emailIntrodus);

            if (farmacistGasit != null)
            {
                MessageBox.Show($"Parola pentru contul dvs. este: {farmacistGasit.Parola}", "Recuperare reușită", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Nu există niciun cont asociat cu acest e-mail în sistem.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCreareCont_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pentru a crea un cont nou, vă rugăm să contactați administratorul farmaciei sau să vă logați cu contul de Admin.", "Informație", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}