using Stages;

namespace Architecure.Services
{
    public interface IStageConfigGeneratorService
    {
        int GetCurrentStageNumber();
        StageConfig GetConfig();
        void Reset();
    }
}