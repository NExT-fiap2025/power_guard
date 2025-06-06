#  PowerGuard – Microserviço de Análise de Falhas Elétricas

### Projeto desenvolvido para a disciplina de **C# Software Development – GS 2025 (FIAP)**
👥 Integrantes

|nome | rm  |
| --- | --- |
| Gustavo  Lopes | 98887 | 
| Eduardo Gomes | 97919 | 
| Enzo Cunha  | 550985 | 

---

## 📌 Descrição do Problema

Falhas de energia elétrica causadas por eventos extremos (chuvas intensas, ventos, deslizamentos) colocam em risco infraestruturas críticas e expõem sistemas à **indisponibilidade e ameaças cibernéticas**. É essencial antecipar e registrar esses eventos para **análise preventiva e reativa**.

---

## 🎯 Objetivo do Projeto

Criar um **microserviço RESTful em C# (.NET 6)** com **SQLite** que:

- Registra eventos de falta de energia
- Aplica regras para gerar recomendações automáticas
- Fornece resumos estatísticos por região
- Simula entradas inválidas com `try-catch`
- Expõe API segura e bem estruturada

---

## ✅ Funcionalidades Implementadas

| # | Funcionalidade                                | Rota REST                           | Tipo   |
|---|-----------------------------------------------|-------------------------------------|--------|
| 1 | Registro de evento de falha elétrica          | `POST /api/analytics/event`         | Create |
| 2 | Consulta de resumo por localidade             | `GET /api/analytics/summary`        | Read   |
| 3 | Listagem completa de eventos                  | `GET /api/analytics/events`         | Read   |
| 4 | Geração de recomendações (sem salvar)         | `POST /api/analytics/recommendations` | Compute|
| 5 | Consulta de logs de eventos (opcional extra)  | `GET /api/analytics/logs`           | Read   |
| — | Login do usuário (obrigatório)                | `POST /api/auth/login`              | Auth   |

---

## ⚙ Tecnologias Utilizadas

- [x] .NET 6 (ASP.NET Core Web API)
- [x] Entity Framework Core
- [x] SQLite (banco de dados local)
- [x] LINQ para agregações
- [x] Visual Studio 2022+
- [x] Swagger ou Postman para testes
- [x] GitHub para versionamento

---

## 📐 Requisitos Atendidos

### Funcionais
- RF01 Registro e validação de eventos
- RF02 Regras de recomendação com base em dados
- RF03 Relatórios e resumos estatísticos
- RF04 Simulação de falhas via `try/catch`
- RF05 API RESTful acessível e testável

### Não Funcionais
- RNF01 Código limpo e comentado
- RNF02 Separação em camadas (MVC + Services)
- RNF03 Banco de dados leve e portável (SQLite)
- RNF04 Publicado no GitHub com documentação

### Técnicos
- RT01 Utiliza EF Core com SQLite
- RT02 Validação e tratamento de exceções robusto
- RT03 Recomendações encapsuladas em serviço (`RulesEngine.cs`)
- RT04 Retornos JSON bem formatados

---

## 📊 Regras de Negócio

| Regra | Descrição |
|-------|-----------|
| RN01 | Se a duração for > 90 minutos, alerta de infraestrutura crítica |
| RN02 | Se a causa incluir "chuva", recomendar inspeção de drenagem |
| RN03 | Não permitir duração <= 0, data futura, local vazio |
| RN04 | Recomendações sempre processadas via `RulesEngine.cs` |

---

## Como Executar Localmente

### Pré-requisitos

- Visual Studio 2022+ com .NET 6
- EF CLI: `dotnet tool install --global dotnet-ef`

### Passo a Passo

```bash
# Clone o repositório
git clone https://github.com/seuusuario/powerguard.git
cd powerguard

# Restaure os pacotes
dotnet restore

# Crie o banco SQLite e aplique as migrations
dotnet ef migrations add Init
dotnet ef database update

# Execute a API
dotnet run
```

```
http://localhost:5000/api/analytics/event
```

📢 Conclusão
O PowerGuard oferece uma base sólida para análise inteligente de falhas elétricas, promovendo resposta ágil, mitigação de impactos e segurança digital preventiva.
