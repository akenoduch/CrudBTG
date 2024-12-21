using System.Collections.ObjectModel;
using System.Windows.Input;
using CrudBTG.Models;
using CrudBTG.Services;

namespace CrudBTG.ViewModels
{
    public class ClientesViewModel : BaseViewModel
    {
        private readonly ClienteService _clienteService;

        public ObservableCollection<Cliente> Clientes { get; }
        public ICommand AddClienteCommand { get; }

        public ClientesViewModel(ClienteService clienteService)
        {
            _clienteService = clienteService;
            Clientes = _clienteService.GetClientes();
            AddClienteCommand = new Command(AdicionarCliente);
        }

        private void AdicionarCliente()
        {
            var novoCliente = new Cliente
            {
                Name = "Novo",
                Lastname = "Cliente",
                Age = 25,
                Address = "Endereço Padrão"
            };
            _clienteService.AddCliente(novoCliente);
        }
    }
}
