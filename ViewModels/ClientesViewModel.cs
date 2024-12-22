using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using CrudBTG.Models;
using CrudBTG.Services;
using CrudBTG.Views;
using Microsoft.Maui.Controls;

namespace CrudBTG.ViewModels
{
    public class ClientesViewModel : BaseViewModel
    {
        private readonly ClienteService _clienteService;

        public ObservableCollection<Cliente> Clientes { get; }
        public ICommand AddClienteCommand { get; }
        public ICommand EditClienteCommand { get; }
        public ICommand DeleteClienteCommand { get; }

        public ClientesViewModel(ClienteService clienteService)
        {
            _clienteService = clienteService;
            Clientes = _clienteService.GetClientes();

            AddClienteCommand = new Command(AbrirPopupAdicionarCliente);
            EditClienteCommand = new Command<Cliente>(AbrirPopupEditarCliente);
            DeleteClienteCommand = new Command<Cliente>(ConfirmarExclusaoCliente);
        }

        private async void AbrirPopupAdicionarCliente()
        {
            var popup = new AdicionarClientePopup();
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);

            if (result is Cliente novoCliente)
            {
                _clienteService.AddCliente(novoCliente);
            }
        }

        private async void AbrirPopupEditarCliente(Cliente cliente)
        {
            var popup = new AdicionarClientePopup(cliente);
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);

            if (result is Cliente clienteEditado)
            {
                _clienteService.UpdateCliente(clienteEditado);
            }
        }

        private async void ConfirmarExclusaoCliente(Cliente cliente)
        {
            bool confirmacao = await Application.Current.MainPage.DisplayAlert(
                "Confirmação",
                $"Tem certeza que deseja excluir o cliente {cliente.Name} {cliente.Lastname}?",
                "Sim",
                "Não");

            if (confirmacao)
            {
                _clienteService.DeleteCliente(cliente);
            }
        }
    }
}
