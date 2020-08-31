using System.Threading.Tasks;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{
    public class ProgramInstanceService : IProgramInstanceService
    {
        private readonly IRepository<Program> programRepository;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<ProgramInstance> programInstanceRepository;

        public ProgramInstanceService(
            IRepository<Program> programRepository,
            IRepository<User> userRepository,
            IRepository<ProgramInstance> programInstanceRepository
        )
        {
            this.programRepository = programRepository;
            this.userRepository = userRepository;
            this.programInstanceRepository = programInstanceRepository;
        }

        public async Task CreateNewInstance(Program program, User user)
        {
            if (program == null)
            {
                throw new ArgumentNullException(nameof(program), "Program cannot be null.");
            }

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            var userExists = this.userRepository.All().Any((x) => x.Id == user.Id);
            if (!userExists)
            {
                throw new ArgumentException("User does not exist in the database.");
            }

            var programExists = this.programRepository.All().Any((x) => x.Id == program.Id);
            if (!programExists)
            {
                throw new ArgumentException("Program does not exist in the database.");
            }


            var newExerciseInstances = program.Exercises.Select((x) => new ExerciseInstance()
            {
                ExerciseId = x.Id,
                Tempo = x.TempoDefault,
                Break = x.BreakDefault,
                Series = x.SeriesDefault,
            }).ToList();

            var newProgramInstance = new ProgramInstance
            {
                UserId = user.Id,
                ProgramId = program.Id,
                ExerciseInstances = newExerciseInstances,
            };

            await this.programInstanceRepository.AddAsync(newProgramInstance);
            await this.programInstanceRepository.SaveChangesAsync();
        }
    }
}