using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrainMe.Data.Models;
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
            return this.programInstanceService.GetAll().Select((x) => new ProgramInstanceViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                ProgramId = x.ProgramId,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            });
        }


        [HttpGet("{id}")]
        public ActionResult<ProgramInputModel> GetById(int id)
        {
            var exists = this.programInstanceService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            var result = programInstanceService.GetById(id);

            var programInstanceViewModel = new ProgramInstanceViewModel
            {
                Id = result.Id,
                ProgramId = result.ProgramId,
                UserId = result.UserId,
                CreatedOn = result.CreatedOn,
                ModifiedOn = result.ModifiedOn
            };
            return this.Ok(programInstanceViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProgramInstanceInputModel model)
        {
            var user = new ProgramInstance
            {
                ProgramId = model.ProgramId,
                UserId = model.UserId,
            };
            await this.programInstanceService.Create(user);
            return Ok();
        }

        [HttpPost("enroll/{id}")]
        [Authorize]
        public async Task<ActionResult> Enroll(int id)
        {
            var userIsAlreadyEnroled = await this.programInstanceService.Exists(id, this.User.Identity.Name);

            if (userIsAlreadyEnroled)
            {
                return this.BadRequest("User is already enrolled!");
            }

            // TODO: Map result
            var result = await this.programInstanceService.EnrollInProgram(id, this.User.Identity.Name);
            return this.Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(ProgramInstanceInputModel model)
        {
            var programInstance = this.programInstanceService.GetById(model.Id);
            if (programInstance == null)
            {
                return this.NotFound();
            }
            programInstance.ProgramId = model.ProgramId;
            programInstance.UserId = model.UserId;

            await this.programInstanceService.Update(programInstance);
            return this.Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = programInstanceService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            await this.programInstanceService.Delete(id);
            return this.Ok();
        }
    }
}