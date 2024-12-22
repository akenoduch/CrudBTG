using CrudBTG.Views;

namespace CrudBTG
{
    public partial class App : Application
    {
        public App(ClientesPage clientesPage)
        {
            InitializeComponent();
            Application.Current.UserAppTheme = AppTheme.Light;
            // MainPage = new AppShell(); // Desativado para iniciar com ClientesPage
            MainPage = new NavigationPage(clientesPage);

        }
    }
}
