# GerTarefas

GerTarefas é uma aplicação para gerenciamento de tarefas, onde você pode criar projetos, adicionar tarefas, atribuir responsáveis e acompanhar o progresso de suas atividades.

## Sobre o desenvolvimento da solução

### Funcionalidades

- Criar, editar e excluir projetos.
- Adicionar, editar e remover tarefas em um projeto.
- Atribuir responsáveis para as tarefas.
- Relatório de desempenho.

### Arquitetura Utilizada

Este projeto foi desenvolvido utilizando os princípios da Clean Architecture e CQRS (Command Query Responsibility Segregation).

### Tecnologias Utilizadas

- .NET 8 
- Entity Framework Core
- MediatR
- NUnit (para testes unitários)
- Swagger (para documentação da API)

#### Requisitos

- .NET Core SDK (versão 8)
- SQL Server (ou outro banco de dados suportado)

## Deploy e Execução no Docker

### Baixando imagem do sql-server (2017) ( Caso queira rodar o SQL Server em container )
-docker pull mcr.microsoft.com/mssql/server:2017-latest-ubuntu

### criando e executando o contêiner do Sql Server
- docker run -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Pwssa#2024' -e 'MSSQL_PID=Express' -p 1433:1433

### criando e executando o contêiner da aplicação
- caso use o SQL Server em servidor alterar o arquivo docker-compose.yml com as informações do banco 
- cd \<pasta da aplicação>
- docker-compose up --build

### executando a api no browser  (a porta está configurada no arquivo launchSettings.json)
- https://localhost:44382/swagger/index.html

## Perguntas para os POs

### Escopo do Projeto
- Qual é o escopo geral do projeto?
- Quais são os principais objetivos e metas que esperamos alcançar com este sistema?
- Além das funcionalidades oferecidas, quais outras a API deverá oferecer?
- Há alguma funcionalidade específica que seja crítica para o sucesso do projeto?

### Priorização de Funcionalidades
- Existe uma lista de priorização das funcionalidades? Quais são as prioridades?
- Quais funcionalidades são consideradas "essenciais" e devem ser implementadas primeiro?

### Integrações com Outros Sistemas
- O sistema precisa se integrar com outros sistemas ou serviços externos?
- Quais são os requisitos para essas integrações?

### Restrições e Limitações
- Existem restrições de orçamento, tempo ou recursos que devemos considerar?
- Há alguma limitação técnica ou de infraestrutura que possa afetar o desenvolvimento do sistema?

## Pontos de melhoria

### Implementação de Autenticação
- Atualmente, a API não possui um sistema de autenticação implementado.
- Opções sugeridas incluem: JSON Web Tokens (JWT), OAuth 2.0, Bearer Tokens
- Avaliar a possibilidade de integração com provedores de identidade externos, como Auth0 ou Azure AD, para simplificar a gestão de usuários e autenticação

### Logs e Auditoria
- Implementar a geração de logs de atividades na API para monitorar e rastrear ações dos usuários
- Registrar eventos importantes
  
