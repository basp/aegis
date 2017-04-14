namespace Aegis.Ops
{
    using Aegis.Data;

    public class CreateWorkspaceResponse
    {
        public CreateWorkspaceResponse(Workspace workspace)
        {
            this.Workspace = workspace;
        }

        public Workspace Workspace { get; }
    }
}
