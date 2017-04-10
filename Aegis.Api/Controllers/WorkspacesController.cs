namespace Aegis.Api.Controllers
{
    using System.Web.Http;
    using Aegis.Data;

    [RoutePrefix("api/workspaces")]
    public class WorkspacesController : ApiController
    {
        private readonly WorkspaceRepository repository;

        public WorkspacesController(
            WorkspaceRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("{id}", Name = "GetWorkspace")]
        public IHttpActionResult Get([FromUri] int id)
        {
            var workspace = this.repository.GetById(id);
            return workspace == null
                ? (IHttpActionResult)this.NotFound()
                : this.Json(workspace);
        }

        [HttpGet]
        [Route(Name = "GetWorkspaces")]
        public IHttpActionResult Get()
        {
            var workspaces = this.repository.All();
            return this.Json(workspaces);
        }

        [HttpPost]
        [Route(Name = "PostWorkspace")]
        public IHttpActionResult Post([FromBody] Workspace workspace)
        {
            this.repository.Insert(workspace);
            var url = this.Url.Route("GetWorkspace", new { id = workspace.Id });
            return this.Created(url, workspace);
        }
    }
}