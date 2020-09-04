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
