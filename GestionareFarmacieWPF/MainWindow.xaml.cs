using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using GestionareFarmacie;

namespace GestionareFarmacie.WPF
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // Manageri de stocare
        private IStocareMedicamente adminMedicamente;
        private IStocareFarmacisti adminFarmacisti;

        // Entitățile selectate în formulare
        private Medicament medicamentCurent;
        private Farmacist farmacistCurent;

        // Listele observabile care se leagă la tabele
        public ObservableCollection<Medicament> ListaMedicamente { get; set; }
        public ObservableCollection<Farmacist> ListaFarmacisti { get; set; }

        public Medicament MedicamentCurent
        {
            get => medicamentCurent;
            set { medicamentCurent = value; OnPropertyChanged(); ActualizeazaCheckBoxuri(); }
        }

        public Farmacist FarmacistCurent
        {
            get => farmacistCurent;
            set { farmacistCurent = value; OnPropertyChanged(); }
        }

        public MainWindow()
        {
            InitializeComponent();

            // Inițializare Manageri
            adminMedicamente = new AdministrareMedicamente_FisierText();
            adminFarmacisti = new AdministrareFarmacisti_FisierText();

            // Inițializare Liste
            ListaMedicamente = new ObservableCollection<Medicament>();
            ListaFarmacisti = new ObservableCollection<Farmacist>();

            // Setare obiecte noi pentru pornire
            MedicamentCurent = new Medicament();
            FarmacistCurent = new Farmacist();

            DataContext = this;

            cmbTip.ItemsSource = Enum.GetValues(typeof(TipMedicament));

            // Încărcare date din fișiere text
            IncarcaMedicamente();
            IncarcaFarmacisti();
        }

        // ==========================================
        // LOGICĂ MEDICAMENTE (TAB 1)
        // ==========================================
        private void IncarcaMedicamente()
        {
            ListaMedicamente.Clear();
            foreach (var m in adminMedicamente.GetMedicamente()) ListaMedicamente.Add(m);
        }

        private MomentAdministrare GetMomentSelectat()
        {
            MomentAdministrare moment = MomentAdministrare.Nespecificat;
            if (cbDimineata.IsChecked == true) moment |= MomentAdministrare.Dimineata;
            if (cbPranz.IsChecked == true) moment |= MomentAdministrare.Pranz;
            if (cbSeara.IsChecked == true) moment |= MomentAdministrare.Seara;
            return moment;
        }

        private void ActualizeazaCheckBoxuri()
        {
            if (MedicamentCurent != null)
            {
                cbDimineata.IsChecked = MedicamentCurent.Moment.HasFlag(MomentAdministrare.Dimineata);
                cbPranz.IsChecked = MedicamentCurent.Moment.HasFlag(MomentAdministrare.Pranz);
                cbSeara.IsChecked = MedicamentCurent.Moment.HasFlag(MomentAdministrare.Seara);
            }
        }

        private void btnAdauga_Click(object sender, RoutedEventArgs e)
        {
            if (MedicamentCurent.EsteValid)
            {
                MedicamentCurent.Moment = GetMomentSelectat();
                MedicamentCurent.Id = new Random().Next(1, 1000);
                adminMedicamente.AdaugaMedicament(MedicamentCurent);
                IncarcaMedicamente();
                btnReset_Click(sender, e);
            }
            else MessageBox.Show("Erori în formularul medicamentelor.", "Atenție", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnModifica_Click(object sender, RoutedEventArgs e)
        {
            if (MedicamentCurent != null && MedicamentCurent.Id > 0 && MedicamentCurent.EsteValid)
            {
                MedicamentCurent.Moment = GetMomentSelectat();
                adminMedicamente.ModificaMedicament(MedicamentCurent);
                IncarcaMedicamente();
                MessageBox.Show("Modificat cu succes!");
            }
        }

        private void btnSterge_Click(object sender, RoutedEventArgs e)
        {
            if (MedicamentCurent != null && MedicamentCurent.Id > 0)
            {
                if (MessageBox.Show($"Ștergi {MedicamentCurent.Nume}?", "Confirmare", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    adminMedicamente.StergeMedicament(MedicamentCurent.Id);
                    IncarcaMedicamente();
                    btnReset_Click(sender, e);
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            MedicamentCurent = new Medicament();
            cbDimineata.IsChecked = false; cbPranz.IsChecked = false; cbSeara.IsChecked = false;
        }

        private void btnCauta_Click(object sender, RoutedEventArgs e)
        {
            string termen = txtCautare.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(termen))
            {
                var rezultate = adminMedicamente.GetMedicamente().Where(m => m.Nume != null && m.Nume.ToLower().Contains(termen));
                ListaMedicamente.Clear();
                foreach (var m in rezultate) ListaMedicamente.Add(m);
            }
        }

        private void btnToate_Click(object sender, RoutedEventArgs e)
        {
            txtCautare.Clear();
            IncarcaMedicamente();
        }

        // ==========================================
        // LOGICĂ FARMACIȘTI (TAB 2)
        // ==========================================
        private void IncarcaFarmacisti()
        {
            ListaFarmacisti.Clear();
            foreach (var f in adminFarmacisti.GetFarmacisti()) ListaFarmacisti.Add(f);
        }

        private void btnAdaugaFarmacist_Click(object sender, RoutedEventArgs e)
        {
            if (FarmacistCurent.EsteValid)
            {
                FarmacistCurent.Id = new Random().Next(1, 1000);
                adminFarmacisti.AdaugaFarmacist(FarmacistCurent);
                IncarcaFarmacisti();
                btnResetFarmacist_Click(sender, e);
            }
            else MessageBox.Show("Numele farmacistului este obligatoriu.", "Atenție", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnModificaFarmacist_Click(object sender, RoutedEventArgs e)
        {
            if (FarmacistCurent != null && FarmacistCurent.Id > 0 && FarmacistCurent.EsteValid)
            {
                adminFarmacisti.ModificaFarmacist(FarmacistCurent);
                IncarcaFarmacisti();
                MessageBox.Show("Date farmacist modificate!");
            }
        }

        private void btnStergeFarmacist_Click(object sender, RoutedEventArgs e)
        {
            if (FarmacistCurent != null && FarmacistCurent.Id > 0)
            {
                if (MessageBox.Show($"Ștergi farmacistul {FarmacistCurent.Nume}?", "Confirmare", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    adminFarmacisti.StergeFarmacist(FarmacistCurent.Id);
                    IncarcaFarmacisti();
                    btnResetFarmacist_Click(sender, e);
                }
            }
        }

        private void btnResetFarmacist_Click(object sender, RoutedEventArgs e)
        {
            FarmacistCurent = new Farmacist();
        }

        // ==========================================
        // NOTIFICĂRI
        // ==========================================
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}