using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace GestionareFarmacie.WPF
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private AdministrareMedicamente_FisierText adminMedicamente;
        private AdministrareFarmacisti_FisierText adminFarmacisti;

        public ObservableCollection<Medicament> ListaMedicamente { get; set; }
        public ObservableCollection<Farmacist> ListaFarmacisti { get; set; }

        private Medicament medicamentCurent;
        public Medicament MedicamentCurent
        {
            get => medicamentCurent;
            set { medicamentCurent = value; OnPropertyChanged(); }
        }

        private Farmacist farmacistCurent;
        public Farmacist FarmacistCurent
        {
            get => farmacistCurent;
            set { farmacistCurent = value; OnPropertyChanged(); }
        }

        // Variabila pentru a ține minte utilizatorul logat
        private Farmacist utilizatorLogat;

        // CONSTRUCTOR MODIFICAT
        public MainWindow(Farmacist utilizator)
        {
            InitializeComponent();
            utilizatorLogat = utilizator;

            // Ascundem complet tab-ul de personal dacă NU este admin
            if (utilizatorLogat.EsteAdmin == false)
            {
                tabPersonal.Visibility = Visibility.Collapsed;
            }

            adminMedicamente = new AdministrareMedicamente_FisierText();
            adminFarmacisti = new AdministrareFarmacisti_FisierText();

            ListaMedicamente = new ObservableCollection<Medicament>();
            ListaFarmacisti = new ObservableCollection<Farmacist>();

            MedicamentCurent = new Medicament();
            FarmacistCurent = new Farmacist();

            DataContext = this;
            cmbTip.ItemsSource = Enum.GetValues(typeof(TipMedicament));

            IncarcaMedicamente();
            IncarcaFarmacisti();
        }

        private void IncarcaMedicamente()
        {
            var medicamente = adminMedicamente.GetMedicamente();
            ListaMedicamente.Clear();
            foreach (var m in medicamente) ListaMedicamente.Add(m);
        }

        private void IncarcaFarmacisti()
        {
            var farmacisti = adminFarmacisti.GetFarmacisti();
            ListaFarmacisti.Clear();
            foreach (var f in farmacisti) ListaFarmacisti.Add(f);
        }

        // ==========================================
        // LOGICA PENTRU MEDICAMENTE
        // ==========================================
        private void btnAdauga_Click(object sender, RoutedEventArgs e)
        {
            if (MedicamentCurent == null) return;

            if (MedicamentCurent.EsteValid)
            {
                int nouId = ListaMedicamente.Count > 0 ? ListaMedicamente.Max(m => m.Id) + 1 : 1;
                MedicamentCurent.Id = nouId;

                MomentAdministrare momenteSelectate = MomentAdministrare.Nespecificat;
                if (cbDimineata.IsChecked == true) momenteSelectate |= MomentAdministrare.Dimineata;
                if (cbPranz.IsChecked == true) momenteSelectate |= MomentAdministrare.Pranz;
                if (cbSeara.IsChecked == true) momenteSelectate |= MomentAdministrare.Seara;
                MedicamentCurent.Moment = momenteSelectate;

                Medicament medicamentDeAdaugat = new Medicament(MedicamentCurent.Id, MedicamentCurent.Nume!, MedicamentCurent.Tip, MedicamentCurent.Moment, MedicamentCurent.Pret, MedicamentCurent.Stoc, MedicamentCurent.DataExpirarii);

                adminMedicamente.AdaugaMedicament(medicamentDeAdaugat);
                ListaMedicamente.Add(medicamentDeAdaugat);
                MedicamentCurent = new Medicament();

                cbDimineata.IsChecked = false; cbPranz.IsChecked = false; cbSeara.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Completați corect toate datele medicamentului!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnModifica_Click(object sender, RoutedEventArgs e)
        {
            if (MedicamentCurent == null) return;
            if (dgMedicamente.SelectedItem != null && MedicamentCurent.EsteValid)
            {
                MomentAdministrare momenteSelectate = MomentAdministrare.Nespecificat;
                if (cbDimineata.IsChecked == true) momenteSelectate |= MomentAdministrare.Dimineata;
                if (cbPranz.IsChecked == true) momenteSelectate |= MomentAdministrare.Pranz;
                if (cbSeara.IsChecked == true) momenteSelectate |= MomentAdministrare.Seara;
                MedicamentCurent.Moment = momenteSelectate;

                adminMedicamente.ModificaMedicament(MedicamentCurent);
                IncarcaMedicamente();
                MedicamentCurent = new Medicament();
                cbDimineata.IsChecked = false; cbPranz.IsChecked = false; cbSeara.IsChecked = false;
            }
        }

        private void btnSterge_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedicamente.SelectedItem is Medicament medSelectat)
            {
                adminMedicamente.StergeMedicament(medSelectat.Id);
                ListaMedicamente.Remove(medSelectat);
                MedicamentCurent = new Medicament();
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            dgMedicamente.SelectedIndex = -1;
            MedicamentCurent = new Medicament();
            cbDimineata.IsChecked = false; cbPranz.IsChecked = false; cbSeara.IsChecked = false;
        }

        private void btnCauta_Click(object sender, RoutedEventArgs e)
        {
            string termen = txtCautare.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(termen))
            {
                var rezultate = adminMedicamente.GetMedicamente()
                    .Where(m => m.Nume != null && m.Nume.ToLower().Contains(termen))
                    .ToList();

                if (rezultate.Count == 0)
                {
                    MessageBox.Show($"Nu a fost găsit niciun medicament care să conțină '{termen}'.", "Căutare fără rezultate", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    ListaMedicamente.Clear();
                    foreach (var m in rezultate) ListaMedicamente.Add(m);
                }
            }
        }

        private void btnToate_Click(object sender, RoutedEventArgs e)
        {
            txtCautare.Clear();
            IncarcaMedicamente();
        }

        // ==========================================
        // LOGICA PENTRU FARMACIȘTI
        // ==========================================
        private void btnAdaugaFarmacist_Click(object sender, RoutedEventArgs e)
        {
            if (FarmacistCurent == null)
            {
                FarmacistCurent = new Farmacist();
                return;
            }

            if (FarmacistCurent.EsteValid)
            {
                int nouId = ListaFarmacisti.Count > 0 ? ListaFarmacisti.Max(f => f.Id) + 1 : 1;

                // Preluăm inclusiv statusul EsteAdmin
                Farmacist nouFarmacist = new Farmacist(nouId, FarmacistCurent.Nume!, FarmacistCurent.Email!, FarmacistCurent.Parola!, FarmacistCurent.EsteAdmin);

                adminFarmacisti.AdaugaFarmacist(nouFarmacist);
                ListaFarmacisti.Add(nouFarmacist);
                FarmacistCurent = new Farmacist();
            }
            else
            {
                MessageBox.Show("Vă rugăm să completați corect toate câmpurile contului!", "Formular invalid", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnModificaFarmacist_Click(object sender, RoutedEventArgs e)
        {
            if (FarmacistCurent == null) return;

            if (dgFarmacisti.SelectedItem is Farmacist farmacistSelectat && FarmacistCurent.EsteValid)
            {
                adminFarmacisti.ModificaFarmacist(FarmacistCurent);
                IncarcaFarmacisti();
                FarmacistCurent = new Farmacist();
                MessageBox.Show("Datele contului au fost actualizate!", "Modificare reușită", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnStergeFarmacist_Click(object sender, RoutedEventArgs e)
        {
            if (dgFarmacisti.SelectedItem is Farmacist farmacistSelectat)
            {
                var raspuns = MessageBox.Show($"Sigur doriți să ștergeți contul lui {farmacistSelectat.Nume}?", "Confirmare ștergere", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (raspuns == MessageBoxResult.Yes)
                {
                    adminFarmacisti.StergeFarmacist(farmacistSelectat.Id);
                    ListaFarmacisti.Remove(farmacistSelectat);
                    FarmacistCurent = new Farmacist();
                }
            }
        }

        private void btnResetFarmacist_Click(object sender, RoutedEventArgs e)
        {
            dgFarmacisti.SelectedIndex = -1;
            FarmacistCurent = new Farmacist();
        }

        // ==========================================
        // NOTIFICARE INTERFAȚĂ
        // ==========================================
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}