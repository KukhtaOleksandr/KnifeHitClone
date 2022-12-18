using System;

namespace Global.Progress.Data
{

    [Serializable]
    public class GameProgress
    {
        public int MaxStage { get; set; }
        
        public int MaxScore { get; set; }
    }
}
