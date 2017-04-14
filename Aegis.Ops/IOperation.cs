namespace Aegis.Ops
{
    using Optional;

    public interface IOperation<TReq, TRes, TEx>
    {
        Option<TRes, TEx> Execute(TReq req);
    }
}
