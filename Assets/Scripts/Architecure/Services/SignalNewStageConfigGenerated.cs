using Stages;

namespace Architecure.Services
{
    public struct SignalNewStageConfigGenerated : ISignalNewStageNumberGenerated, ISignalNewStageConfigGenerated
    {
        public int StageNumber { get; set; }
        public StageConfig StageConfig { get; set; }
    }
    public interface ISignalNewStageNumberGenerated
    {
        int StageNumber { get; set; }
    }

    public interface ISignalNewStageConfigGenerated
    {
        StageConfig StageConfig { get; set; }
    }
}