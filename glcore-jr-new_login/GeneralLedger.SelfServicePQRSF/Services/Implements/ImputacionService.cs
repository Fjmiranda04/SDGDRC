using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class ImputacionService : GenericService<Imputacion>, IImputacionService
    {
        private readonly IImputacionRepository imputacionRepository;

        public ImputacionService(IImputacionRepository imputacionRepository) : base(imputacionRepository)
        {
            this.imputacionRepository = imputacionRepository;
        }

        public async Task<IEnumerable<Imputacion>> GetImputaciones(string nroFactura)
        {
            return await imputacionRepository.GetImputaciones(nroFactura);
        }
    }
}