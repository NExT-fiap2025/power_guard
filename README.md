# ⚡ PowerGuard – Microserviço de Análise de Falhas Elétricas

### Projeto para a disciplina de **C# Software Development – GS 2025 (FIAP)**

| nome          | rm     |
| ------------- | ------ |
| Gustavo Lopes | 98887  |
| Eduardo Gomes | 97919  |
| Enzo Cunha    | 550985 |

## 📌 Descrição do Problema

Falhas de energia causadas por chuvas intensas, ventos e deslizamentos afetam sistemas críticos como hospitais, transporte, semáforos e redes elétricas. Em muitos casos, essas falhas também expõem sistemas digitais a **vulnerabilidades cibernéticas**. O PowerGuard é uma API que coleta eventos, aplica regras automáticas e fornece dados úteis para resposta rápida e análise estratégica.

---

## 🎯 Objetivo da Solução

Desenvolver um **microserviço RESTful** com:

- Registro de eventos de falha elétrica
- Regras inteligentes para recomendações automáticas
- Relatórios agregados por localização
- Validações com `try-catch` e tratamento de entradas inválidas
- Persistência via SQLite

---

### 📐 Requisitos Atendidos

- ✅ Projeto C# com 5 funcionalidades reais
- ✅ Camadas separadas (Controller, Service, Model, Data)
- ✅ Validações com `try/catch`
- ✅ Recomendações baseadas em regras de negócio
- ✅ Código limpo, comentado e versionado

---

## ⚙ Tecnologias Utilizadas

- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core
- SQLite
- PowerShell / curl / Postman

---

## 🧾 Requisitos Detalhados

### ✅ Requisitos Funcionais (RF)

| Código | Descrição                                                                     |
| ------ | ----------------------------------------------------------------------------- |
| RF01   | Registrar eventos de falha elétrica (POST `/api/analytics/event`)             |
| RF02   | Validar entradas com regras claras (campos obrigatórios, datas válidas, etc.) |
| RF03   | Gerar recomendações com base nos dados recebidos                              |
| RF04   | Listar eventos registrados (GET `/api/analytics/events`)                      |
| RF05   | Gerar relatório agregado por localidade (GET `/api/analytics/summary`)        |

---

### 🚫 Requisitos Não Funcionais (RNF)

| Código | Descrição                                                    |
| ------ | ------------------------------------------------------------ |
| RNF01  | Desenvolvido com C# (.NET 8)                                 |
| RNF02  | Banco de dados local SQLite, leve e portátil                 |
| RNF03  | Organização em camadas (Controllers, Models, Services, Data) |
| RNF04  | Código limpo, padronizado, com nomes significativos          |
| RNF05  | Documentado com README e comandos claros para execução       |
| RNF06  | Testável via Postman ou linha de comando (`curl`)            |

---

### ⚙ Requisitos Técnicos (RT)

| Código | Descrição                                                                   |
| ------ | --------------------------------------------------------------------------- |
| RT01   | Usar `Entity Framework Core` para acesso a dados com migrations automáticas |
| RT02   | Configurar `DbContext` com SQLite                                           |
| RT03   | Implementar validações robustas com `try/catch`                             |
| RT04   | Criar um `RulesEngine.cs` separado para centralizar a lógica de negócio     |
| RT05   | Manter API RESTful usando `ASP.NET Core Web API` padrão                     |

---

### 🧠 Regras de Negócio (conectadas a requisitos)

| Regra | Descrição                                                                 | Requisitos Relacionados |
| ----- | ------------------------------------------------------------------------- | ----------------------- |
| RN01  | Duração > 90 min → gerar alerta de infraestrutura crítica                 | RF03, RT04              |
| RN02  | Causa contendo "chuva" → recomendação sobre drenagem urbana               | RF03, RT04              |
| RN03  | Impedir envio de duração ≤ 0, local vazio, data futura, causa curta       | RF02, RT03              |
| RN04  | Recomendações sempre calculadas pela `RulesEngine.cs` e não no controller | RT04, RF03              |

## ✅ Funcionalidades Implementadas

| #   | Funcionalidade                             | Rota REST                               |
| --- | ------------------------------------------ | --------------------------------------- |
| 1   | Registro de evento de falha elétrica       | `POST /api/analytics/event`             |
| 2   | Consulta de resumo por localidade          | `GET /api/analytics/summary`            |
| 3   | Listagem completa de eventos               | `GET /api/analytics/events`             |
| 4   | Geração de recomendações (sem salvar)      | `POST /api/analytics/recommendations`   |
| 5   | Validação de entrada e tratamento de erros | Integrado via `try/catch` no controller |
| 6   | Análise de duração média por localidade    | GET /api/analytics/avg-duration         |

---

## 🚀 Como Executar o Projeto (Windows / PowerShell)

### ✅ Pré-requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- PowerShell ou Terminal
- Visual Studio (opcional)

---

### 📦 1. Instalar o Entity Framework CLI

```powershell
dotnet tool install --global dotnet-ef
```

---

### 🛠 2. Aplicar a migration e criar o banco

```powershell
dotnet ef database update --project PowerGuard.csproj
```

---

### ▶️ 3. Executar o projeto

```powershell
dotnet run --project PowerGuard.csproj
```

Aplicação disponível em:

```
http://localhost:5085
```

---

## 🔬 Testando a API via PowerShell (ou Postman)

### 📤 Registro de evento:

```powershell
curl -X POST http://localhost:5085/api/analytics/event `
-H "Content-Type: application/json" `
-d '{"location":"Centro","timestamp":"2025-06-06T15:00:00","durationMinutes":120,"cause":"Chuva forte","damage":"Transformador queimado"}'
```

---

### 📊 Consulta de resumo:

```powershell
curl http://localhost:5085/api/analytics/summary
```

---

### 💡 Geração de recomendação (sem salvar):

```powershell
curl -X POST http://localhost:5085/api/analytics/recommendations `
-H "Content-Type: application/json" `
-d '{"location":"Bairro B","timestamp":"2025-06-06T16:00:00","durationMinutes":100,"cause":"Vento","damage":"Poste danificado"}'
```

## 📢 Conclusão

O PowerGuard é uma solução realista e escalável para monitorar, entender e agir sobre falhas elétricas em cenários críticos. Oferece inteligência de decisão local, mesmo com infraestrutura limitada, agregando valor ao gerenciamento de crises energéticas.

---
