using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class EmpresaService : GenericService<Empresa>, IEmpresaService
    {
        private readonly IEmpresaRepository empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository) : base(empresaRepository)
        {
            this.empresaRepository = empresaRepository;
        }

        public async Task<Empresa> GetEmpresaByNit(string Nit)
        {
            return await empresaRepository.GetEmpresaByNit(Nit);
        }
    }
}