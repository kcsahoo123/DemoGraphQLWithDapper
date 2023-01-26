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
    public async Task<int> SaveCakeAsync(Cake newCake)
    {
        return await _cakeService.SaveCake(newCake);
    }

    public async Task<Cake> UpdateCakeAsync(Cake updateCake)
    {
        //context.Cake.Update(updateCake);
        //await context.SaveChangesAsync();
        return updateCake;
    }

    public async Task<string> DeleteCakeAsync(int id)
    {
        int result=await _cakeService.DeleteCake(id);
        return "Record Deleted!";
    }
}