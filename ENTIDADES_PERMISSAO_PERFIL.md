
# Documentação - Entidades: tb01_Permissão e tb02_Perfil

## 📋 Resumo

Este documento descreve as entidades **tb01_Permissão** e **tb02_Perfil**, suas propriedades, relações e configurações no banco de dados.

---

## 1️⃣ Entidade tb01_Permissão (tb01_permissaoModel)

### Descrição
Define as permissões disponíveis no sistema (ex: "Cadastrar Funcionário", "Editar Cliente", etc).

### Localização
`C01.Domain/tb01_permissao.cs`

### Propriedades

| Propriedade | Tipo | Banco de Dados | Descrição | Obrigatório |
|---|---|---|---|---|
| `id` | `int` | `id` (PK) | Identificador único | ✅ Sim |
| `Descricao` | `string` | `descricao` | Descrição da permissão (3-150 caracteres) | ✅ Sim |
| `DataCriacao` | `DateTime` | `DataCriacao` | Data de criação (padrão: UtcNow) | ✅ Sim |
| `DataAtualizacao` | `DateTime?` | `DataAtualizacao` | Data da última atualização | ❌ Não |
| `Estado` | `bool` | `Estado` | Indica se a permissão está ativa | ✅ Sim (padrão: true) |

### Relacionamentos

```
┌─────────────────────┐
│  tb01_Permissão     │
├─────────────────────┤
│ id (PK)             │
│ descricao           │
│ DataCriacao         │
│ DataAtualizacao     │
│ Estado              │
└─────────────────────┘
          │
          │ Muitos-para-Muitos
          ↓
┌─────────────────────┐
│tb03_PerfilPermissão │
├─────────────────────┤
│ id (PK)             │
│ IdPermissão (FK)    │◄─ tb01_Permissão
│ IdPerfil (FK)       │◄─ tb02_Perfil
│ Estado              │
│ DataCriacao         │
│ DataAtualizacao     │
└─────────────────────┘
```

- **Muitos-para-Muitos com tb02_Perfil** através de `tb03_perfiL_permissaoModel`
  - Configuração: `HasOne().WithMany(p => p.PerfilPermissao).HasForeignKey()`
  - DeleteBehavior: `Cascade`
  - Constraint: `FK_PerfilPermissao_Permissao`

### Propriedade de Navegação

```csharp
public ICollection<tb03_perfiL_permissaoModel> PerfilPermissao { get; set; } = [];
```

---

## 2️⃣ Entidade tb02_Perfil (tb02_perfilModel)

### Descrição
Define os perfis de usuário do sistema (ex: Admin, Corretor, Cliente).
Cada perfil possui um conjunto de permissões associadas.

### Localização
`C01.Domain/tb02_perfilModel.cs`

### Propriedades

| Propriedade | Tipo | Banco de Dados | Descrição | Obrigatório |
|---|---|---|---|---|
| `id` | `int` | `id` (PK) | Identificador único | ✅ Sim |
| `Descricao` | `string` | `descricao` | Nome do perfil (3-100 caracteres) | ✅ Sim |
| `DataCriacao` | `DateTime` | `DataCriacao` | Data de criação (padrão: UtcNow) | ✅ Sim |
| `DataAtualizacao` | `DateTime?` | `DataAtualizacao` | Data da última atualização | ❌ Não |
| `Estado` | `bool` | `Estado` | Indica se o perfil está ativo | ✅ Sim (padrão: true) |

### Relacionamentos

```
┌─────────────────────┐
│    tb02_Perfil      │
├─────────────────────┤
│ id (PK)             │
│ descricao           │
│ DataCriacao         │
│ DataAtualizacao     │
│ Estado              │
└─────────────────────┘
    │         │         │
    │         │         └─► Um-para-Muitos ──► tb06_Cliente
    │         │
    │         └─► Um-para-Muitos ──► tb04_Funcionário
    │
    └─► Muitos-para-Muitos ──► tb01_Permissão
```

#### 2.1 - Muitos-para-Muitos com tb01_Permissão
- **Tabela de Junção**: `tb03_perfiL_permissaoModel`
- **Propriedade de Navegação**: `PerfilPermissao`
- **Configuração**: `HasOne().WithMany(p => p.PerfilPermissao).HasForeignKey()`
- **DeleteBehavior**: `Cascade`
- **Constraint**: `FK_PerfilPermissao_Perfil`

#### 2.2 - Um-para-Muitos com tb04_Funcionário
- **Propriedade de Navegação**: `Funcionarios`
- **Chave Estrangeira em Funcionário**: `Idtb02_perfilModel`
- **Configuração**: `HasOne(e => e.Perfil).WithMany(p => p.Funcionarios).HasForeignKey()`
- **DeleteBehavior**: `Restrict` (não permite deletar perfil com funcionários)
- **Constraint**: `FK_Funcionario_Perfil`

