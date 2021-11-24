using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;

namespace CodeSavvy.Domain.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<Favorite> CreateFavoriteRecord(Favorite favorite);
        Task<Favorite> DeleteFavoriteRecord(int favoriteId);
        Task<Favorite> GetFavoriteRecord(int favoriteId);
        Task<Favorite> UpdateFavoriteRecord(int favoriteId, Favorite favorite);
        Task<List<Favorite>> GetFavoritesForEmployee(Employee employee);
    }
}
