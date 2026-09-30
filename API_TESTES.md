# Guia rápido de testes da API

## 1. Como entrar no projeto

No terminal, entre na pasta da solução:

```powershell
cd caminho\para\MobiGest
```

## 2. Restaurar dependências

```powershell
dotnet restore
```

## 3. Compilar

```powershell
dotnet build
```

## 4. Executar

```powershell
dotnet run --project .\MobiGest.Api
```

Confira no terminal a porta HTTP ou HTTPS informada pelo `dotnet run`. Nos exemplos abaixo, substitua `URL_BASE` pela URL apresentada, por exemplo `http://localhost:5000`.

Os dados ficam armazenados em memória e são perdidos quando a aplicação é encerrada.

## 5. Estrutura das principais rotas

O model `Movel` possui as propriedades `id`, `nome`, `descricao`, `preco`, `estoque` e `categoria`. O `id` é gerado pela API no cadastro. `categoria` é um número do enum `TiposCategoria`: `0` Mesa, `1` Cadeira, `2` Armario ou `3` Planejado.

### GET todos os móveis

**GET** `URL_BASE/api/moveis`

Lista todos os móveis cadastrados. Não possui parâmetros de rota, query ou body.

Resposta `200 OK`:

```json
[
  {
    "id": 1,
    "nome": "Sofá 3 Lugares",
    "descricao": "Sofá cinza",
    "preco": 1899.90,
    "estoque": 5,
    "categoria": 2
  }
]
```

### GET móvel por ID

**GET** `URL_BASE/api/moveis/1`

O parâmetro de rota `id` identifica o móvel; neste exemplo, `1` é o ID. Não possui body.

Resposta `200 OK`:

```json
{
  "id": 1,
  "nome": "Sofá 3 Lugares",
  "descricao": "Sofá cinza",
  "preco": 1899.90,
  "estoque": 5,
  "categoria": 2
}
```

Possível erro: `404 Not Found` se o ID não existir.

### Criar móvel

**POST** `URL_BASE/api/moveis`

Não possui parâmetros de rota ou query. Envie no body JSON as propriedades `nome`, `descricao`, `preco`, `estoque` e `categoria`; não é necessário enviar `id`.

```json
{
  "nome": "Sofá 3 Lugares",
  "descricao": "Sofá cinza",
  "preco": 1899.90,
  "estoque": 5,
  "categoria": 2
}
```

Resposta `201 Created`:

```json
{
  "id": 1,
  "nome": "Sofá 3 Lugares",
  "descricao": "Sofá cinza",
  "preco": 1899.90,
  "estoque": 5,
  "categoria": 2
}
```

Possível erro: `400 Bad Request` se `nome` estiver vazio, `preco` não for maior que zero ou `estoque` for negativo.

### Atualizar móvel

**PUT** `URL_BASE/api/moveis/1`

O parâmetro `id` vem na URL e não precisa ser duplicado no JSON. Envie o objeto completo no body:

```json
{
  "nome": "Sofá 3 Lugares Premium",
  "descricao": "Sofá cinza atualizado",
  "preco": 2099.90,
  "estoque": 7,
  "categoria": 2
}
```

Resposta `200 OK` com o móvel atualizado. Possíveis erros: `400 Bad Request` para dados inválidos e `404 Not Found` se o ID não existir.

### Deletar móvel

**DELETE** `URL_BASE/api/moveis/1`

O parâmetro `id` vem na URL. Não envie body.

Resposta `204 No Content` quando o móvel é removido. Possível erro: `404 Not Found` se o ID não existir.

## 6. Teste pelo Insomnia

1. Crie uma requisição `GET` para `URL_BASE/api/moveis` e execute para listar os móveis.
2. Crie uma requisição `POST` para `URL_BASE/api/moveis`. Selecione **Body > JSON**, informe o JSON de criação e execute.
3. Crie uma requisição `PUT` para `URL_BASE/api/moveis/1`. Selecione **Body > JSON**, informe o JSON de atualização e execute.
4. Crie uma requisição `DELETE` para `URL_BASE/api/moveis/1`. Não adicione body e execute.

## 7. Teste pelo Swagger/OpenAPI

Este projeto possui OpenAPI integrado. Em ambiente de desenvolvimento, acesse `URL_BASE/openapi/v1.json`, usando a porta apresentada pelo `dotnet run`. O projeto não inclui uma interface visual Swagger; o arquivo OpenAPI pode ser usado em ferramentas compatíveis.

## 8. Exemplos com curl

Substitua `URL_BASE` pela URL exibida no terminal:

```powershell
curl.exe URL_BASE/api/moveis

curl.exe -X POST URL_BASE/api/moveis -H "Content-Type: application/json" -d '{"nome":"Sofá 3 Lugares","descricao":"Sofá cinza","preco":1899.90,"estoque":5,"categoria":2}'

curl.exe -X PUT URL_BASE/api/moveis/1 -H "Content-Type: application/json" -d '{"nome":"Sofá 3 Lugares Premium","descricao":"Sofá cinza atualizado","preco":2099.90,"estoque":7,"categoria":2}'

curl.exe -X DELETE URL_BASE/api/moveis/1
```