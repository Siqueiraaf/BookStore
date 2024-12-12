
# 📚 API de Livraria - .NET 8
Bem-vindo à API de Livraria, um projeto que explora as APIs mínimas do .NET 8. Esta API permite gerenciar um catálogo de livros com operações básicas de CRUD: listar todos os livros, recuperar um livro pelo ID, adicionar novos livros e excluir livros existentes.
![Captura de tela 2024-12-11 205905](https://github.com/user-attachments/assets/a65ca8dc-1a28-4b8f-91b5-0a434b0be3d3)

### 🛠️ Nesta MimalAPI Criamos:
    1. Criamos os modelos
    2. Criamos o contexto do banco de dados
    3. Criamos os contratos
    4. Adicionamos serviço
    5. Criamos as exceções
    6. Criamos os endpoints da API
    7. Adicionamos dados Seed(os primeiros dados) ao banco de dados
    8. Realizamos uma migração
    9. Testamos os endpoints da API

### 🌐 Métodos HTTP em APIs mínimas e baseadas em controladores

    GET: Recuperar dados (todos os livros ou por ID)
    POST: Adicionar novos livros
    DELETE: Excluir livros
    PUT: Atualizar um arquivo

### 📂 Arquivos de projeto de API mínima

    ├───Configurations/
    ├───Contracts/
    ├───Endpoints/
    ├───Exceptions/
    ├───Extensions/
    ├───Interfaces/
    ├───Migrations/
    ├───Models/
    └───Services/
    [Program.cs]


    🗃️ AppContext : contém o contexto do banco de dados e as configurações relacionadas.

    🌱 Configurações : contém configurações do Entity Framework Core e dados iniciais para o banco de dados.

    📜 Contratos : contém objetos de transferência de dados (DTOs) usados ​​em nosso aplicativo.

    📋 Endpoints : onde definimos e configuramos nossos endpoints mínimos de API.

    ⚠️ Exception : contém classes de exceção personalizadas usadas no projeto.

    🆙 Extensões : contém métodos de extensão que usaremos ao longo do projeto.

    📘 Modelos : contém modelos de lógica de negócios.

    🔧 Serviços : contém classes de serviço que implementam lógica de negócios.

    📑 Interfaces : contém definições de interface usadas para mapear nossos serviços.

✅ Conclusão
API mínima totalmente funcional no .NET 8 para gerenciar um catálogo de livros.


    
