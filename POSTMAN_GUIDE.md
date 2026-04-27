# Guia de Testes no Postman - API Ali Imobiliária

## Base URL
```
http://localhost:5190/api
```
ou
```
https://localhost:7135/api
```

---

## 1. Funcionário (Admin)

### Cadastrar Funcionário Admin Inicial
Use este endpoint para cadastrar o primeiro admin. O perfil ID 1 é Admin.
- **Método:** `POST`
- **URL:** `/admin/funcionarios`
- **Body (JSON):**
```json
{
    "funcionarioNome": "Admin Principal",
    "funcionarioTelefone": "923456789",
    "funcionarioIdPerfil": 1
}
```
- **Resposta esperada:** `201 Created` + mensagem SMS com senha (anote a senha para login)

### Cadastrar Funcionário
- **Método:** `POST`
- **URL:** `/admin/funcionarios`
- **Body (JSON):**
```json
{
    "funcionarioNome": "Zênio Carlos",
    "funcionarioTelefone": "923456789",
    "funcionarioIdPerfil": 1
}
```
- **Resposta esperada:** `201 Created` + mensagem SMS enviada com senha

### Listar Funcionários
- **Método:** `GET`
- **URL:** `/admin/funcionarios?pagina=1&quantidade=20`

### Obter Funcionário por ID
- **Método:** `GET`
- **URL:** `/admin/funcionarios/1`

### Actualizar Funcionário
- **Método:** `PUT`
- **URL:** `/admin/funcionarios`
- **Body (JSON):**
```json
{
    "id": 1,
    "funcionarioNome": "Zênio Carlos Actualizado",
    "funcionarioTelefone": "923456789",
    "funcionarioIdPerfil": 1,
    "estado": true
}
```

### Desativar Funcionário
- **Método:** `PATCH`
- **URL:** `/admin/funcionarios/1/desativar`

---

## 2. Autenticação (Login)

### Login Funcionário
- **Método:** `POST`
- **URL:** `/auth/login/funcionario`
- **Body (JSON):**
```json
{
    "telefone": "923456789",
    "senha": "SENHA_RECEBIDA_POR_SMS"
}
```
- **Resposta esperada:** `200 OK` com token JWT

---

## 3. Cliente

### Cadastrar Cliente
- **Método:** `POST`
- **URL:** `/cliente`
- **Body (JSON):**
```json
{
    "clienteNome": "Maria Silva",
    "clienteTelefone": "911222333",
    "clienteEmail": "maria@email.com",
    "clienteIdPerfil": 2
}
```

### Listar Clientes
- **Método:** `GET`
- **URL:** `/cliente?pagina=1&quantidade=20`

### Obter Cliente por ID
- **Método:** `GET`
- **URL:** `/cliente/1`

### Actualizar Cliente
- **Método:** `PUT`
- **URL:** `/cliente`
- **Body (JSON):**
```json
{
    "id": 1,
    "clienteNome": "Maria Silva Actualizada",
    "clienteTelefone": "911222333",
    "clienteEmail": "maria.nova@email.com",
    "clienteIdPerfil": 2,
    "estado": true
}
```

---

## 4. Imóvel

### Cadastrar Imóvel
- **Método:** `POST`
- **URL:** `/imovel`
- **Body (JSON):**
```json
{
    "funcionarioId": 1,
    "tipoImovelId": 1,
    "tipologiaId": 1,
    "proprietarioId": 1,
    "descricao": "Apartamento T3 no centro da cidade",
    "preco": 250000.00,
    "estado": true
}
```

### Listar Imóveis Disponíveis
- **Método:** `GET`
- **URL:** `/imovel/disponiveis?pagina=1&quantidade=20`

### Obter Imóvel por ID
- **Método:** `GET`
- **URL:** `/imovel/1`

### Actualizar Imóvel
- **Método:** `PUT`
- **URL:** `/imovel`
- **Body (JSON):**
```json
{
    "imovelId": 1,
    "funcionarioId": 1,
    "tipoImovelId": 1,
    "tipologiaId": 1,
    "proprietarioId": 1,
    "descricao": "Apartamento T3 renovado",
    "preco": 275000.00,
    "estado": true
}
```

### Desativar Imóvel
- **Método:** `PATCH`
- **URL:** `/imovel/1/desativar`

---

## 5. Proprietário

### Cadastrar Proprietário
- **Método:** `POST`
- **URL:** `/proprietario`
- **Body (JSON):**
```json
{
    "nome": "João Proprietário",
    "telefone": "933444555",
    "idTipoImovel": 1
}
```

### Listar Proprietários
- **Método:** `GET`
- **URL:** `/proprietario?pagina=1&quantidade=20`

### Obter Proprietário por ID
- **Método:** `GET`
- **URL:** `/proprietario/1`

### Actualizar Proprietário
- **Método:** `PUT`
- **URL:** `/proprietario`
- **Body (JSON):**
```json
{
    "id": 1,
    "nome": "João Proprietário Actualizado",
    "telefone": "933444555",
    "idTipoImovel": 1
}
```

---

## 6. Solicitação

### Cadastrar Solicitação
- **Método:** `POST`
- **URL:** `/solicitacao`
- **Body (JSON):**
```json
{
    "idCliente": 1,
    "idImovel": 1,
    "idEstadoSolicitacao": 1
}
```

### Actualizar Estado da Solicitação
- **Método:** `PUT`
- **URL:** `/solicitacao/estado`
- **Body (JSON):**
```json
{
    "idSolicitacao": 1,
    "idNovoEstado": 2
}
```

### Listar Solicitações por Cliente
- **Método:** `GET`
- **URL:** `/solicitacao/cliente/1?pagina=1&quantidade=20`

---

## 7. Favoritos

### Adicionar Favorito
- **Método:** `POST`
- **URL:** `/cliente/favorito`
- **Body (JSON):**
```json
{
    "clienteId": 1,
    "imovelId": 1
}
```

### Listar Favoritos do Cliente
- **Método:** `GET`
- **URL:** `/cliente/favoritos/1?pagina=1&quantidade=20`

### Remover Favorito
- **Método:** `DELETE`
- **URL:** `/cliente/favorito/1`

---

## 8. Dashboard (Corretora)

### Estatísticas
- **Método:** `GET`
- **URL:** `/corretora/dashboard`

### Listar Imóveis
- **Método:** `GET`
- **URL:** `/corretora/imoveis?pagina=1&quantidade=20`

### Listar Clientes
- **Método:** `GET`
- **URL:** `/corretora/clientes?pagina=1&quantidade=20`

### Listar Proprietários
- **Método:** `GET`
- **URL:** `/corretora/proprietarios?pagina=1&quantidade=20`

---

## Notas Importantes

1. **Cadastro de Funcionário:** Ao cadastrar um funcionário, uma senha é gerada automaticamente e enviada por SMS para o telefone informado.

2. **Login:** Use o telefone e a senha recebida por SMS para fazer login e obter o token JWT.

3. **Perfil ID:** 
   - `1` = Administrador
   - `2` = Cliente
   - Outros perfis conforme cadastrados na base de dados

4. **Base de Dados:** Certifique-se de que a base de dados PostgreSQL está configurada corretamente em `appsettings.json` com a connection string `ConexaoLocal`.
