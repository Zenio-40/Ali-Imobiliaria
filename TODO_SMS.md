# TODO - Implementação do Serviço de SMS

## Passos

- [x] 1. Criar interface `ISmsService` em `C02.Aplication/Servico/ISmsService/ISmsService.cs`
- [x] 2. Criar implementação `SmsService` em `C02.Aplication/Servico/SmsService.cs`
- [x] 3. Corrigir injeção de `ISmsService` no construtor de `CadastrarFuncionario.cs`
- [x] 4. Verificar conexão com API "POST https://sms.gsaplatform.co/enviar/sms"

## Resultado

Build falha devido a erro **pré-existente** `IJwtService` em `LoginCommand.cs` (não foi introduzido por SMS).

---

## 🧪 Como Testar o Envio de SMS

### Opção 1: Via Cadastro de Funcionário (já implementado)
POST `/api/funcionario` com body:
```json
{
  "funcionarioNome": "Carlos",
  "funcionarioTelefone": "923000000",
  "funcionarioIdPerfil": 1
}
```
→ Se o funcionário for criado com sucesso (código 201), o sistema chama automaticamente:
```
POST https://sms.gsaplatform.co/enviar/sms
Body: {
  "mensagem": [{"telefone":"923000000","mensagemTexto":"Bem-vindo..."}],
  "nif": "5101090688"
}
```

### Opção 2: Simular sem gastar SMS
Alterar em `appsettings.json`:
```json
  "Sms": {
    "Nif": "5101090688",
    "SimularEnvio": true
  }
```
→ O sistema vai logar no console `"[SIMULAÇÃO] SMS para 923000000: ..."` em vez de chamar a API real.



