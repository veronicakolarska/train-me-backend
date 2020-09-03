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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService userService;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService
        )
        {
            _logger = logger;
            this.userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> GetAll()
        {
            return this.userService.GetAll().Select((x) => new UserViewModel {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Password = x.Password,
                Age = x.Age,
                Gender = x.Gender,
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
