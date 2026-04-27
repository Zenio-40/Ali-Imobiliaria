using Corretora.C01.Domain;
using Corretora.C02.Aplication.CasosUso.ImovelUseCase.DTOs;

namespace Corretora.C02.Aplication.CasosUso.ImovelUseCase.Command;

public class ActualizarImovel(
    Corretora.C01.Domain.Interfaces.IPesquisarPorIdRepositorio<tb11_imovelModel> pesquisarImovel,
    Corretora.C01.Domain.Interfaces.IPesquisarPorIdRepositorio<tb09_tipo_imovelModel> pesquisarTipo,
    Corretora.C01.Domain.Interfaces.IPesquisarPorIdRepositorio<tb10_tipologiaModel> pesquisarTipologia,
    Corretora.C01.Domain.Interfaces.IPesquisarPorIdRepositorio<tb04_funcionarioModel> pesquisarFuncionario,
    Corretora.C01.Domain.Interfaces.IPesquisarPorIdRepositorio<tb18_proprietarioModel> pesquisarProprietario,
    Corretora.C01.Domain.Interfaces.IActualizarRepositorio<tb11_imovelModel> actualizar)
{
    public async Task<(ActualizarImovelDTO? dados, string mensagem, int codigo)> Executar(ActualizarImovelDTO dto)
    {
        var (imovel, _, _) = await pesquisarImovel.PesquisarPorIdAsync(dto.Id);
        if (imovel is null) return (null, "Imóvel não encontrado", 404);

        var (tipo, _, _) = await pesquisarTipo.PesquisarPorIdAsync(dto.IdTipoImovel);
        if (tipo is null) return (null, "Tipo de imóvel não encontrado", 404);

        var (tipologia, _, _) = await pesquisarTipologia.PesquisarPorIdAsync(dto.IdTipologia);
        if (tipologia is null) return (null, "Tipologia não encontrada", 404);

        var (funcionario, _, _) = await pesquisarFuncionario.PesquisarPorIdAsync(dto.IdFuncionario);
        if (funcionario is null) return (null, "Funcionário não encontrado", 404);

        var (proprietario, _, _) = await pesquisarProprietario.PesquisarPorIdAsync(dto.IdProprietario);
        if (proprietario is null) return (null, "Proprietário não encontrado", 404);

        imovel.Descricao = dto.Descricao;
        imovel.Preco = dto.Preco;
        imovel.tb09_tipo_imovelModel = dto.IdTipoImovel;
        imovel.tb10_tipologiaModel = dto.IdTipologia;
        imovel.tb04_funcionarioModel = dto.IdFuncionario;
        imovel.tb18_proprietarioModel = dto.IdProprietario;
        imovel.Estado = dto.Estado;

        var (dado, mensagem, codigo) = await actualizar.ActualizarAsync(imovel);
        return (dto, mensagem, codigo);
    }
}

