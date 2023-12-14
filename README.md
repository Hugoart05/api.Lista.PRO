ListaPRO - Controle interno de manutenção
API desenvolvida em ASP.NET Core, seguindo boas práticas e design patterns.

## Principais Características

- **Design Patterns e Clean Code:** Implementação seguindo boas práticas de design e código limpo.
- **Separação de Responsabilidades:** Cada componente possui uma única responsabilidade.
- **Injeção de Dependência:** Utilização extensiva para modularidade e testabilidade.
- **Entity Framework Core e Fluent API:** Interação com SQL Server de forma fluente.

## Como Usar

1. **Requisitos:**
   - [.NET Core SDK](https://dotnet.microsoft.com/download)

2. **Clone o Repositório:**
    ```bash
    git clone https://github.com/seu-usuario/seu-repositorio.git
    ```

3. **Configuração:**
    - Configure a string de conexão no arquivo `appsettings.json`.

4. **Migrações do Banco de Dados:**
    ```bash
    dotnet ef database update
    ```

5. **Execução:**
    ```bash
    dotnet run
    ```

A aplicação estará disponível em `http://localhost:5000`.

## Contribuição

Contribuições são bem-vindas! Abra uma "issue" para discutir mudanças e envie "pull requests" para colaborar.
