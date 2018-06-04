using System.Threading.Tasks;
using System.Web.Http;
using Common;
using Services.Attributes;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.Logging;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.Controllers
{
    [RoutePrefix("database")]
    public class DatabaseController : ApiController
    {
        private IDbService _dbService;
        private ILogger _logger;

        public DatabaseController(ILogger logger, IDbService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        [HttpPost]
        [Route("seed")]
        [RequireRoleAccess(UserRole.Developer)]
        public async Task<IHttpActionResult> DatabaseSeed()
        {
            await _dbService.RunDatabaseSeed();
            return Ok();
        }
    }
}