#### 2.3 - Um-para-Muitos com tb06_Cliente
- **Propriedade de Navegação**: `Clientes`
- **Chave Estrangeira em Cliente**: `Idtb02_perfilModel`
- **Configuração**: `HasOne(e => e.Perfil).WithMany(p => p.Clientes).HasForeignKey()`
- **DeleteBehavior**: `Restrict` (não permite deletar perfil com clientes)
- **Constraint**: `FK_Cliente_Perfil`

### Propriedades de Navegação

```csharp
public ICollection<tb03_perfiL_permissaoModel> PerfilPermissao { get; set; } = [];
public ICollection<tb04_funcionarioModel> Funcionarios { get; set; } = [];
public ICollection<tb06_clienteModel> Clientes { get; set; } = [];
```

---

## 3️⃣ Entidade tb03_PerfilPermissão (tb03_perfiL_permissaoModel)

### Descrição
Tabela de junção que relaciona Perfis e Permissões em uma relação Muitos-para-Muitos.
Permite que cada perfil tenha múltiplas permissões e cada permissão possa ser atribuída a múltiplos perfis.

### Localização
`C01.Domain/tb03_perfiL_permissaoModel.cs`

### Propriedades

| Propriedade | Tipo | Banco de Dados | Descrição | Obrigatório |
|---|---|---|---|---|
| `id` | `int` | `id` (PK) | Identificador único | ✅ Sim |
| `Idtb02_perfilModel` | `int` | `IdPerfil` (FK) | Referência para tb02_Perfil | ✅ Sim |
| `Idtb01_permissaoModel` | `int` | `IdPermissao` (FK) | Referência para tb01_Permissão | ✅ Sim |
| `Estado` | `bool` | `Estado` | Indica se a associação está ativa | ✅ Sim |
| `DataCriacao` | `DateTime` | `DataCriacao` | Data de criação | ✅ Sim |
| `DataAtualizacao` | `DateTime?` | `DataAtualizacao` | Data da última atualização | ❌ Não |

### Relacionamentos

- **Muitos-para-Um com tb01_Permissão**
  - Propriedade: `Permissao`
  - FK: `Idtb01_permissaoModel`
  - DeleteBehavior: `Cascade`

- **Muitos-para-Um com tb02_Perfil**
  - Propriedade: `Perfil`
  - FK: `Idtb02_perfilModel`
  - DeleteBehavior: `Cascade`

### Propriedades de Navegação

```csharp
public tb01_permissaoModel Permissao { get; set; } = null!;
public tb02_perfilModel Perfil { get; set; } = null!;
```

---

## 🔗 Configurações no DbContext

### Arquivo
`C03.Infra/Data/CorretoraDbContext.cs`

### Configuração da Relação Muitos-para-Muitos (Permissão ↔ Perfil)

```csharp
modelBuilder.Entity<tb03_perfiL_permissaoModel>(entity =>
{
    entity.HasKey(e => e.id);

    entity.HasOne(e => e.Permissao)
        .WithMany(p => p.PerfilPermissao)
        .HasForeignKey(e => e.Idtb01_permissaoModel)
        .OnDelete(DeleteBehavior.Cascade)
        .HasConstraintName("FK_PerfilPermissao_Permissao");

    entity.HasOne(e => e.Perfil)
        .WithMany(p => p.PerfilPermissao)
        .HasForeignKey(e => e.Idtb02_perfilModel)
        .OnDelete(DeleteBehavior.Cascade)
        .HasConstraintName("FK_PerfilPermissao_Perfil");
});
```

### Configuração da Relação Um-para-Muitos (Perfil → Funcionário)

```csharp
modelBuilder.Entity<tb04_funcionarioModel>(entity =>
{
    entity.HasOne(e => e.Perfil)
        .WithMany(p => p.Funcionarios)
        .HasForeignKey(e => e.Idtb02_perfilModel)
        .OnDelete(DeleteBehavior.Restrict)
        .HasConstraintName("FK_Funcionario_Perfil");
});
```

### Configuração da Relação Um-para-Muitos (Perfil → Cliente)

```csharp
modelBuilder.Entity<tb06_clienteModel>(entity =>
{
    entity.HasOne(e => e.Perfil)
        .WithMany(p => p.Clientes)
        .HasForeignKey(e => e.Idtb02_perfilModel)
        .OnDelete(DeleteBehavior.Restrict)
        .HasConstraintName("FK_Cliente_Perfil");
});
```

---

## 📊 Dados de Inicialização (Seed Data)

### Permissões Predefinidas

