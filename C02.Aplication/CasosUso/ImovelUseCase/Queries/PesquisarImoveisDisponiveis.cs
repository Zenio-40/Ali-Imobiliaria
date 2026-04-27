using Corretora.C01.Domain;
using Corretora.C02.Aplication.CasosUso.ImovelUseCase.DTOs;

namespace Corretora.C02.Aplication.CasosUso.ImovelUseCase.Queries;

public class PesquisarImoveisDisponiveis(Corretora.C01.Domain.Interfaces.IPesquisarTodosRepositorio<tb11_imovelModel> pesquisar)
{
    public async Task<(IEnumerable<ImovelDTO>? dados, string mensagem, int codigo)> Executar(int pagina = 1, int quantidade = 20)
    {
        var (imoveis, mensagem, codigo) = await pesquisar.PesquisarTodosAsync(pagina, quantidade);
        if (imoveis is null) return (null, mensagem, codigo);

        var disponiveis = imoveis.Where(i => i.Estado).Select(i => new ImovelDTO
        {
            Id = i.Id,
            Descricao = i.Descricao,
            Preco = i.Preco,
            Estado = i.Estado,
            IdTipoImovel = i.tb09_tipo_imovelModel,
            TipoImovel = i.TipoImovel?.Descricao ?? string.Empty,
            IdTipologia = i.tb10_tipologiaModel,
            Tipologia = i.Tipologia?.Descricao ?? string.Empty,
            IdFuncionario = i.tb04_funcionarioModel,
            Funcionario = i.Funcionario?.Nome ?? string.Empty,
            IdProprietario = i.tb18_proprietarioModel,
            Proprietario = i.ProprietarioModel?.Nome ?? string.Empty
        });

        return (disponiveis, "Imóveis disponíveis encontrados", 200);
    }
}

