namespace Global.Progress.Data.Transactions
{
    public abstract class GameProgressTransaction
    {
        public abstract void Execute(GameProgress progress);
    }
}
