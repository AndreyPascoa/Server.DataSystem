# Servidor - API de Tarefas

Este é o backend do projeto de gerenciamento de tarefas, desenvolvido em **.NET Core**.

---

## Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/en-us/download) v7+
* SQL Server

---

## Configuração e execução

### 1. Clonar o repositório

```bash
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio/Servidor
```

### 2. Configurar a string de conexão

No arquivo `appsettings.json`, configure sua conexão com o banco de dados:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MEI_DAN;Trusted_Connection=True;"
}
```

### 3. Restaurar pacotes e atualizar o banco

```bash
dotnet restore
dotnet ef database update
```

### 4. Executar o servidor

```bash
dotnet run
```

O servidor estará disponível em `https://localhost:5121` ou na porta configurada.

---

## Testes

Para executar testes (caso existam):

```bash
dotnet test
```

---

## Observações

* Use o **Insomnia** ou **Postman** para testar os endpoints da API.
* Modelo de tabelas usado como no exeplo SQL/database.sql 
* Certifique-se de que o banco de dados contém a tabela `Status` com os registros esperados:

| Id | Nome        |
| -- | ----------- |
| 1  | Pendente    |
| 2  | EmProgresso |
| 3  | Concluida   |

