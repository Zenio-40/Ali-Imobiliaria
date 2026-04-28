# TODO - Análise e Melhorias do Projecto Ali Imobiliária

## 🔴 CRÍTICO - Bugs & Problemas de Compilação/Execução

- [ ] **1. Duplicação de `AddDbContext<CorretoraDbContext>` no `Program.cs`**
  - Primeira chamada configura `UseNpgsql(conexao)`
  - Segunda chamada `builder.Services.AddDbContext<CorretoraDbContext>()` sem configuração pode sobrescrever
  - **Solução:** Remover a segunda chamada

- [ ] **2. Migração vazia `20260427183406_Initial.cs`**
  - Métodos `Up()` e `Down()` estão vazios
  - Verificar se modelos mudaram e gerar nova migração

- [ ] **3. Inconsistência de tipos de retorno nos repositórios de pesquisa por ID**
  - Alguns retornam `(Model?, string, int)` (com mensagem e código)
  - Outros retornam `Model?` direto (ex: LoginRepositorio)
  - **Solução:** Padronizar todos para tupla `(Model?, string, int)`

## 🟠 ALTO - Segurança & Performance

- [ ] **4. `CadastrarFuncionario.cs` não usa os serviços de password injetados**
  - Possui métodos estáticos próprios: `GerarHash()`, `GerarSalt()`
  - Mas `IPasswordHash` e `IPasswordCreate` já estão registados no DI e implementados
  - **Solução:** Refactor para usar `IPasswordCreate` e `IPasswordHash` via DI

- [ ] **5. Duplicação de serviços de hashing**
  - `C02.Aplication/Servico/PasswordHashService.cs` (SHA256)
  - `C03.Infra/Servico/PasswordService/PasswordHashService.cs` (PBKDF2)
  - **Solução:** Consolidar num único serviço robusto (PBKDF2 é melhor)

- [ ] **6. Uso de `Random` não criptograficamente seguro para geração de senhas**
  - `new Random()` em `CadastrarFuncionario.GerarSenhaAleatoria()`
  - Deve usar `RandomNumberGenerator`

- [ ] **7. Hashing de password uses SHA256 simples em vez de PBKDF2/Argon2**
  - `PasswordHashService.cs` (em C02) usa SHA256 com salt simples
  - `PasswordVerifyService.cs` idem
  - BCrypt.Net-Next já está no projecto mas não está a ser usado

- [ ] **8. Vazamento de informação no login**
  - `LoginCommand` retorna mensagens diferentes para "usuário não encontrado" e "senha inválida"
  - Permite enumeração de usuários
  - **Solução:** Usar mensagem genérica: "Credenciais inválidas"

- [ ] **9. JWT `ValidateIssuer` e `ValidateAudience` desactivados**
  - `ValidateIssuer = false`, `ValidateAudience = false`
  - Aumenta risco de ataques com tokens de outras aplicações

- [ ] **10. Middleware de autenticação comentado**
  - `app.UseAuthentication()` e `app.UseAuthorization()` estão comentados
  - `[Authorize]` em controllers não terá efeito

## 🟡 MÉDIO - Arquitectura & Clean Code

- [ ] **11. `CadastrarFuncionario.cs` gera email mas não persiste na tabela `tb08_email`**
  - Email é gerado, retornado na resposta, mas nunca associado ao funcionário
  - O funcionário tem `ICollection<tb08_emailModel> Email` mas fica vazio

- [ ] **12. Nomes de DbSet com typos e inconsistências**
  - `Tabela04Funcinario` → deveria ser `Funcionario`
  - `Tabela17Enderco` → deveria ser `Endereco`
  - `Tabela14Pronvincia` → deveria ser `Provincia`
  - `Tabela09TipolaImovel` → deveria ser `TipoImovel`

- [ ] **13. Inconsistência na inicialização de coleções**
  - Algumas: `new List<>()`
  - Outras: `[]`
  - **Solução:** Padronizar para `[]` (collection expressions do C# 12)

- [ ] **14. Interfaces duplicadas com namespaces diferentes**
  - `IActualizarRepositorio` sem namespace vs `C01.Domain.Interfaces.IActualizarRepositorio`
  - **Solução:** Consolidar num namespace único

- [ ] **15. Vocabulário misto PT/EN em nomes de classes e métodos**
  - `Actualizar` (PT) vs `Update` (EN)
  - `Pesquisar` (PT) vs `Search` (EN)
  - `Cadastrar` (PT) vs `Create` (EN)

- [ ] **16. Retorno de DTOs em vez de ViewModels nos Use Cases**
  - `CadastrarImovel` retorna o próprio DTO de entrada
  - Deveria retornar um ViewModel com dados persistidos (incluindo ID gerado)

## 🟢 BAIXO - Qualidade & Manutenção

- [ ] **17. Falta de anotações `[ProducesResponseType]` nos Controllers**
  - Não documenta os códigos de resposta para Swagger/OpenAPI

- [ ] **18. Tratamento de excepções genérico nos repositórios**
  - `catch (DbUpdateException ex) { return (null, ex.ToString(), 500); }`
  - Retorna stack trace ao cliente (vazamento de informação interna)

- [ ] **19. `SimularEnvio` de SMS sempre `true` em produção?**
  - Configuração `Sms:SimularEnvio: true` pode impedir envios reais

- [ ] **20. Hardcoded `DateTime` nas seed data**
  - `new DateTime(2026, 4, 27, 0, 0, 0, DateTimeKind.Utc)` repetido muitas vezes
  - Considerar `DateTime.UtcNow` ou constante

