namespace Aegis.Ops
{
    public class ImportDatasetRequest
    {
        public int WorkspaceId
        {
            get;
            set;
        }

        public string PathToShapefile
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
