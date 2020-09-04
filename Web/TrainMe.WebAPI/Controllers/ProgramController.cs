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
    public class ProgramController : ControllerBase
    {
        private readonly ILogger<ProgramController> _logger;
        private readonly IProgramService programService;

        public ProgramController(
            ILogger<ProgramController> logger,
            IProgramService programService
        )
        {
            _logger = logger;
            this.programService = programService;
        }

        [HttpGet]
        public IEnumerable<ProgramViewModel> GetAll()
        {
            return this.programService.GetAll().Select((x) => new ProgramViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatorId = x.CreatorId,
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
