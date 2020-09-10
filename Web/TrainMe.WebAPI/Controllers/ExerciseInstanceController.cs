using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrainMe.Data.Models;
using TrainMe.Services.Data;
using TrainMe.WebAPI.Models;

namespace TrainMe.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseInstanceController : ControllerBase
    {
        private readonly ILogger<ExerciseInstanceController> _logger;
        private readonly IExerciseInstanceService exerciseInstanceService;

        public ExerciseInstanceController(
            ILogger<ExerciseInstanceController> logger,
            IExerciseInstanceService exerciseInstanceService
        )
        {
            _logger = logger;
            this.exerciseInstanceService = exerciseInstanceService;
        }

        [HttpGet]
        public IEnumerable<ExerciseInstanceViewModel> GetAll()
        {
            return this.exerciseInstanceService.GetAll().Select((x) => new ExerciseInstanceViewModel
            {
                Id = x.Id,
                ExerciseId = x.ExerciseId,
                Series = x.Series,
                Repetitions = x.Repetitions,
                Tempo = x.Tempo,
                Break = x.Break,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            });
        }

        [HttpGet("{id}")]
        public ActionResult<ExerciseInstanceViewModel> GetById(int id)
        {
            var exists = this.exerciseInstanceService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            var result = exerciseInstanceService.GetById(id);


            var exerciseInstanceViewModel = new ExerciseInstanceViewModel
            {
                Id = result.Id,
                ExerciseId = result.ExerciseId,
                Series = result.Series,
                Repetitions = result.Repetitions,
                Tempo = result.Tempo,
                Break = result.Break,
                CreatedOn = result.CreatedOn,
                ModifiedOn = result.ModifiedOn
            };
            return this.Ok(exerciseInstanceViewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Post(ExerciseInstanceInputModel model)
        {
            var exerciseInstance = new ExerciseInstance
            {
                ExerciseId = model.ExerciseId,
                Series = model.Series,
                Repetitions = model.Repetitions,
                Tempo = model.Tempo,
                Break = model.Break,
            };
            await this.exerciseInstanceService.Create(exerciseInstance);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put()
        {
            this._logger.LogInformation("Test string for put - upgrade");
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = exerciseInstanceService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            await this.exerciseInstanceService.Delete(id);
            return this.Ok();
        }
    }
}