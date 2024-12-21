using Microsoft.Maui.Controls;
using CrudBTG.ViewModels;

namespace CrudBTG.Views
{
    public partial class ClientesPage : ContentPage
    {
        public ClientesPage(ClientesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}