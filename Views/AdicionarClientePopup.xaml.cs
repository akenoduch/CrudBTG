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

        private string _nameErro;
        public string NameErro
        {
            get => _nameErro;
            set
            {
                if (_nameErro != value)
                {
                    _nameErro = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _lastNameErro;
        public string LastNameErro
        {
            get => _lastNameErro;
            set
            {
                if (_lastNameErro != value)
                {
                    _lastNameErro = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _ageErro;
        public string AgeErro
        {
            get => _ageErro;
            set
            {
                if (_ageErro != value)
                {
                    _ageErro = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _enderecoErro;
        public string EnderecoErro
        {
            get => _enderecoErro;
            set
            {
                if (_enderecoErro != value)
                {
                    _enderecoErro = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _nameText;
        public string NameText
        {
            get => _nameText;
            set
            {
                if (_nameText != value)
                {
                    _nameText = value;
                    NovoCliente.Name = value;

                    OnPropertyChanged();
                    ValidateFields();
                }
            }
        }

        private string _lastNameText;
        public string LastNameText
        {
            get => _lastNameText;
            set
            {
                if (_lastNameText != value)
                {
                    _lastNameText = value;
                    NovoCliente.Lastname = value;

                    OnPropertyChanged();
                    ValidateFields();
                }
            }
        }

        private string _ageText;
        public string AgeText
        {
            get => _ageText;
            set
            {
                if (_ageText != value)
                {
                    if (int.TryParse(value, out int age) && age > 0)
                    {
                        NovoCliente.Age = age;
                        _ageText = value;
                    }
                    else
                    {
                        _ageText = string.Empty;
                        NovoCliente.Age = 0;
                    }

                    OnPropertyChanged();
                    ValidateFields();
                }
            }
        }

        private string _enderecoCompleto;
        public string EnderecoCompleto
        {
            get => _enderecoCompleto;
            set
            {
                if (_enderecoCompleto != value)
                {
                    _enderecoCompleto = value;
                    OnPropertyChanged();
                    ValidateFields();
                }
            }
        }

        private bool _isSalvarEnabled;
        public bool IsSalvarEnabled
        {
            get => _isSalvarEnabled;
            set
            {
                if (_isSalvarEnabled != value)
                {
                    _isSalvarEnabled = value;
                    OnPropertyChanged();
                    ((Command)SalvarCommand)?.ChangeCanExecute();
                }
            }
        }

        public ICommand CancelarCommand { get; }
        public ICommand SalvarCommand { get; }

        public AdicionarClientePopup(Cliente cliente = null)
        {
            InitializeComponent();

            NovoCliente = cliente ?? new Cliente
            {
                Name = string.Empty,
                Lastname = string.Empty,
                Address = "Brasília, DF, Brasil",
                Age = 0
            };

            Titulo = cliente == null ? "Adicionar Cliente" : "Editar Cliente";

            NameText = NovoCliente.Name;
            LastNameText = NovoCliente.Lastname;
            AgeText = NovoCliente.Age > 0 ? NovoCliente.Age.ToString() : string.Empty;
            EnderecoCompleto = string.IsNullOrWhiteSpace(NovoCliente.Address)
                ? "Brasília, DF, Brasil"
                : NovoCliente.Address;

            CancelarCommand = new Command(() => Close(null));

            SalvarCommand = new Command(
                execute: () =>
                {
                    NovoCliente.Address = EnderecoCompleto;
                    Close(NovoCliente);
                },
                canExecute: () => IsSalvarEnabled
            );

            ValidateFields(); 

            BindingContext = this;
        }

        private void ValidateFields()
        {
            NameErro = string.IsNullOrWhiteSpace(NovoCliente.Name)
                ? "O campo 'Name' é obrigatório."
                : null;

            LastNameErro = string.IsNullOrWhiteSpace(NovoCliente.Lastname)
                ? "O campo 'LastName' é obrigatório."
                : null;

            if (NovoCliente.Age <= 0)
                AgeErro = "A idade deve ser maior que zero.";
            else
                AgeErro = null;

            bool enderecoValido = !string.IsNullOrWhiteSpace(EnderecoCompleto)
                && EnderecoCompleto.Split(',').Length == 3
                && EnderecoCompleto.EndsWith("Brasil");

            EnderecoErro = enderecoValido
                ? null
                : "O endereço deve ter 3 partes (Cidade, UF, País) e terminar com 'Brasil'.";

            IsSalvarEnabled = string.IsNullOrWhiteSpace(NameErro)
                              && string.IsNullOrWhiteSpace(LastNameErro)
                              && string.IsNullOrWhiteSpace(AgeErro)
                              && string.IsNullOrWhiteSpace(EnderecoErro);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
