using Dot6.DataAccess;
using Dot6.DataModel;
using Dot6.Dto;
using Dot6.Services;
using Microsoft.EntityFrameworkCore;

namespace Dot6.HotChoco12.GraphQL.CRUD.Demo.GqlTypes;

public class QueryType
{
    public ICakeService _cakeService;
    public ICakeRepository _cakeRepository;
    public QueryType(ICakeService cakeService, ICakeRepository cakeRepository)
    {
        _cakeRepository = cakeRepository;
        _cakeService = cakeService;
    }
    public async Task<List<Cake>> AllCakesAsync() 
    { 
        return await _cakeService.GetAll();
    }

    public async Task<Cake> GetCakeById(int id)
    {
        return await _cakeService.GetById(id);
    }

    public async Task<List<Cake>> GetCakeByName(string name)
    {
        return await _cakeService.FilterByName(name);
    }
}