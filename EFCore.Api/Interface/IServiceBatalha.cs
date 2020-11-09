using EFCore.Domain;
using System.Threading.Tasks;

namespace EFCore.Api.Interface
{
    public interface IServiceBatalha
    {
        bool ExistBatalha(int Id);

        Batalha GetBatalhaById(int Id);

        //IQueryable GetAllBatalhas();

        //IQueryable GetBatalhasById(int Id);

        Task<bool> SalvarBatalha(Batalha model);

        Task<bool> AtualizarBatalha(Batalha model);

        Task<bool> DeletarBatalha(Batalha model);
    }
}
