
# CrudBTG

CrudBTG é um aplicativo desenvolvido com .NET MAUI que implementa um sistema de cadastro de clientes (CRUD). O aplicativo utiliza o padrão **MVVM (Model-View-ViewModel)** e é projetado para rodar em várias plataformas, incluindo Android, iOS, MacCatalyst e Windows.

## Funcionalidades

- **Cadastrar Clientes**:
  - Insira informações como Nome, Sobrenome, Idade e Endereço (Cidade, UF, País).
- **Editar Clientes**:
  - Altere informações dos clientes já cadastrados.
- **Excluir Clientes**:
  - Remova clientes do cadastro com uma mensagem de confirmação.
- **Salvar Dados no Cache**:
  - Os dados são armazenados localmente no dispositivo utilizando `Preferences`, garantindo que sejam carregados ao reabrir o aplicativo.

## Tecnologias Utilizadas

- **.NET MAUI**: Framework multiplataforma.
- **MVVM**: Padrão arquitetural para separação de responsabilidades.
- **CommunityToolkit.Maui**: Para recursos como popups.
- **Preferences**: Para persistência de dados local.

## Pré-requisitos

Certifique-se de ter os seguintes softwares instalados em sua máquina:

- [Visual Studio 2022](https://visualstudio.microsoft.com/) com as cargas de trabalho:
  - Desenvolvimento para dispositivos móveis com .NET MAUI.
- .NET 8.0 SDK ou superior.

## Configuração do Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/akenoduch/CrudBTG.git
   cd CrudBTG
   ```

2. Abra o projeto no Visual Studio 2022.

3. Configure o dispositivo ou emulador:
   - Se estiver desenvolvendo para **Android**, configure um emulador no **Android Device Manager**.

4. Compile e execute o projeto:
   - Escolha o dispositivo/emulador no menu superior do Visual Studio.
   - Pressione `F5` ou clique em **Run**.

## Estrutura do Projeto

- **Models**:
  - Contém as definições das classes de modelo, como `Cliente`.
- **Views**:
  - Contém as páginas do aplicativo, como `ClientesPage` e popups.
- **ViewModels**:
  - Contém a lógica de negócios e de apresentação, como `ClientesViewModel`.
- **Services**:
  - Contém serviços auxiliares, como `ClienteService`, para gerenciamento de dados.

## Como Usar

1. **Adicionar Cliente**:
   - Na tela inicial, clique no botão **Adicionar Cliente**.
   - Preencha os campos obrigatórios e clique em **Salvar**.

2. **Editar Cliente**:
   - Clique no ícone de lápis no cartão de um cliente.
   - Atualize as informações desejadas e clique em **Salvar**.

3. **Excluir Cliente**:
   - Clique no ícone de lixeira no cartão de um cliente.
   - Confirme a exclusão na mensagem de diálogo.


---

## Contato

Criado por **[Felipe Lemos]** - Entre em contato:

- **E-mail**: [felipe.pye@gmail.com](mailto:felipe.pye@gmail.com)
- **LinkedIn**: [Felipe Lemos](https://linkedin.com/in/felipe-vilemondes/)
