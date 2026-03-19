# 🛒 Products API - .NET (In-Memory)

API RESTful simples para gerenciamento de produtos, desenvolvida com **ASP.NET Core** e **Entity Framework Core (In-Memory Database)**.
O projeto implementa operações completas de **CRUD (Create, Read, Update, Delete)** e inclui documentação interativa com **Swagger**.

---

## 🚀 Tecnologias Utilizadas

* .NET 6+
* ASP.NET Core Web API
* Entity Framework Core
* In-Memory Database
* Swagger / OpenAPI
* CORS habilitado (AllowAll)

---

## 📁 Estrutura do Projeto

```
backend/
│
├── Controllers/
│   └── ProductsController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   └── Products.cs
│
└── Program.cs
```

---

## ⚙️ Configuração e Execução

### Pré-requisitos

* .NET SDK instalado (6 ou superior)

### Passos

```bash
# Clonar o repositório
git clone <url-do-repositorio>

# Acessar a pasta do projeto
cd backend

# Restaurar dependências
dotnet restore

# Executar a aplicação
dotnet run
```

A API estará disponível em:

```
https://localhost:<porta>/swagger
```

---

## 📌 Funcionalidades

* ✅ Listar todos os produtos
* ✅ Buscar produto por ID
* ✅ Criar novo produto
* ✅ Atualizar produto existente
* ✅ Deletar produto
* ✅ Seed automático de dados (mock inicial)

---

## 🧠 Modelo de Dados

```json
{
  "id": 1,
  "name": "Burger",
  "price": 19.9,
  "image": "https://..."
}
```

### Propriedades

| Campo | Tipo   | Descrição                |
| ----- | ------ | ------------------------ |
| Id    | int    | Identificador único      |
| Name  | string | Nome do produto          |
| Price | double | Preço                    |
| Image | Uri    | URL da imagem do produto |

---

## 🔗 Endpoints da API

### 📥 GET - Listar todos os produtos

```
GET /api/products
```

---

### 📥 GET - Buscar produto por ID

```
GET /api/products/{id}
```

---

### 📤 POST - Criar novo produto

```
POST /api/products
```

Body:

```json
{
  "name": "Novo Produto",
  "price": 10.5,
  "image": "https://url-da-imagem"
}
```

---

### ✏️ PUT - Atualizar produto

```
PUT /api/products/{id}
```

---

### ❌ DELETE - Remover produto

```
DELETE /api/products/{id}
```

---

## 🌐 CORS

A API está configurada com política aberta:

```csharp
AllowAnyOrigin()
AllowAnyMethod()
AllowAnyHeader()
```

⚠️ **Atenção:** Essa configuração é recomendada apenas para desenvolvimento.

---

## 📊 Banco de Dados

* Utiliza **In-Memory Database**
* Dados são resetados a cada reinício da aplicação
* Seed automático com produtos mock

Exemplo de produtos carregados:

* Burger
* Frango
* Sanduíche
* Nuggets
* Tortilha
* Soda

---

## 📖 Documentação (Swagger)

Disponível automaticamente em ambiente de desenvolvimento:

```
/swagger
```

Permite:

* Testar endpoints
* Visualizar contratos
* Executar requisições diretamente no browser

---

## ⚠️ Observações Técnicas

* O método `PopulateProductsDB()` realiza seed inicial apenas uma vez usando flag estática
* Uso de `async void` não é recomendado para produção (ideal usar `Task`)
* Banco em memória não persiste dados
* Não há validação de modelo (Data Annotations)

---

## 🧩 Possíveis Melhorias

* 🔐 Implementar autenticação (JWT)
* 💾 Migrar para banco persistente (SQL Server / PostgreSQL)
* ✅ Adicionar validações com Data Annotations ou FluentValidation
* 🧪 Implementar testes unitários
* 📦 Criar DTOs e separar camadas (Service / Repository)
* 🐳 Dockerizar aplicação

---

## 👨‍💻 Autor

Desenvolvido como projeto de demonstração de API REST com .NET para teste ACT.

---

## 📄 Licença

Este projeto é livre para testes.

---
