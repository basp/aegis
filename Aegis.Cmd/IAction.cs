namespace Aegis.Cmd
{
    public interface IAction<TArgs>
    {
        void Execute(TArgs args);
    }
}
