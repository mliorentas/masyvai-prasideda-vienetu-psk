using System.Collections.Generic;
using System.Threading.Tasks;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;

namespace MasyvaiPrasidedaVienetu.Interfaces
{
    public interface IDbService
    {
        Task RunDatabaseSeed();
    }
}
