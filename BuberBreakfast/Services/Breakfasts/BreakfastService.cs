using System.Runtime.CompilerServices;
using BuberBreakfast.Controllers;
using BuberBreakfast.Models;
using ErrorOr;
using BuberBreakfast.ServiceErrors;

namespace BuberBreakfast.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{
        //only storing in memory as learning project
        //however - when using in real use LINQ to add to sql tables 
    
    private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();
    public void CreateBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
 
    }

    public void DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id)
    {
        if (_breakfasts.TryGetValue(id, out var breakfast))
        {
            return breakfast;
        }
        return Errors.Breakfast.NotFound;
    }

    public void UpsertBreakfast(Breakfast breakfast)
    {
        _breakfasts[breakfast.Id] = breakfast;
    }
}
