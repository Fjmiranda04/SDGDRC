using GeneralLedger.SelfServiceCore.Data.Repositories.Profilers;

namespace GeneralLedger.SelfServiceCore.Services.Profilers.Implements
{
    public class ProfilerService : IProfilerService
    {
        private readonly IProfilerRepository profilerRepository;

        public ProfilerService(IProfilerRepository profilerRepository)
        {
            this.profilerRepository = profilerRepository;
        }

        public IProfilerRepository GetInstancia()
        {
            return this.profilerRepository;
        }
    }
}