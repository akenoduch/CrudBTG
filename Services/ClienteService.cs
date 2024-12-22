using CrudBTG.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace CrudBTG.Services
{
    public class ClienteService
    {
        private const string ClientesKey = "ClientesCache";
        private readonly ObservableCollection<Cliente> _clientes;

        public ClienteService()
        {
            _clientes = LoadClientes();
        }

        public ObservableCollection<Cliente> GetClientes()
        {
            return _clientes;
        }

        public void AddCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
            SaveClientes();
        }

        public void UpdateCliente(Cliente cliente)
        {
            var index = _clientes.IndexOf(cliente);
            if (index >= 0)
            {
                _clientes[index] = cliente;
                SaveClientes();
            }
        }

        public void DeleteCliente(Cliente cliente)
        {
            if (_clientes.Contains(cliente))
            {
                _clientes.Remove(cliente);
                SaveClientes();          
            }
        }

        private void SaveClientes()
        {
            var clientesJson = JsonSerializer.Serialize(_clientes);
            Preferences.Set(ClientesKey, clientesJson);
        }

        private ObservableCollection<Cliente> LoadClientes()
        {
            if (Preferences.ContainsKey(ClientesKey))
            {
                var clientesJson = Preferences.Get(ClientesKey, string.Empty);
                if (!string.IsNullOrEmpty(clientesJson))
                {
                    return JsonSerializer.Deserialize<ObservableCollection<Cliente>>(clientesJson)
                           ?? new ObservableCollection<Cliente>();
                }
            }

            return new ObservableCollection<Cliente>();
        }
    }
}
