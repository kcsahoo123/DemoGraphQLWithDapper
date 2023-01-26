using Dot6.DataAccess;
using Dot6.DataModel;
using Dot6.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dot6.Services
{
    public class CakeService : ICakeService
    {
        public ICakeRepository _cakeRepository;
        public CakeService(ICakeRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
        }
        public async Task<List<Cake>> FilterByName(string name)
        {
            return await _cakeRepository.FilterByName(name);
        }

        public async Task<List<Cake>> GetAll()
        {
            return await _cakeRepository.GetAll();
        }

        public async Task<Cake> GetFirst()
        {
            return await _cakeRepository.GetFirst();
        }
        public async Task<Cake> GetById(int id)
        {
            return await _cakeRepository.GetById(id);
        }

        public async Task<int> SaveCake(Cake cake)
        {
            return await _cakeRepository.SaveCake(cake);
        }
        public async Task<Cake> UpdateCake(Cake cake)
        {
            return await _cakeRepository.UpdateCake(cake);
        }

        public async Task<int> DeleteCake(int id)
        {
            return await _cakeRepository.DeleteCake(id);
        }
    }
}
