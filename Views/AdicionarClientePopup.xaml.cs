using CommunityToolkit.Maui.Views;
using CrudBTG.Models;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CrudBTG.Views
{
    public partial class AdicionarClientePopup : Popup, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Cliente NovoCliente { get; private set; }
        public string Titulo { get; private set; }

        private string _ageText;
        public string AgeText
        {
            get => _ageText;
            set
            {
                if (int.TryParse(value, out int age) && age > 0)
                {
                    NovoCliente.Age = age;
                    _ageText = value;
                }
                else
                {
                    _ageText = string.Empty;
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSalvarEnabled));
            }
        }

        private string _enderecoCompleto;
        public string EnderecoCompleto
        {
            get => _enderecoCompleto;
            set
            {
                _enderecoCompleto = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSalvarEnabled));
            }
        }

        public bool IsSalvarEnabled =>
            !string.IsNullOrWhiteSpace(NovoCliente.Name) &&
            !string.IsNullOrWhiteSpace(NovoCliente.Lastname) &&
            NovoCliente.Age > 0 &&
            EnderecoCompleto.Split(',').Length == 3 &&
            EnderecoCompleto.EndsWith("Brasil");

        public ICommand CancelarCommand { get; }
        public ICommand SalvarCommand { get; }

        public AdicionarClientePopup(Cliente cliente = null)
        {
            InitializeComponent();

            NovoCliente = cliente ?? new Cliente();
            Titulo = cliente == null ? "Adicionar Cliente" : "Editar Cliente";

            AgeText = NovoCliente.Age > 0 ? NovoCliente.Age.ToString() : string.Empty;
            EnderecoCompleto = !string.IsNullOrWhiteSpace(NovoCliente.Address)
                ? NovoCliente.Address
                : "Brasília, DF, Brasil";

            CancelarCommand = new Command(() => Close(null));
            SalvarCommand = new Command(() =>
            {
                NovoCliente.Address = EnderecoCompleto;
                Close(NovoCliente);
            }, () => IsSalvarEnabled);

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(IsSalvarEnabled))
                {
                    ((Command)SalvarCommand).ChangeCanExecute();
                }
            };

            BindingContext = this;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
