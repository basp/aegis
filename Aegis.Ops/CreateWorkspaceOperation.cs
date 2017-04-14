namespace Aegis.Ops
{
    using System;
    using Optional;

    using static Optional.Option;

    using Req = CreateWorkspaceRequest;
    using Res = CreateWorkspaceResponse;

    public class CreateWorkspaceOperation : IOperation<Req, Res, Exception>
    {
        public Option<Res, Exception> Execute(Req req)
        {
            try
            {
                return None<Res, Exception>(new NotImplementedException());
            }
            catch(Exception ex)
            {
                return None<Res, Exception>(ex);
            }
        }
    }
}
