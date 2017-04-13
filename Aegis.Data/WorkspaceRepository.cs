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

        public IEnumerable<Workspace> All(int skip, int top)
        {
            return this.context.Workspaces
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(top)
                .Include(x => x.FeatureTypes)
                .ToList();
        }

        public Workspace Get(int id)
        {
            return this.context.Workspaces
                .Include(x => x.FeatureTypes)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Workspace workspace)
        {
            this.context.Workspaces.Add(workspace);
            this.context.SaveChanges();
        }

        public void Update(Workspace workspace)
        {
            this.context.Workspaces.Attach(workspace);
            this.context.Entry(workspace).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
