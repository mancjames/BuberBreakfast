using System.Runtime.CompilerServices;
using BuberBreakfast.Models;

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

    public Breakfast GetBreakfast(Guid id)
    {
        return _breakfasts[id];
    }
}