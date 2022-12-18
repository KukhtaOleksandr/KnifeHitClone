using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Global.Progress.Data;
using UnityEngine;

namespace Global.Progress
{
    public partial class GameProgressService
    {
        private static string Path => Application.persistentDataPath + "/game_progress.dat";
        
        public void Load()
        {
            var formatter = new BinaryFormatter();

            var deserialized = !File.Exists(Path) 
                ? CreateFileWithDefaultProgress(formatter, Path) 
                : LoadProgress(formatter, Path);

            _gameProgress = deserialized;
        }
		
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using FileStream file = File.Open(Path, FileMode.Open);

            formatter.Serialize(file, _gameProgress);
        }
        
        private GameProgress LoadProgress(IFormatter formatter, string path)
        {
            using FileStream file = File.OpenRead(path);

            var progress = formatter.Deserialize(file) as GameProgress;
            
            return progress;
        }

        private static GameProgress CreateFileWithDefaultProgress(IFormatter formatter, string path)
        {
            using FileStream file = File.Create(path);

            var data = new GameProgress();
            formatter.Serialize(file, data);

            return data;
        }
    }
}
