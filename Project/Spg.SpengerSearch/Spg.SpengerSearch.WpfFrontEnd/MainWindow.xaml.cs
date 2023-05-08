using Spg.SpengerSearch.CoreApplication;
using Spg.SpengerSearch.DomainModel.Infrastructure;
using Spg.SpengerSearch.WpfFrontEnd.Helpers;
using Spg.SpengerSearch.WpfFrontEnd.ViewModel;
using System.Windows;

namespace Spg.SpengerSearch.WpfFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Muss sein, weil ist von XAML vorgegeben
            InitializeComponent();

            // Dependency Injection ist OK, weil DB wird im ViewModel benötigt
            SpengerSearchContext db = new SpengerSearchContext(DatabaseUtilities.GenerateDbOptionsProductive());
            // ACHTUNG!! Wegwerf-Code
            DatabaseUtilities.GenerateDbAndSeed(db); // das hier sollte ja nur ein mal aufgerufen werden
            // ACHTUNG!! Wegwerf-Code

            DataContext = new MainWindowViewModel(
                db,
                new CategoryService(db));

            // Für Donnerstag: IServiceCollection implementieren
        }
    }
}
