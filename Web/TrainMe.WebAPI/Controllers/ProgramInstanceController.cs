using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrainMe.Services.Data;
using TrainMe.WebAPI.Models;

namespace TrainMe.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgramInstanceController : ControllerBase
    {
        private readonly ILogger<ProgramInstanceController> _logger;
        private readonly IProgramInstanceService programInstanceService;

        public ProgramInstanceController(
            ILogger<ProgramInstanceController> logger,
            IProgramInstanceService programInstanceService
        )
        {
            _logger = logger;
            this.programInstanceService = programInstanceService;
        }

        [HttpGet]
        public IEnumerable<ProgramInstanceViewModel> GetAll()
        {
            return this.programInstanceService.GetAll().Select((x) => new ProgramInstanceViewModel {
                Id = x.Id,
                UserId = x.UserId,
                ProgramId = x.ProgramId,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            });
        }

        [HttpPost]
        public ActionResult Post()
        {
            this._logger.LogInformation("Test string for post");
            return Ok();
        }

        [HttpPut]
        public ActionResult Put()
        {
            this._logger.LogInformation("Test string for put - upgrade");
            return Ok();
        }

        [HttpPatch]
        public ActionResult Patch()
        {
            this._logger.LogInformation("Test string for patch");
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            this._logger.LogInformation("Test string for delete");
            return Ok();
        }



    }
}
