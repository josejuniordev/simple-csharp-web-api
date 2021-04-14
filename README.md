# Simples Web API com Asp.Net Core

## Instuções para rodar o projeto

A partir do terminal, navegue para a pasta _SimpleWebApi.Application_ e rode `dotnet run`. Após isso acesse _https://localhost:5001/swagger/index.html_ em seu navegador.
Você pode também rodar o projeto através de sua IDE preferida.

## Metodologia
O projeto foi desenvolvido usando TDD.

## Arquitetura Escolhida
Analisando o projeto, entendi que este poderia ser um microserviço ou a parte de um outro sistema maior, responsável pela parte de autenticação (crud de usuários, login, etc). Assim, escolhi usar uma arquitetura adaptada que nos fornece uma boa organização e separação de responsabilidades, uma arquitetura baseada no Clean Architecture, com algumas camadas.
Abaixo irei descreve-las.

### Core Layer
Nela ficam as entidades, objetos de valor, exceções de domínio... Nesse caso ela possúi apenas um objeto de valor e uma domain exception.

### Infra Layer
Camada responsável por nos fornecer um meio de acesso a dados, comunicação com serviços externos, envio de emails, etc... No nosso caso ela está vazia, já que não fazia parte da task em questão, porém, a criei para já deixar claro a organização escolhida.

### Application Layer
Responsável por expor os endpoints, receber as requisições, fazer a orquestração e comunicação entre as camadas e dar o retorno para o client.

### Tests Layer
Camada onde os testes de integração e unitários são escritos.