# 📱 Configuração do Provedor de SMS - Guia de Uso

## ✅ Status Atual
A API está **totalmente funcional** com o provedor de SMS real (GSA Platform).

---

## 🔧 Configuração Atual

O arquivo `appsettings.json` está configurado com:

```json
"Sms": {
    "Nif": "5101090688",
    "SimularEnvio": false,
    "ProviderUrl": "https://sms.gsaplatform.co"
}
```

**Credenciais de Acesso:**
- **NIF**: 5101090688
- **Provedor**: GSA Platform (https://sms.gsaplatform.co)
- **Endpoint**: `POST /enviar/sms`

---

## 🚀 Como Testar

### Opção 1: Envio Real de SMS (Produção)

Deixar `"SimularEnvio": false` no `appsettings.json`

**Via Cadastro de Funcionário:**
```bash
POST http://localhost:5190/api/admin/funcionarios
Content-Type: application/json

{
    "funcionarioNome": "Carlos Silva",
    "funcionarioTelefone": "923000000",
    "funcionarioIdPerfil": 1
}
```

**Resultado esperado:**
- Código HTTP: `201 Created`
- SMS enviado para `923000000` com a senha gerada
- Mensagem: `"Bem-vindo à Ali Imobiliária! Suas credenciais de acesso: Telefone: 923000000 | Senha: [SENHA_GERADA]"`

---

### Opção 2: Teste Local (Simulação)

Para testar **sem gastar créditos de SMS**, altere no `appsettings.json`:

```json
"Sms": {
    "Nif": "5101090688",
    "SimularEnvio": true,
    "ProviderUrl": "https://sms.gsaplatform.co"
}
```

**O sistema irá:**
- Logar no console: `[SIMULAÇÃO] SMS para 923000000: Bem-vindo à Ali Imobiliária!...`
- Retornar sucesso sem chamar a API real
- Permitir testar todo o fluxo de cadastro

---

## 📊 Resposta da API

### Sucesso (201 Created)
```json
{
    "dados": null,
    "mensagem": "Funcionário cadastrado com sucesso!",
    "codigo": 201
}
```

O SMS foi enviado automaticamente para o número registrado.

### Erro na Requisição
Se houver erro de validação:
```json
{
    "dados": null,
    "mensagem": "Telefone é obrigatório",
    "codigo": 400
}
```

### Erro no Envio de SMS
Se o SMS falhar, você verá nos logs:
```
[Warn] Falha ao enviar SMS para 923000000. Status: 400. Resposta: [detalhes_erro]
```

---

## 🔐 Segurança & Produção

### Antes de Usar em Produção:

1. ✅ Verificar credenciais reais do NIF
2. ✅ Testar com número de teste primeiro
3. ✅ Monitorar logs de SMS enviados
4. ✅ Configurar limites de taxa (rate limiting)
5. ✅ Validar formato de telefone (ex: +244923000000)

---

## 🛠️ Resolução de Problemas

### SMS não está sendo enviado

**Verificar:**
1. `SimularEnvio` está `false`? ✓
2. URL do provedor está correta? ✓ (https://sms.gsaplatform.co)
3. NIF está correto? ✓ (5101090688)
4. Número tem formato válido? (ex: 923000000)
5. Créditos disponíveis no provedor?

### Logs para Debugging

```bash
# Windows PowerShell
dotnet run

# Procure por:
# [Info] SMS enviado com sucesso para...
# [Warn] Falha ao enviar SMS para...
# [Error] Erro inesperado ao enviar SMS para...
```

---

## 📝 Endpoints Relacionados

### Login com SMS
```bash
POST http://localhost:5190/api/auth/login/funcionario
Content-Type: application/json

{
    "telefone": "923000000",
    "senha": "[SENHA_RECEBIDA_POR_SMS]"
}
```

**Resposta:**
```json
{
    "token": "eyJhbGciOiJIUzI1NiIs...",
    "mensagem": "Login realizado com sucesso",
    "codigo": 200
}
```

---

## 💡 Próximas Melhorias

- [ ] Adicionar retry automático em caso de falha
- [ ] Suportar múltiplos provedores de SMS
- [ ] Template de mensagens customizáveis
- [ ] Histórico de SMS enviados (auditoria)
- [ ] Notificações por email como fallback

---

**Última atualização:** 29/04/2026  
**Status:** 🟢 Totalmente Funcional com Credenciais Reais
