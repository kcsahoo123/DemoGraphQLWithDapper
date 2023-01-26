using Dot6.DataAccess;
using Dot6.DataModel;
using Dot6.Dto;
using Dot6.Services;

namespace Dot6.HotChoco12.GraphQL.CRUD.Demo.GqlTypes;

public class MutationType
{
    public ICakeService _cakeService;
    public MutationType(ICakeService cakeService)
    {
        _cakeService = cakeService;
    }
    public async Task<List<Cake>> SaveCakeAsync(Cake newCake)
    {
        int noOfRecs= await _cakeService.SaveCake(newCake);
        var result= await _cakeService.GetAll();
        return result;
    }

    public async Task<Cake> UpdateCakeAsync(Cake updateCake)
    {
        return await _cakeService.UpdateCake(updateCake);
    }

    public async Task<List<Cake>> DeleteCakeAsync(int id)
    {
        int result=await _cakeService.DeleteCake(id);
        return await _cakeService.GetAll();
    }
}