namespace Aegis.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Aegis.Cfg;

    [RoutePrefix("api/workspaces")]
    public class WorkspacesController : ApiController
    {
        private readonly Repository repository;

        public WorkspacesController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route(Routes.Datastores)]
        public IHttpActionResult CreateDatastore([FromUri] string ws, [FromBody] Dataset dataset)
        {
            var workspace = this.repository.GetWorkspaceByName(ws);
            if (workspace == null)
            {
                return this.NotFound();
            }

            workspace.AddDataset(dataset);

            this.repository.InsertDataset(dataset);
            this.repository.UpdateWorkspace(workspace);

            var location = this.Url.Route(
                routeName: nameof(Routes.Datastore),
                routeValues: new { ws, ds = dataset.Name });

            return this.Created(location, dataset);
        }

        [HttpPost]
        [Route]
        public IHttpActionResult CreateWorkspace([FromBody] Workspace workspace)
        {
            this.repository.InsertWorkspace(workspace);

            var location = this.Url.Route(
                routeName: nameof(Routes.Workspace),
                routeValues: new { name = workspace.Name });

            return this.Created(location, workspace);
        }

        [HttpGet]
        [Route(Routes.Datastore, Name = nameof(Routes.Datastore))]
        public IHttpActionResult GetDatastore(string ws, string ds)
        {
            var workspace = this.repository.GetWorkspaceByName(ws);
            if (workspace == null)
            {
                return this.NotFound();
            }
                ;
            var datastore = workspace.Datasets
                .FirstOrDefault(x => x.Name.Equals(
                    ds,
                    StringComparison.InvariantCultureIgnoreCase));

            return datastore == null
                ? (IHttpActionResult)this.NotFound()
                : this.Json(datastore);
        }

        [HttpGet]
        [Route(Routes.Datastores)]
        public IHttpActionResult GetDatastores(string ws)
        {
            var workspace = this.repository.GetWorkspaceByName(ws);
            return workspace == null
                ? (IHttpActionResult)this.NotFound()
                : this.Json(workspace.Datasets);
        }

        [HttpGet]
        [Route(Routes.Workspace, Name = nameof(Routes.Workspace))]
        public IHttpActionResult GetWorkspace(string ws)
        {
            var workspace = this.repository.GetWorkspaceByName(ws);
            return workspace == null
                ? (IHttpActionResult)this.NotFound()
                : this.Json(workspace);
        }

        [HttpGet]
        [Route(Routes.FeatureTypes)]
        public IHttpActionResult GetFeatureTypes(string ws, string ds)
        {
            var workspace = this.repository
                .GetWorkspaceByName(ws);

            if (workspace == null)
            {
                return this.NotFound();
            }

            var dataset = workspace.Datasets
                .FirstOrDefault(x => x.Name.Equals(ds, StringComparison.InvariantCultureIgnoreCase));

            if (dataset == null)
            {
                return this.NotFound();
            }

            var layerDefinitions = dataset.Layers.Select(x => x.GetLayerDefinition());
            return this.Json(layerDefinitions);
        }

        [HttpGet]
        [Route]
        public IHttpActionResult GetWorkspaces()
        {
            var workspaces = this.repository.GetWorkspaces();
            return this.Json(workspaces);
        }

        private static class Routes
        {
            public const string Datastore = "{ws}/datastores/{ds}";
            public const string Datastores = "{ws}/datastores";
            public const string FeatureTypes = "{ws}/datastores/{ds}/featuretypes";
            public const string Workspace = "{ws}";
        }
    }
}