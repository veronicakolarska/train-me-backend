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
            return this.userService.GetAll().Select((x) => new UserViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
                Gender = x.Gender,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            });
        }

        [HttpGet("programs")]
        [Authorize]
        public IEnumerable<ProgramInstanceViewModel> GetAllProgramInstancesByUserId()
        {
            var externalUserId = this.User.Identity.Name;

            this._logger.LogInformation("Getting user program instances - {externalUserId}", externalUserId);

            return this.userService.GetAllProgramInstancesByUserId(externalUserId).Select((x) => new ProgramInstanceViewModel
            {
                Id = x.Id,
                ProgramName = x.Program.Name,
                UserId = x.UserId,
                ProgramId = x.ProgramId,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            });
        }

        [HttpGet("{id}")]
        public ActionResult<UserViewModel> GetById(int id)
        {
            var exists = this.userService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            var result = userService.GetById(id);

            var userViewModel = new UserViewModel
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Age = result.Age,
                Gender = result.Gender,
                CreatedOn = result.CreatedOn,
                ModifiedOn = result.ModifiedOn
            };
            return this.Ok(userViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserInputModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Gender = model.Gender,
            };
            await this.userService.Create(user);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(UserInputModel model)
        {
            var user = this.userService.GetById(model.Id);
            if (user == null)
            {
                return this.NotFound();
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Age = model.Age;
            user.Gender = model.Gender;

            await this.userService.Update(user);
            return this.Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = userService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            await this.userService.Delete(id);
            return this.Ok();
        }
    }
}