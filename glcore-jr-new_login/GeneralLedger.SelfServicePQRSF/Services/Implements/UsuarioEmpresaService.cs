using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class UsuarioEmpresaService : GenericService<UsuarioEmpresa>, IUsuarioEmpresaService
    {
        private readonly IUsuarioEmpresaRepository usuarioEmpresaRepository;

        public UsuarioEmpresaService(IUsuarioEmpresaRepository usuarioEmpresaRepository) : base(usuarioEmpresaRepository)
        {
            this.usuarioEmpresaRepository = usuarioEmpresaRepository;
        }

        public async Task<UsuarioEmpresa> GetUsuarioByEmail(string email)
        {
            return await usuarioEmpresaRepository.GetUsuarioByEmail(email);
        }
    }
}