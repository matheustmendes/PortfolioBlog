# 📝 PortfolioBlog — Simulador de Blog em C# (.NET Console App)

Este é um projeto de aprendizado com o objetivo de desenvolver um **blog pessoal com seção de portfólio**, inicialmente como **aplicação console em C#**, com planos de expansão para uma aplicação **web fullstack** utilizando **ASP.NET Core Web API** no backend e **Angular** no frontend.

---

## 🎯 Objetivo

Construir um sistema de blog pessoal com:
- Cadastro e gerenciamento de postagens
- Listagem e visualização de conteúdo
- Autores e metadados
- Seção de projetos para portfólio

### 🚧 Status atual

> ✅ Versão inicial funcionando como um **Console App** com:
- CRUD de posts em memória
- Organização em camadas: `Model`, `Service`, `Program`
- Menu interativo em terminal

---

## 🚀 Próximos passos (roadmap)

### 🔹 Fase 2 — Backend com ASP.NET Core
- [ ] Migrar lógica do `PostService` para Web API
- [ ] Criar endpoints RESTful para `Post`, `Project`, `User`
- [ ] Implementar persistência com Entity Framework Core
- [ ] Adicionar autenticação JWT para painel administrativo

### 🔹 Fase 3 — Frontend com Angular
- [ ] Criar interface SPA com Angular
- [ ] Páginas: Home, Sobre Mim, Portfólio, Login, Dashboard
- [ ] CRUD completo de posts e projetos via frontend
- [ ] Comunicação via `HttpClient` com a API

---

## 🧱 Estrutura atual

```bash
PortfolioBlog/
├── Models/
│   └── Post.cs
├── Services/
│   └── PostService.cs
├── Program.cs
