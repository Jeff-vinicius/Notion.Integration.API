
<h1 align="center">Notion Integration API</h1>

<p align="center">Criação de páginas automaticamente no Notion, consumindo uma API fake utilizando .NET6 </p>

### Pré-requisitos da API

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [.NET6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0), [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/downloads/)

### Pré-requisitos do Notion 
Criar uma conta no [Notion](https://www.notion.so/pt-br)

Necessário criar um usuário de integração para obter o token de acesso na API, conforme exemplo abaixo: 
![token](https://github.com/Jeff-vinicius/Notion.Integration.API/blob/master/src/images/internal_integration_token.JPG)

Criar uma página base no Notion e compartilhar com o usuário criado na etapa anterior, conforme exemplo abaixo 
![share](https://github.com/Jeff-vinicius/Notion.Integration.API/blob/master/src/images/share_notion.JPG)

### Utilizando a API de Integração 
Necessário informar os seguintes campos no body da requisição: 
- notion_authorization (token do usuário de integração criado)
- manager_notion (nome do responsável pelos usuários)
- notion_page_id (id da página base criada, se encontra na url conforme exemplo abaixo, apartir do número 9)
  ![url](https://github.com/Jeff-vinicius/Notion.Integration.API/blob/master/src/images/url_id.JPG)
  
### Exemplo com o resultado da integração 
Os dados para criação das páginas, são obtidos através desta [API Fake](https://jsonplaceholder.typicode.com/)

Título da página recebe o nome de cada usuário

#### Estrutura geral das páginas:
![general_structure](https://github.com/Jeff-vinicius/Notion.Integration.API/blob/master/src/images/general_structure.JPG)

#### Estrutura da página de gerente:
![manager_structure](https://github.com/Jeff-vinicius/Notion.Integration.API/blob/master/src/images/manager_structure.JPG)

#### Estrutura da página de usuário:
##### Bloco de informações geraris com os campos telefone, e-mail, empresa e cidade:
![user_information_structure](https://github.com/Jeff-vinicius/Notion.Integration.API/blob/master/src/images/user_information_structure.JPG)

##### Bloco de tarefas, caso já esteja concluída, opção check fica preenchida: 
![user_task_structure](https://github.com/Jeff-vinicius/Notion.Integration.API/blob/master/src/images/user_task_structure.JPG)

##### Bloco de publicações, onde é possível visualizar o título e seus respectivos comentários:
![user_posts_structure](https://github.com/Jeff-vinicius/Notion.Integration.API/blob/master/src/images/user_posts_structure.JPG)

##### Bloco de estatísticas:
![user_posts_structure](https://github.com/Jeff-vinicius/Notion.Integration.API/blob/master/src/images/user_statistics_structure.JPG)

### Tecnologias utlizadas:

- .NET 6
- Swagger
- CQRS
- MediatR
- FluentValidation
- Flurl.Http
- Visual Studio 2022

Desenvolvido por Jefferson Vinicius!

[![Linkedin Badge](https://img.shields.io/badge/-Jefferson-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/jeffvinicius/)](https://www.linkedin.com/in/jeffvinicius/) 
[![Gmail Badge](https://img.shields.io/badge/-jefferson.vinicius.souza@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:jefferson.vinicius.souza@gmail.com)](mailto:jefferson.vinicius.souza@gmail.com?subject=Olá%20Jefferson%20Vinicius)
