using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrainMe.Common.Extensions;
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
        [Authorize]
        public IEnumerable<ProgramViewModel> GetAll()
        {
            return this.programService.GetAll().Select((x) => new ProgramViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Difficulty = x.Difficulty,
                Duration = x.WorkoutDays.Count,
                CreatorId = x.CreatorId,
                Picture = x.Picture,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn,
                IsUserEnrolled = this.User.IsAuthenticated() && x.ProgramInstances.Any((inst) => inst.User.ExternalId == this.User.GetExternalId())
            });
        }

        [Authorize]
        [HttpGet("filter")]
        public IEnumerable<ProgramViewModel> GetAll([FromQuery] ProgramsFilterInputModel filter)
        {
            return this.programService.GetAll(filter.Duration, filter.Difficulty, filter.Name).Select((x) => new ProgramViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Difficulty = x.Difficulty,
                CreatorId = x.CreatorId,
                Duration = x.WorkoutDays.Count,
                Picture = x.Picture,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            });
        }

        [HttpGet("{id}")]
        public ActionResult<ProgramViewModel> GetById(int id)
        {
            var exists = this.programService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }

            var result = programService.GetById(id);

            var programViewModel = new ProgramViewModel
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Difficulty = result.Difficulty,
                CreatorId = result.CreatorId,
                Duration = result.WorkoutDays.Count,
                Picture = result.Picture,
                CreatedOn = result.CreatedOn,
                ModifiedOn = result.ModifiedOn,
                Workdays = result.WorkoutDays.Select(x => new WorkdayViewModel
                {
                    Id = x.Id,
                    IsRestDay = x.IsRestDay,
                    Order = x.Order,
                    ProgramId = x.ProgramId,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    Exercises = x.ExercisesInWorkoutDay
                        .Select(y => y.Exercise)
                        .Select(y => new ExerciseViewModel
                        {
                            BreakDefault = y.BreakDefault,
                            CreatedOn = y.CreatedOn,
                            Id = y.Id,
                            ModifiedOn= y.ModifiedOn,
                            Name = y.Name,
                            RepetitionsDefault = y.RepetitionsDefault,
                            SeriesDefault = y.SeriesDefault,
                            TempoDefault = y.TempoDefault,
                        })
                }).OrderBy(x => x.Order)
            };
            return this.Ok(programViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProgramInputModel model)
        {
            var program = new TrainMe.Data.Models.Program
            {
                Name = model.Name,
                Description = model.Description,
                CreatorId = model.CreatorId,
                Picture = model.Picture,
                Difficulty = model.Difficulty
            };
            await this.programService.Create(program);
            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> Put(ProgramInputModel model)
        {
            var program = this.programService.GetById(model.Id);
            if (program == null)
            {
                return this.NotFound();
            }
            program.Name = model.Name;
            program.Description = model.Description;
            program.CreatorId = model.CreatorId;
            program.Picture = model.Picture;
            program.Difficulty = model.Difficulty;

            await this.programService.Update(program);
            return this.Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = programService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            await this.programService.Delete(id);
            return this.Ok();
        }
    }
}