# TODO - Casos de Uso da Imobiliária

## Análise Concluída
- [x] Ler modelos de domínio (21 entidades)
- [x] Ler interfaces de repositório (CRUD genérico)
- [x] Ler use case existente (FuncionarioUseCase)
- [x] Ler controladores e Program.cs
- [x] Ler Contrato.cs (DI)

## Implementação

### 1. ClienteUseCase
- [x] DTOs (CadastrarClienteDTO, ActualizarClienteDTO, ClienteDTO)
- [x] Command: CadastrarCliente
- [x] Command: ActualizarCliente
- [x] Query: PesquisarClientePorId
- [x] Query: PesquisarTodosClientes

### 2. ImovelUseCase
- [x] DTOs (CadastrarImovelDTO, ActualizarImovelDTO, ImovelDTO)
- [x] Command: CadastrarImovel
- [x] Command: ActualizarImovel
- [x] Command: DesativarImovel
- [x] Query: PesquisarImovelPorId
- [x] Query: PesquisarImoveisDisponiveis

### 4. FavoritoUseCase
- [x] DTOs (AdicionarFavoritoDTO)
- [x] Command: AdicionarFavorito
- [x] Command: RemoverFavorito
- [x] Query: ListarFavoritosDoCliente

### 5. SolicitacaoUseCase
- [x] DTOs (CadastrarSolicitacaoDTO, ActualizarEstadoSolicitacaoDTO, SolicitacaoDTO)
- [x] Command: CadastrarSolicitacao
- [x] Command: ActualizarEstadoSolicitacao
- [x] Query: PesquisarSolicitacaoPorId
- [x] Query: PesquisarSolicitacoesDoCliente

### 6. ProprietarioUseCase
- [x] DTOs (CadastrarProprietarioDTO, ActualizarProprietarioDTO, ProprietarioDTO)
- [x] Command: CadastrarProprietario
- [x] Command: ActualizarProprietario
- [x] Query: PesquisarProprietarioPorId
- [x] Query: PesquisarTodosProprietarios

### 9. FuncionarioUseCase (Complementar)
- [x] Command: ActualizarFuncionario
- [x] Command: DesativarFuncionario
- [x] Query: PesquisarFuncionarioPorId
- [x] Query: PesquisarTodosFuncionarios

### Controladores
- [x] AuthController (login)
- [x] AdminController (CRUD funcionários + proteção [Authorize])
- [x] ClienteController (clientes + favoritos + imóveis disponíveis)
- [x] ImovelController (CRUD imóveis)
- [x] ProprietarioController (CRUD proprietários)
- [x] SolicitacaoController (solicitações + estados)
- [x] CorretoraController (dashboard com estatísticas reais)

### 10. Ajustes Gerais
- [x] Actualizar Program.cs com novos DI
- [x] Build e teste

## Pendências Futuras
- [ ] Adicionar `.Include()` nos repositórios de infra para carregar dados relacionados
- [ ] Implementar filtro de imóveis por preço, bairro, tipo
- [ ] Adicionar upload de fotos/vídeos para imóveis
- [ ] Criar testes unitários
