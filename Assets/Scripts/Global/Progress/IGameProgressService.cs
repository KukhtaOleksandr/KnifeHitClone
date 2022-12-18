
using Global.Progress.Data;
using Global.Progress.Data.Transactions;

namespace Global.Progress
{
    public interface IGameProgressService
    {
        GameProgress GameProgress { get; }

        void MakeTransaction(GameProgressTransaction transaction);
    }
}
