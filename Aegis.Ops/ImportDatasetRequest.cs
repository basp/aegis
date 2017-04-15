namespace Aegis.Ops
{
    public class ImportDatasetRequest
    {
        public int WorkspaceId
        {
            get;
            set;
        }

        public ILayer Layer
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
