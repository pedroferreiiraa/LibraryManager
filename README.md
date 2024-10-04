# 🚀 LibraryManager

**LibraryManager** é um sistema de gerenciamento de biblioteca que permite o cadastro, consulta e gerenciamento de livros e usuários, além de realizar operações de empréstimo e devolução de forma prática e eficiente.

## Funcionalidades

- **Cadastrar Livros**: Adicione novos livros ao sistema.
- **Consultar Todos os Livros**: Liste todos os livros disponíveis na biblioteca.
- **Consultar Um Livro**: Obtenha detalhes de um livro específico.
- **Remover Livros**: Exclua livros que não estão mais disponíveis.
- **Cadastrar Usuários**: Adicione novos usuários ao sistema.
- **Cadastrar Empréstimos**: Registre empréstimos de livros para os usuários.
- **Cadastrar Data de Devolução**: Defina a data de devolução dos livros emprestados.
- **Devolver Livros**: Marque os livros como devolvidos no sistema.
- **Emitir Mensagens de Atraso**: Notifique os usuários sobre livros atrasados.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework utilizado para desenvolvimento da API.
- **Entity Framework Core**: ORM utilizado para acesso ao banco de dados.
- **SQL Server**: Sistema de gerenciamento de banco de dados utilizado.
- **Padrões de Projetos**: Implementação dos padrões CQRS e Repository para melhor organização e escalabilidade do código.

## Estrutura do Projeto

- **Controllers**: Contém as classes responsáveis por gerenciar as requisições HTTP.
- **Application**: Contém os comandos, consultas e lógicas de negócio.
- **Core**: Contém as entidades do domínio.
- **Persistence**: Contém a configuração do banco de dados e o contexto do Entity Framework.


