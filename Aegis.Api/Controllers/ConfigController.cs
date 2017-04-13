namespace Aegis.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Aegis.Data;

    [RoutePrefix("api/workspaces")]
    public class ConfigController : ApiController
    {
        private static class RouteNames
        {
            public const string GetWorkspace = "GetWorkspace";
            public const string GetFeatureType = "GetFeatureType";
        }

        private readonly WorkspaceRepository repository;

        public ConfigController(
            WorkspaceRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("{id}", Name = RouteNames.GetWorkspace)]
        public IHttpActionResult Get(
            [FromUri] int id)
        {
            var workspace = this.repository.Get(id);
            return workspace == null
                ? (IHttpActionResult)this.NotFound()
                : this.Json(workspace);
        }

        [HttpGet]
        public IHttpActionResult Get(
            [FromUri] int skip = 0,
            [FromUri] int top = 100)
        {
            var workspaces = this.repository.All(skip, top);
            return this.Json(workspaces);
        }

        [HttpGet]
        [Route("{workspaceId}/featuretypes")]
        public IHttpActionResult GetFeatureTypes(
            [FromUri] int workspaceId,
            [FromUri] int skip = 0,
            [FromUri] int top = 100)
        {
            var workspace = this.repository.Get(workspaceId);
            return this.Json(workspace.FeatureTypes);
        }

        [HttpGet]
        [Route(
            "{workspaceId}/featuretypes/{featureTypeId}",
            Name = RouteNames.GetFeatureType)]
        public IHttpActionResult GetFeatureType(
            [FromUri] int workspaceId,
            [FromUri] int featureTypeId)
        {
            var workspace = this.repository.Get(workspaceId);
            var featureType = workspace.FeatureTypes.FirstOrDefault();
            return featureType == null
                ? (IHttpActionResult)this.NotFound()
                : this.Json(featureType);
        }

        [HttpPost]
        [Route("{workspaceId}/featuretypes")]
        public IHttpActionResult InsertFeatureType(
            [FromUri] int workspaceId,
            [FromBody] FeatureType featureType)
        {
            var workspace = this.repository.Get(workspaceId);
            workspace.FeatureTypes.Add(featureType);

            this.repository.Update(workspace);

            var routeValues = new
            {
                workspaceId,
                featureTypeId = featureType.Id,
            };

            var location = this.Url.Route(
                RouteNames.GetFeatureType,
                routeValues);

            return this.Created(location, featureType);
        }

        [HttpPost]
        public IHttpActionResult InsertWorkspace(
            [FromBody] Workspace workspace)
        {
            this.repository.Insert(workspace);

            var routeValues = new { id = workspace.Id };
            var location = this.Url.Route(
                RouteNames.GetWorkspace,
                routeValues);

            return this.Created(location, workspace);
        }

        [HttpPut]
        public IHttpActionResult UpdateWorkspace(
            [FromBody] Workspace workspace)
        {
            this.repository.Update(workspace);
            return this.Ok();
        }
    }
}