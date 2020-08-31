namespace TrainMe.Console
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainMe.Data;
    using TrainMe.Data.Models;
    using TrainMe.Data.Repositories;

    class Program
    {
        async static Task Main(string[] args)
        {
            var trainMeContext = new TrainMeContext();

            var efRepository = new EfRepository<User>(trainMeContext);
            await efRepository.AddAsync(new User()
            {
                FirstName = "Ivan",
                LastName = "Petrov",
                Email = "Ivan@abv.bg",
                Password = "12345678!",
                Age = 28,
                Gender = Gender.Male,
            });

            await efRepository.SaveChangesAsync();

            var users = efRepository.All().ToList();
            System.Console.WriteLine($"Users are = {users.Count}");

            // trainMeContext.Users.Add(new User()
            // {
            //     FirstName = "Ivan",
            //     LastName = "Ivanov",
            //     Email = "Ivan@abv.bg",
            //     Password = "12345678!",
            //     Age = 28,
            //     Gender = Gender.Male,
            // });

            // trainMeContext.Users.Add(new User()
            // {
            //     FirstName = "Petar",
            //     LastName = "Simeonov",
            //     Email = "pesho@abv.bg",
            //     Password = "0012345678!",
            //     Age = 25,
            //     Gender = Gender.Male,
            // });

            // trainMeContext.Resources.Add(new Resource()
            // {
            //     Name = "Push ups",
            //     Link = "https://www.youtube.com/watch?v=IODxDxX7oi4",
            //     Type = ResourceType.Link,
            //     Description = "Standard push ups",
            // });

            // trainMeContext.Resources.Add(new Resource()
            // {
            //     Name = "Crunches",
            //     Link = "https://www.youtube.com/watch?v=Xyd_fa5zoEU",
            //     Type = ResourceType.Link,
            //     Description = "Standard crunches",
            // });

            // var resourcePushUp = trainMeContext.Resources.AsQueryable().First(resource => resource.Exercises.Any(x => x.Exercise.Name == "Push ups"));

            // trainMeContext.Exercises.Add(new Exercise()
            // {
            //     Name = "Push ups",
            //     SeriesDefault = 3,
            //     RepetitionsDefault = 20,
            //     TempoDefault = "10/20",
            //     BreakDefault = 30,
            // });

            // var exercisePushUp = trainMeContext.Exercises.AsQueryable().First(exercise => exercise.Name == "Push ups");

            // var newExcersiceResource = new ExerciseResource()
            // {
            //     ResourceId = resourcePushUp.Id,
            //     ExerciseId = exercisePushUp.Id,
            // };
            // trainMeContext.ExerciseResources.Add(newExcersiceResource);

            // var resourceCrunches = trainMeContext.Resources.AsQueryable().First(resource => resource.Name == "Crunches");

            // trainMeContext.Exercises.Add(new Exercise()
            // {
            //     Name = "Crunches",
            //     SeriesDefault = 3,
            //     RepetitionsDefault = 30,
            //     TempoDefault = "10/20",
            //     BreakDefault = 30,
            // });

            // var exerciseCrunches = trainMeContext.Exercises.AsQueryable().First(exercise => exercise.Name == "Crunches");

            // var newExcersiceResourceTwo = new ExerciseResource()
            // {
            //     ResourceId = resourceCrunches.Id,
            //     ExerciseId = exerciseCrunches.Id,
            // };
            // trainMeContext.ExerciseResources.Add(newExcersiceResourceTwo);

            // var pushUps = trainMeContext.Exercises.AsQueryable().Where(exercise => exercise.Name == "Push ups").ToList().First();

            // var pushUpsInstance = new ExerciseInstance()
            // {
            //     ExerciseId = pushUps.Id,
            //     Series = 3,
            //     Repetitions = 25,
            //     Tempo = "10/25",
            //     Break = 30,
            // };

            // trainMeContext.ExerciseInstances.Add(pushUpsInstance);

            // var crunches = trainMeContext.Exercises.AsQueryable().Where(exercise => exercise.Name == "Crunches").ToList().First();

            // var crunchesInstance = new ExerciseInstance()
            // {
            //     ExerciseId = crunches.Id,
            //     Series = 4,
            //     Repetitions = 30,
            //     Tempo = "10/25",
            //     Break = 20,
            // };

            // trainMeContext.ExerciseInstances.Add(crunchesInstance);

            // var creator = trainMeContext.Users.AsQueryable().Where(person => person.FirstName == "Ivan").ToList().First();

            // trainMeContext.Programs.Add(new Data.Models.Program()
            // {
            //     Name = "Weight loss",
            //     CreatorId = creator.Id,
            //     Exercises = new HashSet<Exercise>()
            //     {
            //         crunches,
            //         pushUps,
            //     },
            // }
            // );

            // var program = trainMeContext.Programs.AsQueryable().Where(program => program.Name == "Weight loss").ToList().First();

            // trainMeContext.ProgramInstances.Add(new ProgramInstance()
            // {
            //     ProgramId = program.Id,
            //     UserId = creator.Id,
            //     ExerciseInstances = new HashSet<ExerciseInstance>()
            //     {
            //         pushUpsInstance,
            //         crunchesInstance,
            //     }
            // });
        }
    }
}