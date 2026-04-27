using Corretora.C01.Domain;
using Corretora.C02.Aplication.CasosUso.ImovelUseCase.DTOs;

namespace Corretora.C02.Aplication.CasosUso.ImovelUseCase.Command;

public class CadastrarImovel(
    Corretora.C01.Domain.Interfaces.IPesquisarPorIdRepositorio<tb09_tipo_imovelModel> pesquisarTipo,
    Corretora.C01.Domain.Interfaces.IPesquisarPorIdRepositorio<tb10_tipologiaModel> pesquisarTipologia,
    Corretora.C01.Domain.Interfaces.IPesquisarPorIdRepositorio<tb04_funcionarioModel> pesquisarFuncionario,
    Corretora.C01.Domain.Interfaces.IPesquisarPorIdRepositorio<tb18_proprietarioModel> pesquisarProprietario,
    Corretora.C01.Domain.Interfaces.ICadastrarRepositorio<tb11_imovelModel> cadastrar)
{
    public async Task<(CadastrarImovelDTO? dados, string mensagem, int codigo)> Executar(CadastrarImovelDTO dto)
    {
        var (tipo, _, _) = await pesquisarTipo.PesquisarPorIdAsync(dto.IdTipoImovel);
        if (tipo is null) return (null, "Tipo de imóvel não encontrado", 404);

        var (tipologia, _, _) = await pesquisarTipologia.PesquisarPorIdAsync(dto.IdTipologia);
        if (tipologia is null) return (null, "Tipologia não encontrada", 404);

        var (funcionario, _, _) = await pesquisarFuncionario.PesquisarPorIdAsync(dto.IdFuncionario);
        if (funcionario is null) return (null, "Funcionário não encontrado", 404);

        var (proprietario, _, _) = await pesquisarProprietario.PesquisarPorIdAsync(dto.IdProprietario);
        if (proprietario is null) return (null, "Proprietário não encontrado", 404);

        var model = new tb11_imovelModel
        {
            Descricao = dto.Descricao,
            Preco = dto.Preco,
            tb09_tipo_imovelModel = dto.IdTipoImovel,
            tb10_tipologiaModel = dto.IdTipologia,
            tb04_funcionarioModel = dto.IdFuncionario,
            tb18_proprietarioModel = dto.IdProprietario,
            Estado = true
        };

        var (dado, mensagem, codigo) = await cadastrar.CadastrarAsync(model);
        return dado is null ? (null, mensagem, codigo) : (dto, mensagem, codigo);
    }
}

