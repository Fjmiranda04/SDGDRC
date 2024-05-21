using GeneralLedger.SelfServiceCore.Data.Repositories.Profilers;

namespace GeneralLedger.SelfServiceCore.Services.Profilers
{
    public interface IProfilerService
    {
        IProfilerRepository GetInstancia();
    }
}