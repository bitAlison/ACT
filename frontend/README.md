# 🛒 Product CRUD App (Angular + .NET API)

Aplicação full stack simples para gerenciamento de produtos, com operações completas de CRUD (Create, Read, Update, Delete).

O projeto é composto por:

* **Frontend**: Angular 21 + Angular Material (UI moderna e responsiva)
* **Backend**: API REST em .NET com Entity Framework (InMemory)

---

## 🚀 Funcionalidades

* 📋 Listagem de produtos em formato de **cards**
* ➕ Cadastro de novos produtos
* ✏️ Edição de produtos existentes
* 🔍 Visualização de detalhes
* ❌ Exclusão de produtos
* 🖼️ Exibição de imagem por URL
* 🔄 Integração completa com API REST

---

## 🧱 Arquitetura do Projeto

```bash
frontend/
│
├── src/app/
│   ├── core/
│   │   └── services/
│   │       └── product.service.ts
│   │
│   ├── features/
│   │   └── products/
│   │       ├── models/
│   │       ├── components/
│   │       │   └── product-card/
│   │       └── pages/
│   │           ├── product-list/
│   │           ├── product-form/
│   │           └── product-detail/
│   │
│   ├── app.routes.ts
│   └── app.config.ts
│
backend/
```

---

## 🛠️ Tecnologias Utilizadas

### Frontend

* Angular 21 (Standalone Components)
* Angular Material
* RxJS
* TypeScript
* SCSS

### Backend

* .NET 8
* Entity Framework Core (InMemory)
* REST API

---

## ⚙️ Pré-requisitos

* Node.js 18+
* Angular CLI 21+
* .NET SDK 8+

---

## ▶️ Como Executar o Projeto

### 🔹 1. Backend (.NET)

```bash
cd backend
dotnet run
```

A API estará disponível em:

```bash
https://localhost:7092/api/products
```

---

### 🔹 2. Frontend (Angular)

```bash
cd frontend
npm install
ng serve -o
```

A aplicação abrirá em:

```bash
http://localhost:4200
```

---

## 🔗 Integração com API

O frontend consome a API através do serviço:

```ts
private api = 'https://localhost:7092/api/products';
```

## 🔐 HTTPS (Desenvolvimento)

Se houver erro de certificado:

```bash
dotnet dev-certs https --trust
```

---

## 🎨 UI / UX

* Layout responsivo com **Angular Material**
* Cards com imagens padronizadas
* Hover effects e feedback visual
* Formulários com validação básica

---

## 📄 Licença

Este projeto é livre para testes.

---

## 👨‍💻 Autor

Desenvolvido por **Alison Nunes Silva**

