namespace Aegis.Cfg
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class Repository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Dataset> GetDatasets(int workspaceId)
        {
            return this.context.Datasets
                .AsNoTracking()
                .Where(x => x.WorkspaceId == workspaceId)
                .ToList();
        }

        public IEnumerable<Field> GetFields(int layerId)
        {
            return this.context.Fields
                .AsNoTracking()
                .Where(x => x.LayerId == layerId)
                .ToList();
        }

        public IEnumerable<Layer> GetLayers(int datasetId)
        {
            return this.context.Layers
                .AsNoTracking()
                .Where(x => x.DatasetId == datasetId)
                .ToList();
        }

        public IEnumerable<Workspace> GetWorkspaces()
        {
            return this.context.Workspaces
                .AsNoTracking()
                .ToList();
        }

        public Feature GetFeature(int layerId, int index)
        {
            return this.context.Features
                .AsNoTracking()
                .Include(x => x.FieldValues)
                .FirstOrDefault(x => x.LayerId == layerId && x.Index == index);
        }

        public void InsertFeature(Feature feature)
        {
            this.context.Features.Add(feature);
            this.context.SaveChanges();
        }

        public void InsertFeatures(params Feature[] features)
        {
            this.context.Features.AddRange(features);
            this.context.SaveChanges();
        }

        public void InsertField(Field field)
        {
            this.context.Fields.Add(field);
            this.context.SaveChanges();
        }

        public void InsertFields(params Field[] fields)
        {
            this.context.Fields.AddRange(fields);
            this.context.SaveChanges();
        }

        public void InsertFieldValue(FieldValue fieldValue)
        {
            this.context.FieldValues.Add(fieldValue);
            this.context.SaveChanges();
        }

        public void InsertFieldValues(params FieldValue[] fieldValues)
        {
            this.context.FieldValues.AddRange(fieldValues);
            this.context.SaveChanges();
        }

        public void InsertLayer(Layer layer)
        {
            this.context.Layers.Add(layer);
            this.context.SaveChanges();
        }

        public void InsertWorkspace(Workspace workspace)
        {
            this.context.Workspaces.Add(workspace);
            this.context.SaveChanges();
        }

        public void UpdateField(Field field)
        {
            this.context.Fields.Attach(field);
            this.context.Entry(field).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void UpdateLayer(Layer layer)
        {
            this.context.Layers.Attach(layer);
            this.context.Entry(layer).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void UpdateWorkspace(Workspace workspace)
        {
            this.context.Workspaces.Attach(workspace);
            this.context.Entry(workspace).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}