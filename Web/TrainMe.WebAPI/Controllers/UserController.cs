// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

// namespace TrainMe.WebAPI.Controllers
// {
//     [Route("[controller]")]
//     [ApiController]
//     public class UserController : ControllerBase
//     {
//         [HttpGet("{id}")]
//         public User Get(int id)
//         {
//             return new User
//             {
//                 Id = id,
//                 FirstName = "Jimmy",
//                 LastName = "Smith"
//             };
//         }

//     }
// }