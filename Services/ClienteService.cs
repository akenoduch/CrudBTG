using CrudBTG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBTG.Services
{
    public class ClienteService
    {
        private readonly ObservableCollection<Cliente> _clientes;

        public ClienteService()
        {
            _clientes = new ObservableCollection<Cliente>();
        }

        public ObservableCollection<Cliente> GetClientes()
        {
            return _clientes;
        }

        public void AddCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public void RemoveCliente(Cliente cliente)
        {
            _clientes.Remove(cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            var index = _clientes.IndexOf(cliente);
            if (index >= 0)
                _clientes[index] = cliente;
        }
    }
}
