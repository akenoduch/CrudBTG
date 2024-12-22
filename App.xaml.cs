using CrudBTG.Views;

namespace CrudBTG
{
    public partial class App : Application
    {
        public App(ClientesPage clientesPage)
        {
            InitializeComponent();
            // MainPage = new AppShell(); // Desativado para iniciar com ClientesPage
            MainPage = new NavigationPage(clientesPage);
        }
    }
}
