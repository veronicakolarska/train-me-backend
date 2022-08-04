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
    public class ExerciseController : ControllerBase
    {
        private readonly ILogger<ExerciseController> _logger;
        private readonly IExerciseService exerciseService;

        public ExerciseController(
            ILogger<ExerciseController> logger,
            IExerciseService exerciseService
        )
        {
            _logger = logger;
            this.exerciseService = exerciseService;
        }

        [HttpGet]
        public IEnumerable<ExerciseViewModel> GetAll()
        {
            return this.exerciseService.GetAll().Select((x) => new ExerciseViewModel
            {
                Id = x.Id,
                Name = x.Name,
                SeriesDefault = x.SeriesDefault,
                RepetitionsDefault = x.RepetitionsDefault,
                TempoDefault = x.TempoDefault,
                BreakDefault = x.BreakDefault,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            });
        }

        [HttpGet("{id}")]
        public ActionResult<ExerciseViewModel> GetById(int id)
        {
            var exists = this.exerciseService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            var result = exerciseService.GetById(id);


            var exerciseViewModel = new ExerciseViewModel
            {
                Id = result.Id,
                Name = result.Name,
                SeriesDefault = result.SeriesDefault,
                RepetitionsDefault = result.RepetitionsDefault,
                TempoDefault = result.TempoDefault,
                BreakDefault = result.BreakDefault,
                CreatedOn = result.CreatedOn,
                ModifiedOn = result.ModifiedOn
            };
            return this.Ok(exerciseViewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Post(ExerciseInputModel model)
        {
            var exercise = new Exercise
            {
                Name = model.Name,
                SeriesDefault = model.SeriesDefault,
                RepetitionsDefault = model.RepetitionsDefault,
                TempoDefault = model.TempoDefault,
                BreakDefault = model.BreakDefault,
            };
            await this.exerciseService.Create(exercise);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(ExerciseInputModel model)
        {
            var exercise = this.exerciseService.GetById(model.Id);
            if (exercise == null)
            {
                return this.NotFound();
            }
            exercise.Name = model.Name;
            exercise.SeriesDefault = model.SeriesDefault;
            exercise.RepetitionsDefault = model.RepetitionsDefault;
            exercise.TempoDefault = model.TempoDefault;
            exercise.BreakDefault = model.BreakDefault;

            await this.exerciseService.Update(exercise);
            return this.Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = exerciseService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            await this.exerciseService.Delete(id);
            return this.Ok();
        }
    }
}