```csharp
modelBuilder.Entity<tb01_permissaoModel>().HasData(
    new tb01_permissaoModel { id = 1, Descricao = "Cadastrar Funcionário" },
    new tb01_permissaoModel { id = 2, Descricao = "Editar Funcionário" },
    new tb01_permissaoModel { id = 3, Descricao = "Desativar Funcionário" },
    new tb01_permissaoModel { id = 4, Descricao = "Listar Funcionários" },
    new tb01_permissaoModel { id = 5, Descricao = "Cadastrar Cliente" },
    new tb01_permissaoModel { id = 6, Descricao = "Editar Cliente" },
    new tb01_permissaoModel { id = 7, Descricao = "Listar Clientes" },
    new tb01_permissaoModel { id = 8, Descricao = "Cadastrar Imóvel" },
    new tb01_permissaoModel { id = 9, Descricao = "Editar Imóvel" },
    new tb01_permissaoModel { id = 10, Descricao = "Desativar Imóvel" },
    new tb01_permissaoModel { id = 11, Descricao = "Listar Imóveis" }
);
```

### Perfis Predefinidos

```csharp
modelBuilder.Entity<tb02_perfilModel>().HasData(
    new tb02_perfilModel { id = 1, Descricao = "Admin" },
    new tb02_perfilModel { id = 2, Descricao = "Corretor" },
    new tb02_perfilModel { id = 3, Descricao = "Cliente" }
);
```

### Associações Perfil-Permissão

- **Admin** (id = 1): Todas as 11 permissões
- **Corretor** (id = 2): Permissões 5-11 (Cliente e Imóvel)
- **Cliente** (id = 3): Sem permissões predefinidas

---

## 🔄 Fluxo de Uso

### 1. Atribuir Permissão a um Perfil

```csharp
var perfilPermissao = new tb03_perfiL_permissaoModel
{
    Idtb02_perfilModel = 2, // ID do Perfil (Corretor)
    Idtb01_permissaoModel = 5, // ID da Permissão (Cadastrar Cliente)
    Estado = true,
    DataCriacao = DateTime.UtcNow
};

await context.Tabela03PerfilPermissao.AddAsync(perfilPermissao);
await context.SaveChangesAsync();
```

### 2. Obter Permissões de um Perfil

```csharp
var permissoesDoCorretor = await context.Tabela03PerfilPermissao
    .Where(pp => pp.Idtb02_perfilModel == 2)
    .Include(pp => pp.Permissao)
    .ToListAsync();
```

### 3. Criar um Funcionário com Perfil

```csharp
var funcionario = new tb04_funcionarioModel
{
    Nome = "João Silva",
    Numero = "001",
    Idtb02_perfilModel = 2, // Perfil de Corretor
    Estado = true
};

await context.Tabela04Funcinario.AddAsync(funcionario);
await context.SaveChangesAsync();
```

### 4. Criar um Cliente com Perfil

```csharp
var cliente = new tb06_clienteModel
{
    Nome = "Maria Santos",
    Idtb02_perfilModel = 3, // Perfil de Cliente
    Estado = true
};

await context.Tabela06Cliente.AddAsync(cliente);
await context.SaveChangesAsync();
```

---

## ✅ Checklist de Implementação

- ✅ **tb01_permissaoModel** criada com propriedades de auditoria
- ✅ **tb02_perfilModel** criada com propriedades de auditoria
- ✅ **tb03_perfiL_permissaoModel** (tabela de junção) criada
- ✅ Relacionamento **Muitos-para-Muitos** entre Permissão e Perfil
- ✅ Relacionamento **Um-para-Muitos** entre Perfil e Funcionário
- ✅ Relacionamento **Um-para-Muitos** entre Perfil e Cliente
- ✅ Configurações Fluent API no DbContext
- ✅ Dados de inicialização (Seed Data) configurados
- ✅ Constraints de chave estrangeira definidas
- ✅ DeleteBehavior apropriado configurado

---

## 📝 Notas Importantes

1. **DeleteBehavior**: 
   - `Cascade` em PerfilPermissão: Ao deletar um perfil ou permissão, todas as associações são deletadas
   - `Restrict` em Funcionário e Cliente: Impede deletar um perfil que possui funcionários ou clientes associados

2. **DataCriacao e DataAtualizacao**: Adicionadas para auditoria. Use `DateTime.UtcNow` para sempre manter em UTC

3. **Estado**: Propriedade booleana para soft-delete lógico, permitindo desativar sem remover do banco

4. **Validação**: Propriedades com `[Required]` e `[StringLength]` para validação automática

5. **Nomeação de Foreign Keys**: Mantém consistência com nomenclatura da tabela (ex: `Idtb02_perfilModel`)

