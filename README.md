# API_CRUD_DAPPER

Este projeto é uma aplicação desenvolvida em .NET 8, utilizando Dapper como ORM, seguindo uma arquitetura em camadas. Ele inclui um repositório genérico, AutoMapper para mapeamento de objetos, e Injeção de Dependência (DI) para gerenciamento de dependências.

## Estrutura do Projeto

O projeto está organizado nas seguintes camadas:

- **Data**: Contém a lógica de acesso a dados, incluindo o repositório genérico e as implementações específicas.
- **Domain**: Contém as entidades, DTOs, enums e interfaces que representam o domínio da aplicação.
- **Service**: Contém a lógica de negócios e serviços da aplicação.
- **WebApi**: Contém a API que expõe os endpoints da aplicação.

## Tecnologias Utilizadas

- **.NET 8**: Framework principal para desenvolvimento da aplicação.
- **Dapper**: ORM leve para mapeamento de objetos e consultas SQL.
- **AutoMapper**: Biblioteca para mapeamento automático de objetos.
- **Injeção de Dependência (DI)**: Padrão de design para gerenciamento de dependências.

## Como Executar o Projeto

1. Clone o repositório para sua máquina local.
2. Certifique-se de ter o .NET 8 SDK instalado.
3. Navegue até o diretório da camada `WebApi` e execute o comando:
   ```bash
   dotnet run
