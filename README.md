# 🚀 Royal Games

> Solução inteligente para o ciclo de vida de videogames: otimizando processos de compra, venda e troca de consoles e jogos de todas as eras em uma única plataforma.

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MySQL](https://img.shields.io/badge/mysql-%2300f.svg?style=for-the-badge&logo=mysql&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)
![Status](https://img.shields.io/badge/Status-Em%20Desenvolvimento-yellow?style=for-the-badge)

## 🛠 Tecnologias

As principais ferramentas utilizadas no desenvolvimento:

* **Linguagem:** C# (ASP.NET Core Web API)
* **Banco de Dados:** MySQL (Relacional)
* **ORM:** Entity Framework Core
* **Segurança:** Autenticação e Autorização via JWT (JSON Web Token)
* **Documentação:** Swagger (OpenAPI)

---

## 🏗 Estrutura do Banco de Dados

A aplicação utiliza uma estrutura relacional normalizada para garantir a integridade dos dados de inventário e usuários, permitindo uma gestão eficiente do catálogo.

### 📊 Modelagem Entidade-Relacionamento (DER)

Abaixo, os detalhes das principais entidades que compõem o sistema:

| Entidade | Descrição |
| :--- | :--- |
| **Usuario** | Armazena credenciais e status dos usuários (administradores/colaboradores) do sistema. |
| **Jogo** | Entidade central contendo título, preço, descrição, imagem e referências de classificação. |
| **Plataforma / Genero** | Tabelas auxiliares que permitem a categorização técnica e comercial dos itens. |
| **Classificacao** | Define a faixa etária ou categoria técnica específica de cada título. |
| **Log_AlteracaoJogo** | Tabela de auditoria para rastrear mudanças históricas de nome e preço dos jogos. |
