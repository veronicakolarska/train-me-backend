using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainMe.WebAPI.Models
{
    public class WorkdayViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public bool IsRestDay { get; set; }

        public int ProgramId { get; set; }

        public IEnumerable<ExerciseViewModel> Exercises { get; set; }
    }
}
