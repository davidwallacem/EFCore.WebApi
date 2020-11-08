using EFCore.Api.Interface;
using EFCore.Domain;
using EFCore.Infra.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Api.App
{
    public class AppBatalha : IAppBatalha
    {
        private readonly IRepositoryBatalha batalha;
        public AppBatalha(IRepositoryBatalha batalha)
        {
            this.batalha = batalha;
        }
        public bool ExistBatalha(int Id)
        {
            return batalha.GetBy(h => h.Id == Id).Any();
        }

        public Batalha GetBatalhaById(int Id) =>
                batalha.FindById(Id);


        //public IQueryable GetAllBatalhas() =>
        //        _batalha.GetAll()
        //              .AsNoTracking().OrderBy(h => h.Id);

        //public IQueryable GetBatalhasById(int Id) =>
        //    _batalha.GetBy(h => h.Id == Id);

        public async Task<bool> SalvarBatalha(Batalha model)
        {
            batalha.Add(model);
            return await batalha.SaveChangesAsync();
        }

        public async Task<bool> AtualizarBatalha(Batalha model)
        {
            batalha.Update(model);
            return await batalha.SaveChangesAsync();
        }

        public async Task<bool> DeletarBatalha(Batalha model)
        {
            batalha.Delete(model);
            return await batalha.SaveChangesAsync();
        }
    }
}
