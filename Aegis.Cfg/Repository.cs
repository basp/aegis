namespace Aegis.Cfg
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Optional;

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

        public Feature GetFeature(int layerId, int index)
        {
            return this.context.Features
                .AsNoTracking()
                .Include(x => x.FieldValues)
                .FirstOrDefault(x => x.LayerId == layerId && x.Index == index);
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

        public Workspace GetWorkspace(int id)
        {
            return this.context.Workspaces
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public Workspace GetWorkspaceByName(string name)
        {
            return this.context.Workspaces
                .AsNoTracking()
                .Where(x => x.Name == name)
                .FirstOrDefault();
        }

        public IEnumerable<Workspace> GetWorkspaces()
        {
            return this.context.Workspaces
                .AsNoTracking()
                .ToList();
        }

        public void InsertDataset(Dataset dataset)
        {
            this.context.Datasets.Add(dataset);
            this.context.SaveChanges();
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

        public Option<Workspace, Exception> TryGetWorkspace(int id)
        {
            try
            {
                var workspace = this.context.Workspaces
                    .AsNoTracking()
                    .Single(x => x.Id == id);

                return Option.Some<Workspace, Exception>(workspace);
           }
            catch (Exception ex)
            {
                return Option.None<Workspace, Exception>(ex);
            }
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