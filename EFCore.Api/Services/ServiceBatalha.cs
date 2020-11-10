using EFCore.Api.Interface;
using EFCore.Domain;
using EFCore.Infra.Interfaces;
using System.Threading.Tasks;

namespace EFCore.Api.Services
{
    public class ServiceBatalha : IServiceBatalha
    {
        private readonly IRepositoryBatalha batalha;
        public ServiceBatalha(IRepositoryBatalha batalha)
        {
            this.batalha = batalha;
        }
        public bool ExistBatalha(int Id)
        {
            return batalha.Exist(h => h.Id == Id);
        }

        public Batalha GetBatalhaById(int Id) =>
                batalha.GetById(Id);


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
            batalha.Remove(model);
            return await batalha.SaveChangesAsync();
        }
    }
}
