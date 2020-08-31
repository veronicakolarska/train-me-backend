using System;
using System.Threading.Tasks;
using TrainMe.Data.Models;

namespace TrainMe.Services.Data
{
    public interface IProgramInstanceService
    {
        Task CreateNewInstance(Program program, User user);
    }
}
