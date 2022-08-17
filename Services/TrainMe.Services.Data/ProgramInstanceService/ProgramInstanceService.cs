using System.Threading.Tasks;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrainMe.Services.Data
{
    public class ProgramInstanceService : IProgramInstanceService
    {
        private readonly IRepository<Program> programRepository;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<ProgramInstance> programInstanceRepository;

        private readonly IRepository<ExerciseInstance> exerciseInstanceRepository;
        private readonly IRepository<ExerciseInstanceInWorkoutDayInstance> exerciseInstanceInWorkdayInstanceRepository;

        public ProgramInstanceService(
            IRepository<Program> programRepository,
            IRepository<User> userRepository,
            IRepository<ProgramInstance> programInstanceRepository,
            IRepository<ExerciseInstance> exerciseInstanceRepository,
            IRepository<ExerciseInstanceInWorkoutDayInstance> exerciseInstanceInWorkdayInstanceRepository
        )
        {
            this.programRepository = programRepository;
            this.userRepository = userRepository;
            this.programInstanceRepository = programInstanceRepository;
            this.exerciseInstanceRepository = exerciseInstanceRepository;
            this.exerciseInstanceInWorkdayInstanceRepository = exerciseInstanceInWorkdayInstanceRepository;
        }

        public async Task Create(ProgramInstance programInstance)
        {
            await this.programInstanceRepository.AddAsync(programInstance);
            await this.programInstanceRepository.SaveChangesAsync();

        }

        public async Task<ProgramInstance> EnrollInProgram(int programId, string externalUserId)
        {
            var program = await this.programRepository
                .All()
                .Include(x => x.WorkoutDays)
                .ThenInclude(x => x.ExercisesInWorkoutDay)
                .ThenInclude(x => x.Exercise)
                .FirstOrDefaultAsync(x => x.Id == programId);

            if (program == null)
            {
                throw new ArgumentException("Program does not exist in the database.");
            }

            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.ExternalId == externalUserId);

            if (user == null)
            {
                throw new ArgumentException("User does not exist in the database.");
            }

            var newWorkdayInstances = program.WorkoutDays
                .Select(x => new WorkoutDayInstance
                {
                    IsRestDay = x.IsRestDay,
                    Order = x.Order,
                    WorkoutDayId = x.Id,
                })
                .ToList();

            var newProgramInstance = new ProgramInstance
            {
                UserId = user.Id,
                ProgramId = program.Id,
                WorkoutDayInstances = newWorkdayInstances,
            };

            var newExerciseInstances = program.WorkoutDays
                .SelectMany(x => x.ExercisesInWorkoutDay.Select(y => y.Exercise))
                .DistinctBy(x => x.Id)
                .Select((x) => new ExerciseInstance()
                {
                    ExerciseId = x.Id,
                    Tempo = x.TempoDefault,
                    Break = x.BreakDefault,
                    Series = x.SeriesDefault,
                    Repetitions = x.RepetitionsDefault,
                }).ToList();

            var newExerciseInstanceInWorkdayInstances = program
                .WorkoutDays
                .SelectMany(x => x.ExercisesInWorkoutDay)
                .Select(x => new ExerciseInstanceInWorkoutDayInstance
                {
                    WorkoutDayInstance = newWorkdayInstances.FirstOrDefault(y => y.WorkoutDayId == x.WorkoutDayId),
                    ExerciseInstance = newExerciseInstances.FirstOrDefault(y => y.ExerciseId == x.ExerciseId),
                });


            await this.programInstanceRepository.AddAsync(newProgramInstance);
            await this.exerciseInstanceRepository.AddAsync(newExerciseInstances);
            await this.exerciseInstanceInWorkdayInstanceRepository.AddAsync(newExerciseInstanceInWorkdayInstances);
            await this.programInstanceRepository.SaveChangesAsync();

            return newProgramInstance;
        }

        public async Task Delete(int id)
        {
            var programInstance = this.GetById(id);
            this.programInstanceRepository.Delete(programInstance);
            await this.programInstanceRepository.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return this.programInstanceRepository.All().Any((x) => x.Id == id);
        }

        public Task<bool> Exists(int programId, string externalUserId)
        {
            return this.programInstanceRepository
                .All()
                .AnyAsync(x => x.ProgramId == programId && x.User.ExternalId == externalUserId);
        }

        public IEnumerable<ProgramInstance> GetAll()
        {
            var programInstances = this.programInstanceRepository.All();
            return programInstances;
        }

        public ProgramInstance GetById(int id)
        {
            return this.programInstanceRepository.All()
                .Include(x => x.WorkoutDayInstances)
                .ThenInclude(x => x.ExerciseInstancesInWorkoutDayInstances)
                .ThenInclude(x => x.ExerciseInstance)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task Update(ProgramInstance programInstance)
        {
            this.programInstanceRepository.Update(programInstance);
            await this.programInstanceRepository.SaveChangesAsync();
        }
    }
}