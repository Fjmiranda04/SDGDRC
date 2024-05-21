using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class ArticuloService : GenericService<Articulo>, IArticuloService
    {
        private readonly IArticuloRepository articuloRepository;

        public ArticuloService(IArticuloRepository articuloRepository) : base(articuloRepository)
        {
            this.articuloRepository = articuloRepository;
        }

        public async Task<IEnumerable<ArticuloShowDTO>> GetArticulos()
        {
            return await articuloRepository.GetArticulos();
        }
    }
}