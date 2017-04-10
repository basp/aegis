namespace Aegis.Data
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class WorkspaceRepository
    {
        private readonly DataContext context;

        public WorkspaceRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Workspace> All()
        {
            return this.context.Workspaces
                .AsNoTracking()
                .Include(x => x.FeatureTypes)
                .ToList();
        }

        public Workspace GetById(int id)
        {
            return this.context.Workspaces
                .Include(x => x.FeatureTypes)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Workspace workspace)
        {
            this.context.Workspaces.Add(workspace);
        }
    }
}
