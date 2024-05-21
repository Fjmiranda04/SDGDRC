using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class ElementoService : GenericService<Elemento>, IElementoService
    {
        private readonly IElementoRepository elementoRepository;

        public ElementoService(IElementoRepository elementoRepository) : base(elementoRepository)
        {
            this.elementoRepository = elementoRepository;
        }
    }
}