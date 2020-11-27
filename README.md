# Guia Bar Api <img src="https://img.icons8.com/fluent/48/000000/beer.png"/>
<center><a href="https://www.linkedin.com/in/paloma-arize/"><img alt="Por: " src="https://img.shields.io/badge/Por:%20Paloma%20Arize-yellow"></a>  <a href="https://www.linkedin.com/in/paloma-arize/"><img alt="Tecnologias" src="https://img.shields.io/badge/Tecnologia-.NET%205.0-yellow"></a></center>

## 💻 Sobre o projeto

:beer: GuiaBar - é uma forma de conectar o público bohêmio e bares locais. Ele permite que o cliente veja as principais informações dos bares cadastrados, mostre o quão distante em quilometros e minutos ele está do bar escolhido e claro, que ao conhecer o bar ele também pode atribuir uma avaliação para que os outros usuários venha a fazer uma boa escolha! 


Projeto desenvolvido durante a **Talent Sprint 2020** oferecida pela [Solutis Tecnologias Ltda.](https://solutis.com.br/)
A Talent Sprint é uma seleção de profissionais entrry level por meio de desafios propostos em etapas! No ano de 2020 devido a pandemia do covid-19, todo o processo foi modelado para funcionar 100% online, tornando-o uma experiência ainda mais diferenciada.

---

## ⚙️ Funcionalidades
#### As funcionalidades dessa API são acessadas utilizando níveis de acesso!
##### Admin (Só é adicionado através de insert no banco de dados) 

- [x] Cadastra bares no banco de dados enviando suas principais informações:
  - [x] Nome
  - [x] Descrição
  - [x] Contato
  - [x] Endereço: 
    - Logradouro
    - Número
    - Bairro
    - Cidade-(Sigla do estado)
    - CEP

##### Public (Usuário não cadastrado)
- [x] Visualiza todos os bares cadastrados para que tenha um preview do quão útil o GuiaBar pode ser:
  - [x] Basta acessar a home
- [x] O usuário pode se cadastrar para ter acesso as demais funcionalidades enviando os seguintes dados:
  - [x] User Name
  - [x] Senha
  - [x] Email
  - [x] Endereço: 
    - Logradouro
    - Número
    - Bairro
    - Cidade-(Sigla do estado)
    - CEP
- [x] Login: uma vez cadastrado o usuário pode efetuar seu login enviando:
  - [x] User Name
  - [x] Senha

##### Common (Usuário cadastrado com login efetuado)
- [x] Calcula a distancia entre ele e o bar escolhido:
  - [x] Basta enviar o nome do bar
- [x] Avalia o bar que já conhce enviando:
  - [x] Nome do bar
  - [x] Avaliação de 0 a 5

---

## 🎨 Arquitetura

A arquitetura da aplicação foi inspirada na clean architecture microsoft:

<a href="https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures">
  <img alt="Made by palomaarize" src="https://img.shields.io/badge/Acessar%20Documentação%20-Microsoft-yellow">
</a>

##### A API foi montada utilizando três projetos, cada um com sua funcionalidade evitando dependências entre elas e desta forma tornando-a mais funcional e segura.

| Projeto        |  Tipo         |
|----------------|---------------|
| GuiaBar.API    | Asp Net Core  |
| GuiaBar.Data   | Class Library |
| GuiaBar.Domain | Class Library |


| Projeto        | Conteúdo                                           |Função                                   |
|----------------|----------------------------------------------------|-----------------------------------------|
| GuiaBar.API    |Controllers  e Requests com anotações para o Swagger| Controla a interação usuário e aplicação|
| GuiaBar.Data   |Repositorys e Contexto do banco de dados            | Camada de acesso a dados|
| GuiaBar.Domain |Entities, Services e Interfaces dos Repositórios e Serviços|Regras de negocio|


## 🚀 Como executar o projeto

💡É necessário ter o .NET SDK 5.0 e um banco de dados para funcionar.

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [.NetCore](https://dotnet.microsoft.com/download) e um banco de dados [Postgresql](https://www.postgresql.org/) com as tabelas que devem ser geradas com o [Script](https://github.com/palomaarize/GuiaBar/blob/master/scripts.sql) que estão nesse repositório.
Além disto caso queira por as mãos no código é bom ter um editor como o [VSCode.](https://code.visualstudio.com/)

#### 🎲 Rodando o Backend (servidor)

```bash

# Clone este repositório
$ git clone https://github.com/palomaarize/GuiaBar.git

# Acesse a pasta do projeto no terminal/cmd
$ cd GuiaBar

# Instale as dependências
$ dotnet restore

# Execute a aplicação em modo de desenvolvimento
$ dotnet run

# O servidor inciará na porta:5000 - acesse http://localhost:5000 

```
#### Para fazer uso de todos os metódos da API GuiaBar após o passo anterior acesse a documentação do Swagger e siga a exemplificação de chamadas.

> Acesse -> http://localhost:5000/swagger/v1/swagger.json



## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

#### **API**  ([.NetCore 5.0](https://docs.microsoft.com/pt-br/dotnet/core/dotnet-five))

**GuiaBar.API**

-   **[EFCore Naming Conventions](https://www.nuget.org/packages/EFCore.NamingConventions/5.0.0-rc1)**
-   **[Microsoft EntityFrameworkCore Proxies](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Proxies/)**
-   **[Microsoft AspNetCore Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.MicrosoftAccount)**
-   **[Leaflet](https://react-leaflet.js.org/en/)**
-   **[Microsoft AspNetCore Authentication JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/)**
-   **[Swashbuckle AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/)**

> Veja o arquivo  [GuiaBar.API.csproj](https://github.com/palomaarize/GuiaBar/blob/master/GuiaBar.API/GuiaBar.API.csproj)

**GuiaBar.Data**

-   **[Npgsql EntityFrameworkCore PostgreSQL](https://www.nuget.org/packages?q=Npgsql.EntityFrameworkCore.PostgreSQL)**

> Veja o arquivo  [GuiaBar.API.csproj](https://github.com/palomaarize/GuiaBar/blob/master/GuiaBar.Data/GuiaBar.Data.csproj)

**GuiaBar.Domain**

-   **[System.IdentityModel.Tokens.Jwt](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt/)**

> Veja o arquivo  [GuiaBar.API.csproj](https://github.com/palomaarize/GuiaBar/blob/master/GuiaBar.Domain/GuiaBar.Domain.csproj)


## 💜 Agradecimento

Muito obrigada a equipe Solutis por nos proporcionar essa experiência incrível e cheia de aprendizados!

Obrigada pessoalmente a Alex por ministrar as melhores "aulas" que não podem ser chamadas de aulas kkkkk

E obrigada aos coleguinhas de treinamento que trocaram dúvidas e conhecimento comigo!

<img src="https://media.giphy.com/media/VelWewgR6CpNK/giphy.gif"
height="200" width="200">
