# TODO - Casos de Uso da Imobiliária

## Análise Concluída
- [x] Ler modelos de domínio (21 entidades)
- [x] Ler interfaces de repositório (CRUD genérico)
- [x] Ler use case existente (FuncionarioUseCase)
- [x] Ler controladores e Program.cs
- [x] Ler Contrato.cs (DI)

## Implementação

### 1. ClienteUseCase
- [ ] DTOs (CadastrarClienteDTO, LoginClienteDTO, ActualizarClienteDTO, ClienteDTO)
- [ ] Command: CadastrarCliente
- [ ] Command: LoginCliente
- [ ] Command: ActualizarCliente
- [ ] Command: AlterarSenhaCliente
- [ ] Command: RecuperarSenhaCliente
- [ ] Query: PesquisarClientePorId
- [ ] Query: PesquisarClientePorTelefone
- [ ] Query: PesquisarTodosClientes

### 2. ImovelUseCase
- [ ] DTOs (CadastrarImovelDTO, ActualizarImovelDTO, ImovelDTO)
- [ ] Command: CadastrarImovel
- [ ] Command: ActualizarImovel
- [ ] Command: DesativarImovel
- [ ] Command: ActivarImovel
- [ ] Query: PesquisarImovelPorId
- [ ] Query: PesquisarImoveisDisponiveis
- [ ] Query: PesquisarImoveisPorBairro
- [ ] Query: PesquisarImoveisPorPreco
- [ ] Query: PesquisarImoveisPorTipo

### 3. FotoVideoUseCase
- [ ] Command: CadastrarFotoImovel
- [ ] Command: CadastrarVideoImovel
- [ ] Command: RemoverFotoImovel
- [ ] Command: RemoverVideoImovel

### 4. FavoritoUseCase
- [ ] DTOs (AdicionarFavoritoDTO)
- [ ] Command: AdicionarFavorito
- [ ] Command: RemoverFavorito
- [ ] Query: ListarFavoritosDoCliente

### 5. SolicitacaoUseCase
- [ ] DTOs (CadastrarSolicitacaoDTO, ActualizarEstadoSolicitacaoDTO)
- [ ] Command: CadastrarSolicitacao
- [ ] Command: ActualizarEstadoSolicitacao
- [ ] Query: PesquisarSolicitacaoPorId
- [ ] Query: PesquisarSolicitacoesDoCliente
- [ ] Query: PesquisarSolicitacoesDoImovel
- [ ] Query: PesquisarTodasSolicitacoes

### 6. ProprietarioUseCase
- [ ] DTOs (CadastrarProprietarioDTO, ActualizarProprietarioDTO)
- [ ] Command: CadastrarProprietario
- [ ] Command: ActualizarProprietario
- [ ] Query: PesquisarProprietarioPorId
- [ ] Query: PesquisarTodosProprietarios

### 7. LocalizacaoUseCase
- [ ] Command: CadastrarProvincia
- [ ] Command: CadastrarMunicipio
- [ ] Command: CadastrarBairro
- [ ] Command: CadastrarEnderecoDoImovel
- [ ] Query: PesquisarTodasProvincias
- [ ] Query: PesquisarMunicipiosPorProvincia
- [ ] Query: PesquisarBairrosPorMunicipio

### 8. TipoImovelUseCase & TipologiaUseCase
- [ ] Command: CadastrarTipoImovel
- [ ] Command: CadastrarTipologia
- [ ] Query: PesquisarTodosTiposImovel
- [ ] Query: PesquisarTodasTipologias

### 9. FuncionarioUseCase (Complementar)
- [ ] Command: ActualizarFuncionario
- [ ] Command: AlterarSenhaFuncionario
- [ ] Command: DesativarFuncionario
- [ ] Query: PesquisarFuncionarioPorId
- [ ] Query: PesquisarTodosFuncionarios

### 10. Ajustes Gerais
- [ ] Corrigir namespaces inconsistentes nos repositórios
- [ ] Actualizar Program.cs com novos DI
- [ ] Actualizar Controladores (ClienteController, CorretoraController)
- [ ] Build e teste

