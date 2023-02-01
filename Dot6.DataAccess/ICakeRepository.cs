using Dot6.DataModel;
using Dot6.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot6.DataAccess
{
    public interface ICakeRepository
    {
        Task<Cake> GetFirst();
        Task<List<Cake>> GetAll();
        Task<List<Cake>> FilterByName(string name);
        Task<Cake> GetById(int id);
        Task<int> SaveCake(Cake cake);
        Task<Cake> UpdateCake(Cake cake);
        Task<Cake> CreateUpdateCake(Cake cake);
        Task<int> DeleteCake(int id);
    }
}
