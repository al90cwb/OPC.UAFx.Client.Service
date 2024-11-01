## Funcionalidades

- Conexão com servidor OPC usando a biblioteca `Opc.UaFx.Client`.
- Coleta de dados como nome do produto, nome do usuário, estado da máquina, produção total, ciclos, minutos trabalhados e rejeitos.
- Armazenamento dos dados em um banco de dados SQLite usando o Entity Framework Core.
- Serviço de fundo (`BackgroundService`) que coleta os dados a cada minuto.

## Estrutura do Projeto

### Classes Principais

- **Worker**: Classe de serviço de fundo que executa um loop para coletar dados a cada minuto e salvá-los no banco de dados.
- **MaquinaOee**: Modelo de dados para representar informações da máquina, incluindo propriedades como nome do produto, estado, produção, ciclos, minutos trabalhados e rejeitos.
- **MaquinaOeeClient**: Classe responsável por gerenciar a conexão OPC e realizar a coleta de dados, além de salvar esses dados no banco de dados.

## Dependências

Este projeto usa as seguintes bibliotecas e pacotes:

- **Microsoft.EntityFrameworkCore.Design** `8.0.10`
- **Microsoft.EntityFrameworkCore.Sqlite** `8.0.10`
- **Microsoft.Extensions.Hosting** `8.0.1`
- **Opc.UaFx.Client** `2.42.4`

## Instalação e Configuração

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 8.0 ou superior).
- [Entity Framework Core CLI](https://learn.microsoft.com/ef/core/cli/dotnet) para migrações e gerenciamento de banco de dados.
- [SQLite Viewer](https://sqlitebrowser.org/) (ou outro visualizador SQLite) para visualizar os dados do banco de dados.

### Passo a Passo

1. **Clone o Repositório**

   ```bash
   git clone https://github.com/SeuUsuario/OPC.UAFx.Client.Service.git
   cd OPC.UAFx.Client.Service

2. **Restaurar Pacotes**

    ```bash
    dotnet restore

3. **Configurar Banco de Dados**
   
   Primeiro adicione a Migração

    ```bash
    dotnet ef migrations add InitialCreate

    Depois, aplique a migração para criar o banco de dados:

    ```bash
    dotnet ef database update

Isso criará o arquivo MaquinaOee.db no diretório raiz do projeto.

3. **Execução**
    Para iniciar o serviço, execute dentro da pasta da aplicação:

    ```bash
    dotnet run

    O serviço iniciará, conectará ao servidor OPC configurado, coletará os dados e os armazenará no banco de dados SQLite a cada minuto.

4. **Visualização dos dados**

    Para visualizar os dados armazenados, abra o arquivo MaquinaOee.db em um visualizador de SQLite, como o DB Browser for SQLite. Acesse a tabela MaquinaOees para visualizar os dados coletados pela aplicação.

5. **Estrutura do Codigo**

    ```plaintext
        OPC.UAFx.Client.Service/
    ├── Migrations/                     # Contém as migrações do Entity Framework Core
    ├── Models/                         
    │   ├── AppDbContext.cs             # DbContext para gerenciar o banco de dados SQLite
    │   ├── MaquinaOee.cs               # Modelo de dados da máquina
    │   └── MaquinaOeeClient.cs         # Cliente OPC para coleta e armazenamento de dados
    ├── Worker.cs                       # Serviço de fundo que coleta os dados periodicamente
    ├── Program.cs                      # Ponto de entrada da aplicação
    └── OPC.UAFx.Client.Service.csproj  # Arquivo de projeto

    Certifique-se de que o endereço OPC configurado na classe MaquinaOeeClient esteja correto para o servidor OPC desejado. Para adicionar ou modificar os dados a serem coletados, ajuste os nós OPC nas leituras da classe MaquinaOeeClient.

6. **Licença**
Este projeto está licenciado sob os termos da MIT License. Consulte o arquivo LICENSE para mais detalhes.