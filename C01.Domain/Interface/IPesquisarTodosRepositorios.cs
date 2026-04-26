using System.Collections.Generic;
using System.Threading.Tasks;

namespace Corretora.C01.Domain.Interface;

public interface IPesquisarTodosRepositorios<T>
{
    Task<(IEnumerable<T> dados, string mensagem, int codigo)> PesquisarTodosAsync( int pagina = 1, int quantidade = 20);
}
