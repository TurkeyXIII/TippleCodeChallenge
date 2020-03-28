using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICocktailService
    {
        Task<Cocktail> GetRandomCocktail();
    }
}
